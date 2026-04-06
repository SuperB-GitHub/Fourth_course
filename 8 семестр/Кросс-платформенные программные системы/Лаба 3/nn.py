from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense, Dropout
from tensorflow.keras.optimizers import Adam
import os
import numpy as np
from PIL import Image
from datetime import datetime

_model = None

# Создаем папку для сохранения предобработанных изображений
PROCESSED_SAVE_DIR = 'processed_images'
os.makedirs(PROCESSED_SAVE_DIR, exist_ok=True)

def create_model():
    """Создает модель (такая же как при обучении)"""
    model = Sequential([
        Dense(256, activation='relu', input_shape=(400,)),
        Dropout(0.4),
        Dense(128, activation='relu'),
        Dropout(0.3),
        Dense(64, activation='relu'),
        Dropout(0.3),
        Dense(32, activation='relu'),
        Dense(3, activation='softmax')
    ])
    
    model.compile(
        optimizer=Adam(learning_rate=0.0005),
        loss='categorical_crossentropy',
        metrics=['accuracy']
    )
    
    cur_dir = os.path.dirname(os.path.abspath(__file__))
    w_path = os.path.join(cur_dir, 'best.weights.h5')
    
    if os.path.exists(w_path):
        model.load_weights(w_path)
        print("✓ Веса загружены")
    else:
        print("✗ Веса не найдены, запустите train_model.py")
    
    return model

def get_model():
    global _model
    if _model is None:
        _model = create_model()
    return _model

def save_processed_image(img_array, original_filename):
    """Сохраняет предобработанное изображение 20x20 (фон черный, фигура в серых тонах)"""
    # Убираем белый фон, делаем его черным
    # Находим белые пиксели (255) и заменяем их на 0
    img_array_clean = img_array.copy()
    
    # Если значение близко к белому ( > 200), делаем черным (фон)
    img_array_clean = np.where(img_array_clean > 200, 0, img_array_clean)
    
    # Преобразуем в изображение
    img_pil = Image.fromarray(img_array_clean.astype(np.uint8))
    
    # Создаем имя файла с timestamp
    timestamp = datetime.now().strftime("%Y%m%d_%H%M%S_%f")[:-3]
    base_name = os.path.splitext(os.path.basename(original_filename))[0]
    filename = f"{timestamp}_{base_name}_processed.png"
    filepath = os.path.join(PROCESSED_SAVE_DIR, filename)
    
    # Сохраняем
    img_pil.save(filepath)
    print(f"Предобработанное изображение сохранено: {filepath}")
    
    return filepath

def preprocess_image(image, save=True, original_filename="unknown"):
    """Предобработка изображения для нейросети"""
    
    # Приводим к черно-белому
    if image.mode != 'L':
        image = image.convert('L')
    
    # Изменяем размер
    image = image.resize((20, 20), Image.Resampling.LANCZOS)
    
    # Получаем массив
    img_array = np.array(image)
    
    # Инвертируем если нужно (чтобы фигура была светлой на темном фоне)
    if np.mean(img_array) > 127:
        img_array = 255 - img_array
    
    # Сохраняем изображение (с удалением белого фона)
    if save:
        save_processed_image(img_array, original_filename)
    
    # Нормализуем для нейросети (0-1)
    img_array_normalized = img_array.astype(np.float32) / 255.0
    img_array_normalized = img_array_normalized.flatten()
    img_array_normalized = img_array_normalized.reshape(1, -1)
    
    return img_array_normalized

def predict(image, original_filename="unknown"):
    """Предсказание фигуры с сохранением предобработанного изображения"""
    model = get_model()
    processed = preprocess_image(image, save=True, original_filename=original_filename)
    pred = model.predict(processed, verbose=0)
    
    classes = ['Круг', 'Треугольник', 'Квадрат']
    predicted_class = np.argmax(pred[0])
    confidence = float(np.max(pred[0]) * 100)
    
    return {
        'shape': classes[predicted_class],
        'confidence': confidence,
        'probabilities': {
            'Круг': float(pred[0][0] * 100),
            'Треугольник': float(pred[0][1] * 100),
            'Квадрат': float(pred[0][2] * 100)
        }
    }