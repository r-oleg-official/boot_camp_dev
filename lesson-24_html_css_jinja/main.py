from flask import Flask, render_template


app = Flask(__name__)


@app.route('/')
def main():
    user_name = ['Aleksey', 'Alla', 'Almir', 'Diana', 'Ilali']
    return render_template('base.html', user_name=user_name,
                             title='Главная страница')


@app.route('/bootcamp')
def boot():
    return render_template('bootcamp.html', title='BootCamp-tasks')


if __name__ == '__main__':
    app.run()