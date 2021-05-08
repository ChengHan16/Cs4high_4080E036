# 延續 [Homework 1](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/Homework/Homework1/Code.md)

> ### `conda create --name websitework1 python=3.8` <br>
> ### `conda activate websitework1` <br>
> ### `pip install flask_wtf` <br>
> ### `pip install email_validator`
---
# ● CODE
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
## ● `main.css`
```css
body {
    background: #fafafa;
    color: #333333;
    margin-top: 5rem;
  }
  
  h1, h2, h3, h4, h5, h6 {
    color: #444444;
  }
  
  .bg-steel {
    background-color: #5f788a;
  }
  
  .site-header .navbar-nav .nav-link {
    color: #cbd5db;
  }
  
  .site-header .navbar-nav .nav-link:hover {
    color: #ffffff;
  }
  
  .site-header .navbar-nav .nav-link.active {
    font-weight: 500;
  }
  
  .content-section {
    background: #ffffff;
    padding: 10px 20px;
    border: 1px solid #dddddd;
    border-radius: 3px;
    margin-bottom: 20px;
  }
  
  .article-title {
    color: #444444;
  }
  
  a.article-title:hover {
    color: #428bca;
    text-decoration: none;
  }
  
  .article-content {
    white-space: pre-line;
  }
  
  .article-img {
    height: 65px;
    width: 65px;
    margin-right: 16px;
  }
  
  .article-metadata {
    padding-bottom: 1px;
    margin-bottom: 4px;
    border-bottom: 1px solid #e3e3e3
  }
  
  .article-metadata a:hover {
    color: #333;
    text-decoration: none;
  }
  
  .article-svg {
    width: 25px;
    height: 25px;
    vertical-align: middle;
  }
  
  .account-img {
    height: 125px;
    width: 125px;
    margin-right: 20px;
    margin-bottom: 16px;
  }
  
  .account-heading {
    font-size: 2.5rem;
  }
```
## ● `home.html`
```html
{% extends "layout.html" %}
{% block content %}
      {% for post in posts %}
            <h1>{{ post.title }}</h1>
            <p>By {{ post.author }} on {{ post.date_posted }}</p>
            <p>{{ post.content }}</p>
      {% endfor %}
{% endblock content %}
```
## ● `about.html`
```html
{% extends "layout.html" %}
{% block content %}
  <h1>About Page</h1>
{% endblock content %}
```
## ● `layout.html`
```html
<!DOCTYPE html>
<html>
  <head>
     <!-- Required meta tags -->
     <meta charset="utf-8">
     <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
 
     <!-- Bootstrap CSS -->
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

     <link rel="stylesheet" type="text/css" href="{{ url_for('static',filename='main.css') }}">

    {% if title %}
          <title>Flask Blog - {{ title }}</title>
    {% else %}
          <title>Flask Blog</title>
    {% endif %}
  </head>
  
  <body>
    <header class="site-header">
        <nav class="navbar navbar-expand-md navbar-dark bg-steel fixed-top">
          <div class="container">
            <a class="navbar-brand mr-4" href="/">Flask Blog</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggle" aria-controls="navbarToggle" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarToggle">
              <div class="navbar-nav mr-auto">
                <a class="nav-item nav-link" href="/">Home</a>
                <a class="nav-item nav-link" href="/about">About</a>
              </div>
              <!-- Navbar Right Side -->
              <div class="navbar-nav">
                <a class="nav-item nav-link" href="/login">Login</a>
                <a class="nav-item nav-link" href="/register">Register</a>
              </div>
            </div>
          </div>
        </nav>
      </header>
      <main role="main" class="container">
        <div class="row">
          <div class="col-md-8">
            {% with messages = get_flashed_messages(with_categories=true) %}
              {% if messages %}
                {% for category, message in messages %}
                  <div class="alert alert-{{ category }}">
                    {{ message }}
                  </div>
                {% endfor %}
              {% endif %}
            {% endwith %}
            {% block content %}{% endblock %}
          </div>
          <div class="col-md-4">
            <div class="content-section">
              <h3>Our Sidebar</h3>
              <p class='text-muted'>You can put any information here you'd like.
                <ul class="list-group">
                  <li class="list-group-item list-group-item-light">Latest Posts</li>
                  <li class="list-group-item list-group-item-light">Announcements</li>
                  <li class="list-group-item list-group-item-light">Calendars</li>
                  <li class="list-group-item list-group-item-light">etc</li>
                </ul>
              </p>
            </div>
          </div>
        </div>
      </main>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
  </body>
</html>
```
## ● `login.html`
```html
{% extends "layout.html" %}
{% block content %}
  <div class="content-section">
      <form method="POST" action="">
            {{ form.hidden_tag() }}
            <fieldset class="form-group">
                <legend class="border-bottom mb-4">Log In</legend>
                <div class="form-group">
                    {{ form.email.label(class="form-control-label") }}
                    {% if form.email.errors %}
                        {{ form.email(class="form-control form-control-lg is-invalid") }}
                        <div class="invalid-feedback">
                            {% for error in form.email.errors %}
                                <span>{{ error }}</span>
                            {% endfor %}
                        </div>
                    {% else %}
                        {{ form.email(class="form-control form-control-lg") }}
                    {% endif %}
                </div>
                <div class="form-group">
                    {{ form.password.label(class="form-control-label") }}
                    {% if form.password.errors %}
                        {{ form.password(class="form-control form-control-lg is-invalid") }}
                        <div class="invalid-feedback">
                            {% for error in form.password.errors %}
                                <span>{{ error }}</span>
                            {% endfor %}
                        </div>
                    {% else %}
                        {{ form.password(class="form-control form-control-lg") }}
                    {% endif %}
                </div>
                <div class="form-check">
                    {{ form.remember(class="form-check-input") }}
                    {{ form.remember.label(class="form-check-label") }}
                </div>

            </fieldset>
            <div class="form-group">
                {{ form.submit(class="btn-outline-inof") }}
            </div>
            <small class="text-muted ml-2">
                <a href="#">Forgot Password?</a>
            </small>
      </form>
  </div>
  <div class="borfer-top pt-3">
      <small class="text-muted">
          Need Have An Acconut? <a class="ml-2" href="{{ url_for('register') }}">Sing Up Now</a>
      </small>

  </div>
{% endblock content %}
```
## ● `register.html`
```html
{% extends "layout.html" %}
{% block content %}
  <div class="content-section">
      <form method="POST" action="">
            {{ form.hidden_tag() }}
            <fieldset class="form-group">
                <legend class="border-bottom mb-4">Join Today</legend>
                <div class="form-group">
                    {{ form.username.label(class="form-control-label") }}

                    {% if form.username.errors %}
                        {{ form.username(class="form-control form-control-lg is-invalid") }}
                        <div class="invalid-feedback">
                            {% for error in form.username.errors %}
                                <span>{{ error }}</span>
                            {% endfor %}
                        </div>
                    {% else %}
                        {{ form.username(class="form-control form-control-lg") }}
                    {% endif %}
                </div>
                <div class="form-group">
                    {{ form.email.label(class="form-control-label") }}
                    {% if form.email.errors %}
                        {{ form.email(class="form-control form-control-lg is-invalid") }}
                        <div class="invalid-feedback">
                            {% for error in form.email.errors %}
                                <span>{{ error }}</span>
                            {% endfor %}
                        </div>
                    {% else %}
                        {{ form.email(class="form-control form-control-lg") }}
                    {% endif %}
                </div>
                <div class="form-group">
                    {{ form.password.label(class="form-control-label") }}
                    {% if form.password.errors %}
                        {{ form.password(class="form-control form-control-lg is-invalid") }}
                        <div class="invalid-feedback">
                            {% for error in form.password.errors %}
                                <span>{{ error }}</span>
                            {% endfor %}
                        </div>
                    {% else %}
                        {{ form.password(class="form-control form-control-lg") }}
                    {% endif %}
                </div>
                <div class="form-group">
                    {{ form.confirm_password.label(class="form-control-label") }}
                    {% if form.confirm_password.errors %}
                        {{ form.confirm_password(class="form-control form-control-lg is-invalid") }}
                        <div class="invalid-feedback">
                            {% for error in form.confirm_password.errors %}
                                <span>{{ error }}</span>
                            {% endfor %}
                        </div>
                    {% else %}
                        {{ form.confirm_password(class="form-control form-control-lg") }}
                    {% endif %}
                </div>
            </fieldset>
            <div class="form-group">
                {{ form.submit(class="btn-outline-inof") }}
            </div>
      </form>
  </div>
  <div class="borfer-top pt-3">
      <small class="text-muted">
          Already Have An Acconut? <a class="ml-2" href="{{ url_for('login') }}">Sing In</a>
      </small>

  </div>
{% endblock content %}
```
# ● Results(執行結果)
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
