
# `app.py`
```python
from flask import Flask, render_template
app = Flask(__name__)

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

if __name__ == '__main__':
    app.run(debug=True)
```
# `main.css`
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
# `home.html`
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
# `about.html`
```
{% extends "layout.html" %}
{% block content %}
  <h1>About Page</h1>
{% endblock content %}
```
# layout.html
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
# Results(執行結果)
![websitework1](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/websitework1.PNG)
![websitework2](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/websitework2.PNG)
___
# ノート
#### `conda create --name websitework1 python=3.8`
#### `conda activate websitework1`
