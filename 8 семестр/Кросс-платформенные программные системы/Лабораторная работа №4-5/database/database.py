from sqlalchemy import create_engine
from sqlalchemy.orm import scoped_session, sessionmaker
from sqlalchemy.ext.declarative import declarative_base

engine = create_engine('sqlite:///C:/Users/ForMi/OneDrive/Desktop/Fourth_course/8 семестр/Кросс-платформенные программные системы/Лабораторная работа №4-5/predict.db')
db_session = scoped_session(sessionmaker(autocommit=False, autoflush=False, bind=engine))
Base = declarative_base()
Base.query = db_session.query_property()

def init_db():
    from results import Predictions
    Base.metadata.create_all(bind=engine)