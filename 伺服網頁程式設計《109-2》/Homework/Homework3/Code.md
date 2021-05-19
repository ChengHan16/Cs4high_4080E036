# ● Code
## `app.py`
```python
from datetime import datetime
from flask import Flask, render_template, url_for, flash , redirect
from flask_sqlalchemy import SQLAlchemy
from forms import RegistrationForm, LoginForm

app = Flask(__name__)
app.config['SECRET_KEY'] = 'e71d69acddf49d621f51c7727d1ac048' # python>>> import secrets>>> secrets.token_hex(16)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///site.db'
db = SQLAlchemy(app)

class User(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(20),unique=True,nullable=False)
    email = db.Column(db.String(120),unique=True,nullable=False)
    image_file = db.Column(db.String(20),nullable=False,default = 'default.jpg')
    password = db.Column(db.String(60), nullable = False)
    posts = db.relationship('Post',backref = 'author', lazy=True)

    def __repr__(self):
        return f"User('{self.username}','{self.email}','{self.image_file}')"

class Post(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    title = db.Column(db.String(100),nullable=False)
    date_posted = db.Column(db.DateTime,nullable = False, default = datetime.utcnow)
    content = db.Column(db.Text, nullable=False)
    user_id = db.Column(db.Integer, db.ForeignKey('user.id'), nullable=False)

    def __repr__(self):
        return f"Post('{self.title}','{self.date_posted}')"

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
## `forms.py`
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
# ● 資料庫操作
## ● 建立資料
### Python Flask Tutorial: Full-Featured Web App Part 4 (17:30
```
>>> PS D:\MyFlask2021\4080E036\flaskTest01> python
>>> from app import db
>>> db.create_all()
>>> from app import User, Post
>>> >>> user_1 = User(username='4080E036',email='E036@demo.com',password='password')
>>> db.session.add(user_1)
>>> user_2 = User(username='4080E001',email='E001@demo.com',password='password')
>>> db.session.add(user_2)
>>> db.session.commit()
```
### ⚠ [from `app` import db <<-- 這個 app 是使用者的 python 執行檔 Ex.app.py]()
---
## ● 顯示用戶資料
### Python Flask Tutorial: Full-Featured Web App Part 4 (21:36
```
>>> User.query.all()                                    <<--顯示所有註冊資訊
[User('4080E036','E036@demo.com','default.jpg'), User('4080E001','E001@demo.com','default.jpg')]
>>> User.query.first()                                  <<--搜尋第一個
User('4080E036','E036@demo.com','default.jpg')

>>> User.query.filter_by(username='4080E001').all()     <<--搜尋篩選為4080E001帳戶資訊
[User('4080E001','E001@demo.com','default.jpg')]
>>> User.query.filter_by(username='4080E001').first()
User('4080E001','E001@demo.com','default.jpg')

>>> user = User.query.filter_by(username='4080E001').first()   <<--搜尋篩選為4080E001帳戶資訊，在變量中篩選其他資訊
>>> user
User('4080E001','E001@demo.com','default.jpg')          
>>> user.id                                            <<--查詢該user用戶的id
2
>>> user = User.query.get(1)                           <<--get出該id資訊
User('4080E036','E036@demo.com','default.jpg')          
>>> user = User.query.get(2)
>>> user
User('4080E001','E001@demo.com','default.jpg')
>>> user.posts                                         <<--查詢有幾則帖文
[]                                                     <<--回傳帖文數量,目前無,所以為空
```
## ● 建立帖文&查詢
### Python Flask Tutorial: Full-Featured Web App Part 4 (24:37
```
>>> user = User.query.filter_by(username='4080E036').first()              
>>> user
User('4080E036','E036@demo.com','default.jpg')
>>> user.id
1
>>> post_1 = Post(title='Blog 1',content='First Post Content!', user_id=user.id)      <<--建立帖文1(資訊
>>> post_2 = Post(title='Blog 2',content='Second Post Content!', user_id=user.id)     <<--建立帖文2(資訊
>>> db.session.add(post_1)      <<--add         
>>> db.session.add(post_2)      <<--add
>>> db.session.commit()         

>>> user.posts                  <<--查詢user的posts
[Post('Blog 1','2021-05-12 02:59:25.395123'), Post('Blog 2','2021-05-12 02:59:25.397123')] <<--顯示user post資訊
>>> for post in user.posts:     
...  print(post.title)          <<--列印出post
...
Blog 1                          <<--顯示結果
Blog 2

>>> post = Post.query.first()   <<--查詢第一個建立的post
>>>
>>> post
Post('Blog 1','2021-05-12 02:59:25.395123') <<--顯示結果

>>> post.user_id        <<--查詢該post的id(順序
1
>>> post.author         <<--post的帳戶資訊
User('4080E036','E036@demo.com','default.jpg')
```
## ● 刪除資料庫
### Python Flask Tutorial: Full-Featured Web App Part 4 (28:20
```
>>> db.drop_all()     <<--刪除資料庫
>>> db.create_all()   <<--創建表格
>>> User.query.all()  <<--查詢所有User資訊
[]
>>> Post.query.all()  <<--查詢所有Post資訊
[]
```
---
# ✰ Results(執行結果)
![0512伺服網頁](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/file/image/0512%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81.PNG)

---
# ✰ 執行步驟：
> ### `set FLASK_APP=app.py`
> ### `flask run`
> ### 重新使用時 `ctrl + C`
> ### 瀏覽器 `ctrl + shift + R `
---
# 參考資料
### Python Flask Tutorial: Full-Featured Web App Part 4 - Database with Flask-SQLAlchemy
> `https://www.youtube.com/watch?v=cYWiDiIUxQc&list=RDCMUCCezIgC97PvUuR4_gbFUs5g&index=2`
#### How to clear the interpreter console?
> `https://stackoverflow.com/questions/517970/how-to-clear-the-interpreter-console`
