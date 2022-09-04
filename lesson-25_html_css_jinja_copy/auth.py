from flask_wtf import FlaskForm
from wtforms import BootleanField, StringField, SubmitField
from wtforms.validators import DataRequired, Email

class LoginForm(FlaskForm):
    name = StringField('Имя', validators=[DataRequired()])
    surname = StringField('Фамилия', validators=[DataRequired()])
    email = StringField('почта', validators=[Email()])
    submit = SubmitField('Submit')