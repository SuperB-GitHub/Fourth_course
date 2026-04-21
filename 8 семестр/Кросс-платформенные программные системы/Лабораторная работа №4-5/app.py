import os
import warnings
os.environ['TF_ENABLE_ONEDNN_OPTS'] = '0'
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '3'
warnings.filterwarnings('ignore')

from flask import Flask, render_template, request, jsonify
from nn import predict, get_model
from PIL import Image
import io
import base64

# Добавьте импорты для БД
from results import Predictions
from database.database import db_session, init_db

app = Flask(__name__)
app.config['MAX_CONTENT_LENGTH'] = 16 * 1024 * 1024

# Инициализация БД
init_db()

# Загружаем модель при старте
print("Загрузка модели...")
model = get_model()
print("Модель готова")

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/history-page')
def history_page():
    return render_template('history.html')

@app.route('/predict', methods=['POST'])
def predict_route():
    try:
        if 'image' not in request.files:
            return jsonify({'error': 'Нет файла'}), 400
        
        file = request.files['image']
        if file.filename == '':
            return jsonify({'error': 'Файл не выбран'}), 400
        
        # Читаем байты для сохранения в БД
        image_bytes = file.read()
        
        # Открываем изображение для предсказания
        image = Image.open(io.BytesIO(image_bytes))
        
        # Предсказание
        result = predict(image, original_filename=file.filename)
        
        # Получаем вероятности для каждой фигуры
        probs = result['probabilities']
        
        # Конвертируем изображение в base64 для сохранения
        image_base64 = base64.b64encode(image_bytes).decode('utf-8')
        
        # Сохраняем в БД
        new_prediction = Predictions(
            filename=file.filename,
            image_data=image_base64,
            predicted_class=result['shape'],
            confidence=result['confidence'] / 100.0,
            probabilities_circle=probs['Круг'] / 100.0,
            probabilities_square=probs['Квадрат'] / 100.0,
            probabilities_triangle=probs['Треугольник'] / 100.0
        )
        
        db_session.add(new_prediction)
        db_session.commit()
        print(f"Сохранено в БД: {file.filename} -> {result['shape']}")
        
        # Подготовка изображения для отображения на сайте
        display = image.convert('RGB') if image.mode != 'RGB' else image
        
        buffered = io.BytesIO()
        display.save(buffered, format='PNG')
        img_base64 = base64.b64encode(buffered.getvalue()).decode()
        
        return jsonify({
            'success': True,
            'prediction': result['shape'],
            'confidence': round(result['confidence'], 2),
            'probabilities': result['probabilities'],
            'image': img_base64,
            'filename': file.filename
        })
        
    except Exception as e:
        print(f"Ошибка: {e}")
        return jsonify({'error': str(e)}), 500

@app.route('/history', methods=['GET'])
def get_history():
    from results import Predictions
    predictions = db_session.query(Predictions).order_by(Predictions.created_at.desc()).limit(50).all()
    return jsonify([{
        'id': p.id,
        'filename': p.filename,
        'predicted_class': p.predicted_class,
        'confidence': p.confidence,
        'image_data': p.image_data,  # Добавьте это поле в ответ
        'created_at': p.created_at.isoformat() if p.created_at else None
    } for p in predictions])

if __name__ == '__main__':
    app.run(debug=False, port=5000)