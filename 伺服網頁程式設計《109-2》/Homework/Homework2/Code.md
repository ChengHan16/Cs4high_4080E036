# 延續 [Homework 1](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/Homework/Homework1/Code.md)

> ### `conda create --name websitework1 python=3.8` <br>
> ### `conda activate websitework1` <br>
> ### `pip install flask_wtf` <br>
> ### `pip install email_validator`
---
## ● `app.py`
```python
from flask import Flask, render_template, url_for, flash , redirect
from forms import RegistrationForm, LoginForm
app = Flask(__name__)

app.config['SECRET_KEY'] = '282ad271f375ee87b6339b08353f847b'

posts = [
    {
        'author': 'Jane Doe',
        'title': 'Blog Post 1',
        'content': 'Second post content',
        'date_posted': 'April 21, 2018'
    },
     {
        'author': 'Jane Doe',
        'title': 'Blog Post 2',
        'content': 'Second post content',
        'date_posted': 'April 21, 2018'
    }
]

@app.route("/")
@app.route("/home")
def home():
    return render_template('home.html',posts=posts)

@app.route("/about")
def about():
    return render_template('about.html')

@app.route("/register", methods=['GET','POST'])
def register():
    form = RegistrationForm()
    if form.validate_on_submit():
        flash(f'Account created for {form.username.data}!', 'success')
        return redirect(url_for('home'))
    return render_template('register.html',titile='Register',form=form)

@app.route("/login", methods=['GET','POST'])
def login():
    form = LoginForm()
    if form.validate_on_submit():
        if form.email.data == 'admin@blog.com' and form.password.data == 'password':
            flash('You have been logged in!','success')
            return redirect(url_for('home'))
        else:
            flash('Login Unsuccessful. Please check username and passeord','danger')
    return render_template('login.html',titile='Login',form=form)

if __name__ == '__main__':
    app.run(debug=True)
```
## ● `forms.py`
```python
from flask_wtf import FlaskForm
from wtforms import StringField,PasswordField, SubmitField, BooleanField
from wtforms.validators import DataRequired , Length , Email , EqualTo 

class RegistrationForm(FlaskForm): # 創建 class RegistrationForm(FlaskForm) <--括號內是繼承 'FlaskForm' 
    username = StringField('Username',validators=[DataRequired(),Length(min=2,max=20)])

    email = StringField('Email',validators=[DataRequired(),Email()]) # StringField : 類似Textbox ,DataRequired()：代表此欄位需要有資料

    password = PasswordField('Password', validators=[DataRequired()])
    confirm_password = PasswordField('Confirm Password', validators=[DataRequired(), EqualTo('password')])

    submit = SubmitField('Sign Up')

class LoginForm(FlaskForm):
    email = StringField('Email',validators=[DataRequired(),Email()])
    password = PasswordField('Password', validators=[DataRequired()])
    remember = BooleanField('Remember Me')
    submit = SubmitField('Login')
```
# Results(執行結果)
![WebHomework(1)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(1).PNG)
![WebHomework(2)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(2).PNG)
![WebHomework(3)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(3).PNG)
![WebHomework(4)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(4).PNG)
![WebHomework(5)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(5).PNG)
![WebHomework(6)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(6).PNG)
![WebHomework(7)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(7).PNG)
![WebHomework(8)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(8).PNG)
![WebHomework(9)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(9).PNG)
![WebHomework(10)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(10).PNG)
![WebHomework(11)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/Homework%202/Image/WebHomework(11).PNG)
----
# ✰ 執行步驟：
> ### `set FLASK_APP=app.py`
> ### `flask run`
> ### 重新使用時 `ctrl + C`
> ### 瀏覽器 `ctrl + shift + R `
---
# Error
### Method Not Allowed The method is not allowed for the requested URL (參考資料 23:25
> `https://stackoverflow.com/questions/39289746/method-not-allowed-the-method-is-not-allowed-for-the-requested-url`
> `https://stackoverflow.com/questions/20689195/flask-error-method-not-allowed-the-method-is-not-allowed-for-the-requested-url/20689328`
---
# 參考資料
### Python Flask Tutorial: Full-Featured Web App Part 2 - Templates
> `https://www.youtube.com/watch?v=MwZwr5Tvyxo&list=RDCMUCCezIgC97PvUuR4_gbFUs5g`
