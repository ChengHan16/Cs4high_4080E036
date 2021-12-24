## Uploading Files to a Database in Flask
> https://www.youtube.com/watch?v=TLgVEBuQURA
### ~ 3:25
---
app.py
```py
#from logging import debug
from flask import Flask,render_template,  request
#from werkzeug.wrappers import request

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/upload', methods=['POST'])
def upload():
    file = request.files['inputFile']

    return file.filename

if __name__ == '__main__':
    app.run(debug=True)
```
index.html
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

    <body>  
        <h2>Upload file to flask database 12/24</h2>
        <h2>4080E036 吳承翰</h2>
        <div class="container">
            <h2>File Input</h2>
            <form method="POST" action="/upload" enctype="multipart/form-data">
            <div class="form-group">
                <label for="inputFile">File input</label>
                <input type="file" name="inputFile">
            </div>
            <button type="submit" class="btn btn-default">submit</button>
            </form>
        </div>
    
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrap.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    </body>
</html>
```
