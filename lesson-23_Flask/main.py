print(1) # Console.WriteLine(1)
from flask import Flask # вытащил объект.

app = Flask(__name__)

@app.route('/')
def main():
    return 'Hello World!'

app.run(port=8080)