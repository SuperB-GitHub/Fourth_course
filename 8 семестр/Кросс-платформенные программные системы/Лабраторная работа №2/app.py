from flask import Flask, render_template
from model import nn

app = Flask(__name__)

model = nn.get_model()

@app.route('/', methods=['GET'])
def index():
    return render_template('index.html')

if __name__ == '__main__':
    app.run(debug=False)