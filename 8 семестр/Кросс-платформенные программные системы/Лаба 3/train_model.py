import os
os.environ['TF_ENABLE_ONEDNN_OPTS'] = '0'
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '3'

import numpy as np
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense, Dropout
from tensorflow.keras.optimizers import Adam
from tensorflow.keras.utils import to_categorical
from sklearn.model_selection import train_test_split
from PIL import Image, ImageDraw
import random
import math

def generate_outline_square(size=20):
    """Генерирует квадрат в виде контура (как на твоей картинке)"""
    img = Image.new('L', (size, size), color=255)
    draw = ImageDraw.Draw(img)
    
    margin = random.randint(3, 5)
    offset = random.randint(-1, 1)
    
    # Рисуем 4 линии по контуру
    # Левая вертикаль
    draw.line([(margin + offset, margin), (margin + offset, size - margin)], fill=0, width=1)
    # Правая вертикаль
    draw.line([(size - margin + offset, margin), (size - margin + offset, size - margin)], fill=0, width=1)
    # Верхняя горизонталь
    draw.line([(margin, margin + offset), (size - margin, margin + offset)], fill=0, width=1)
    # Нижняя горизонталь
    draw.line([(margin, size - margin + offset), (size - margin, size - margin + offset)], fill=0, width=1)
    
    return img

def generate_outline_triangle(size=20):
    """Генерирует треугольник в виде контура"""
    img = Image.new('L', (size, size), color=255)
    draw = ImageDraw.Draw(img)
    
    center = size // 2
    margin = random.randint(4, 6)
    
    # Три линии треугольника
    points = [
        (center, margin),
        (margin, size - margin),
        (size - margin, size - margin)
    ]
    
    draw.line([points[0], points[1]], fill=0, width=1)
    draw.line([points[1], points[2]], fill=0, width=1)
    draw.line([points[2], points[0]], fill=0, width=1)
    
    return img

def generate_outline_circle(size=20):
    """Генерирует круг в виде контура"""
    img = Image.new('L', (size, size), color=255)
    draw = ImageDraw.Draw(img)
    
    center = size // 2
    r = random.randint(6, 8)
    
    draw.ellipse([center - r, center - r, center + r, center + r], outline=0, width=1)
    
    return img

def generate_filled_square(size=20):
    """Залитый квадрат"""
    img = Image.new('L', (size, size), color=255)
    draw = ImageDraw.Draw(img)
    
    margin = random.randint(3, 6)
    draw.rectangle([margin, margin, size - margin, size - margin], fill=0)
    
    return img

def generate_filled_circle(size=20):
    """Залитый круг"""
    img = Image.new('L', (size, size), color=255)
    draw = ImageDraw.Draw(img)
    
    center = size // 2
    r = random.randint(6, 8)
    draw.ellipse([center - r, center - r, center + r, center + r], fill=0)
    
    return img

def generate_filled_triangle(size=20):
    """Залитый треугольник"""
    img = Image.new('L', (size, size), color=255)
    draw = ImageDraw.Draw(img)
    
    center = size // 2
    margin = random.randint(4, 6)
    
    points = [
        (center, margin),
        (margin, size - margin),
        (size - margin, size - margin)
    ]
    draw.polygon(points, fill=0)
    
    return img

def generate_shape_image(shape_type, variant='random', size=20):
    """Генерирует изображение с разными вариантами"""
    
    if variant == 'outline':
        if shape_type == 'square':
            img = generate_outline_square(size)
        elif shape_type == 'triangle':
            img = generate_outline_triangle(size)
        else:
            img = generate_outline_circle(size)
    elif variant == 'filled':
        if shape_type == 'square':
            img = generate_filled_square(size)
        elif shape_type == 'triangle':
            img = generate_filled_triangle(size)
        else:
            img = generate_filled_circle(size)
    else:  # random
        variant_choice = random.choice(['outline', 'filled'])
        return generate_shape_image(shape_type, variant_choice, size)
    
    # Добавляем небольшой шум
    img_array = np.array(img)
    noise = np.random.normal(0, random.randint(0, 15), img_array.shape)
    img_array = np.clip(img_array + noise, 0, 255)
    
    # Иногда инвертируем
    if random.random() > 0.8:
        img_array = 255 - img_array
    
    # Нормализация
    img_array = img_array.astype(np.float32) / 255.0
    img_array = img_array.flatten()
    
    return img_array

def generate_dataset(samples_per_class=8000):
    """Генерирует большой разнообразный датасет"""
    X = []
    y = []
    
    shapes = ['circle', 'triangle', 'square']
    variants = ['outline', 'filled']
    
    for idx, shape in enumerate(shapes):
        print(f"Генерация {shape}...")
        for _ in range(samples_per_class):
            # 50% outline, 50% filled
            variant = random.choice(variants)
            img = generate_shape_image(shape, variant)
            X.append(img)
            y.append(idx)
    
    X = np.array(X)
    y = to_categorical(y, num_classes=3)
    
    return X, y

def create_model():
    """Создает нейросеть"""
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
    
    return model

def train():
    print("=== ГЕНЕРАЦИЯ РАСШИРЕННОГО ДАТАСЕТА ===")
    print("Включает залитые фигуры и фигуры в виде контура (как на твоей картинке)")
    
    X, y = generate_dataset(samples_per_class=6000)  # 6000 на фигуру = 18000 всего
    
    X_train, X_test, y_train, y_test = train_test_split(
        X, y, test_size=0.2, random_state=42, stratify=y
    )
    
    print(f"Train: {X_train.shape}, Test: {X_test.shape}")
    
    model = create_model()
    model.summary()
    
    print("\n=== ОБУЧЕНИЕ ===")
    history = model.fit(
        X_train, y_train,
        validation_data=(X_test, y_test),
        epochs=50,
        batch_size=64,
        verbose=1
    )
    
    # Оценка
    loss, acc = model.evaluate(X_test, y_test, verbose=0)
    print(f"\nТочность на тесте: {acc:.4f}")
    
    # Сохраняем веса
    model.save_weights('best.weights.h5')
    print("Веса сохранены в best.weights.h5")
    
    # Детальное тестирование
    print("\n=== ДЕТАЛЬНОЕ ТЕСТИРОВАНИЕ ===")
    from sklearn.metrics import classification_report, confusion_matrix
    
    y_pred = model.predict(X_test, verbose=0)
    y_pred_classes = np.argmax(y_pred, axis=1)
    y_true_classes = np.argmax(y_test, axis=1)
    
    print("\nClassification Report:")
    print(classification_report(y_true_classes, y_pred_classes, 
                                target_names=['Круг', 'Треугольник', 'Квадрат']))
    
    print("\nConfusion Matrix:")
    cm = confusion_matrix(y_true_classes, y_pred_classes)
    print(cm)
    
    # Тест на конкретном примере квадрата-контура
    print("\n=== ТЕСТ НА КВАДРАТЕ-КОНТУРЕ (как на твоей картинке) ===")
    test_square = generate_shape_image('square', 'outline')
    pred = model.predict(test_square.reshape(1, -1), verbose=0)
    result = ['Круг', 'Треугольник', 'Квадрат'][np.argmax(pred)]
    print(f"Квадрат-контур распознан как: {result}")
    print(f"Вероятности: Круг={pred[0][0]*100:.1f}%, Треугольник={pred[0][1]*100:.1f}%, Квадрат={pred[0][2]*100:.1f}%")
    
    # Сохраняем примеры для проверки
    os.makedirs('test_samples', exist_ok=True)
    for shape in ['square', 'triangle', 'circle']:
        for variant in ['outline', 'filled']:
            img_array = generate_shape_image(shape, variant)
            img_reshaped = (img_array.reshape(20, 20) * 255).astype(np.uint8)
            img_pil = Image.fromarray(img_reshaped)
            img_pil.save(f'test_samples/{shape}_{variant}.png')
    print("\nПримеры сохранены в папку 'test_samples'")

if __name__ == '__main__':
    train()