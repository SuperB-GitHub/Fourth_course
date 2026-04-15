from datetime import datetime, timezone
import base64
from sqlalchemy import Column, Integer, String, Float, Text, DateTime
from database.database import Base

class Predictions(Base):
    __tablename__ = 'Predictions'

    id = Column(Integer, primary_key=True)
    filename = Column(String(255), nullable=True)
    image_data = Column(Text, nullable=False)
    predicted_class = Column(String(50), nullable=False)
    confidence = Column(Float, nullable=False)
    probabilities_circle = Column(Float, nullable=True)
    probabilities_square = Column(Float, nullable=True)
    probabilities_triangle = Column(Float, nullable=True)
    created_at = Column(DateTime, default=lambda: datetime.now(timezone.utc))

    def __init__(self, filename, image_data, predicted_class, confidence, 
                 probabilities_circle, probabilities_square, probabilities_triangle):
        self.filename = filename
        self.image_data = image_data
        self.predicted_class = predicted_class
        self.confidence = confidence
        self.probabilities_circle = probabilities_circle
        self.probabilities_square = probabilities_square
        self.probabilities_triangle = probabilities_triangle

    def __repr__(self):
        return (f"<Prediction(id={self.id}, filename='{self.filename}', "
                f"class='{self.predicted_class}', confidence={self.confidence:.2%})>")

    @staticmethod
    def image_to_base64(image_bytes):
        return base64.b64encode(image_bytes).decode('utf-8')

    @staticmethod
    def base64_to_image(base64_str):
        return base64.b64decode(base64_str.encode('utf-8'))