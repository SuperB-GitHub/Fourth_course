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

app = Flask(__name__)
app.config['MAX_CONTENT_LENGTH'] = 16 * 1024 * 1024

# Загружаем модель при старте
print("Загрузка модели...")
model = get_model()
print("Модель готова")

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/predict', methods=['POST'])
def predict_route():
    try:
        if 'image' not in request.files:
            return jsonify({'error': 'Нет файла'}), 400
        
        file = request.files['image']
        if file.filename == '':
            return jsonify({'error': 'Файл не выбран'}), 400
        
        # Открываем изображение
        image = Image.open(file.stream)
        
        # Предсказание (с сохранением предобработанного изображения)
        result = predict(image, original_filename=file.filename)
        
        # Подготовка изображения для отображения на сайте
        if image.mode != 'RGB':
            display = image.convert('RGB')
        else:
            display = image
        
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

if __name__ == '__main__':
    app.run(debug=False, port=5000)