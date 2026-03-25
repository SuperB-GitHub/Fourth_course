from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense
from tensorflow.keras.optimizers import Adam
import os

_model = None

def create_model():
    
    model = Sequential()
    
    model.add(Dense(100, activation='relu',))

    model.add(Dense(3, activation='softmax'))

    model.build(input_shape=(None, 400))

    model.compile(optimizer=Adam(learning_rate=0.001),
                  loss='categorical_crossentropy',
                  metrics=['accuracy', 'mse', 'mae'])
    
    print(f"Модель построена: {model.built}")

    cur_dir = os.path.dirname(os.path.abspath(__file__))
    w_path = os.path.join(cur_dir, 'best.weights.h5')

    try:
        model.load_weights(w_path)
        print(f"Веса успешно загружены")
    except Exception as e:
        print(f"Ошибка при загрузке весов: {e}")
    

    return model


def get_model():
    global _model
    if _model is None:
        _model = create_model()
