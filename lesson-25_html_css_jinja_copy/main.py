from flask import Flask, render_template
from auth import LoginForm # импорт класса LoginForm из auth.py

app = Flask(__name__) 
app.config['SECRET_KEY'] = 'world world world hello' # csrf-атаки


@app.route('/', methods=['GET', 'POST'])
def main():
    form = LoginForm() # создать форму на гл. странице "/"
    if form.validate_on_submit():
        name = form.name.data
        surname = form.surname.data
        email = form.email.data
        print(name, surname, email)
        return render_template('base.html', title='Главная страница',
                            form=form, message='Вы авторизовались!')
    return render_template('base.html', title='Главная страница',
                            form=form)


if __name__ == '__main__':
    app.run()