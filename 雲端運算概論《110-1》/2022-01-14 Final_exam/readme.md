# 2022-01-14 雲端運算概論 Final

###  ⚠ 安裝 Python 3.9.6 (記得勾選安裝的首頁最下面的 Add Python 3.9 to PATH)
> ###  PowerShell ISE
>> 1. get-executionpolicy (會回傳 Restricted
>> 2. set-executionpolicy remotesigned
>> 3. set-executionpolicy -Scope CurrentUser remotesigned
>> 4. get-executionpolicy (會回傳 RemoteSigned
> ### PowerShell Complete 
---
> ### pip install
>> 1. 安裝虛擬環境軟體 pip3 install virtualenv  
>> 2. 建立虛擬環境 virtualenv FinalExam_on_FlaskDB
>> 3. 開啟虛擬環境 .\FinalExam_on_FlaskDB\Scripts\activate
>> 4. 在虛擬環境下安裝flask套件 pip3 install flask
> ### pip install Complete
---
### app.py
```py
#from logging import debug
#from werkzeug.wrappers import request
from os import name
from flask import Flask,render_template,  request
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///site.db'
db = SQLAlchemy(app)

class FileContents(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(300))
    data = db.Column(db.LargeBinary)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/upload', methods=['POST'])
def upload():
    file = request.files['inputFile']

    newFile = FileContents(name=file.filename, data=file.read())
    db.session.add(newFile)
    db.session.commit()

    return 'Saved' + file.filename + 'to the database!'

if __name__ == '__main__':
    app.run(debug=True)
```
### index.html
```html
<!DOCTYPE html>
<html lang='en'>
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-with, initial-scale=1">
        <title>File Input Example</title>

        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.main.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg320mUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    </head>

    <style>
        body{
                background: rgb(122,188,255); 
                background: -moz-linear-gradient(top,  rgba(122,188,255,1) 0%, rgba(96,171,248,1) 44%, rgba(64,150,238,1) 2000%);
                filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#7abcff', endColorstr='#4096ee',GradientType=0 ); 
            }

    h2{
        text-align:center;
        font-family:"Microsoft JhengHei"
    }

    button{
        font-size:25px;
        border:0;
        background-color:#003C9D;
        color:#fff;border-radius:10px;
    }

    .container{
        display: flex;
        justify-content: center; 
        align-items: center; 
    }

    .file {
    position: relative;
    display: inline-block;
    background: #D0EEFF;
    border: 1px solid #99D3F5;
    border-radius: 4px;
    padding: 4px 12px;
    overflow: hidden;
    color: #1E88C7;
    text-decoration: none;
    text-indent: 0;
    line-height: 20px;
    }
    .file input {
    position: absolute;
    font-size: 100px;
    right: 0;
    top: 0;
    opacity: 0;
    }
    .file:hover {
    background: #AADFFD;
    border-color: #78C3F3;
    color: #004974;
    text-decoration: none;
    }

    #popUpYes
    {
      width: 120px;
      height: 40px;
      background-color: #003C9D
      color= white; /* SET COLOR IN WHITE */
      display: inline-flex;
      justify-content: center; /* center the content horizontally */
      align-items: center; /* center the content vertically */
      --padding-x: 1.2em;
      border-color: transparent;
    }
    #popUpYes:hover
    {
      background-color: #C4E1FF;
      color: black; /* SET COLOR IN BLACK */
    } 

    </style>

    <body>  
        <h2>FinalExam_on_FlaskDB</h2>
        <h2>Upload file to flask database 01-14</h2>
        <h2>4080E036 吳承翰</h2>
        <hr>
        <br>
        <div class="container">
            <form  method="POST" action="/upload" enctype="multipart/form-data">
            <div class="form-group">
                <label style="font-size:20px; font-family:Microsoft JhengHei; font-weight:bold;" for="inputFile">File input</label>
                <input class="file" style="font-size:20px; font-family:Microsoft JhengHei; font-weight:bold;" type="file" name="inputFile">
                <button id="popUpYes" type="submit" class="btn btn-default">submit</button>
            </div>
            </form>
        </div>
    
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrap.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    </body>
</html>
```
### 建立 DB
```
>>> python
>>> from app import db
>>> db.create_all()
>>> exit()
```
###  jade sqlite chrome 安裝、使用
> jade sqlite chrome 選擇 Open 
![image](https://user-images.githubusercontent.com/55220866/149466543-a875a01b-5fd7-412a-8bb2-1083491ba08b.png)
> 選擇 DB
![image](https://user-images.githubusercontent.com/55220866/149466615-79051cee-850a-49a4-bf3d-53ece654e80f.png)
> Result
![image](https://user-images.githubusercontent.com/55220866/149466713-e9b99112-6deb-4cd6-a8a9-a4a6bc868cd2.png)
## Result
