# Midterm exam.md
```python
from flask import Flask, session, redirect, url_for, request, render_template
from markupsafe import escape
 
app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/ksu')
def ksu():
    return render_template('ksu.html')
 
@app.route("/ksu1", methods=['POST']) 
def move_forward1(): 
    #Moving forward code 
    forward_message = "Forward to ..." 
    return redirect('https://en.wikipedia.org/wiki/Taiwan_Miracle');
 
@app.route("/ksu2", methods=['POST']) 
def move_forward2(): 
    #Moving forward code 
    forward_message = "Forward to ..." 
    return redirect('https://www.ecoflex-experience.com/the-right-solution-to-sightsee-in-japan/')
 
@app.route("/ksu3", methods=['POST']) 
def move_forward3(): 
    #Moving forward code 
    forward_message = "Forward to ..." 
    return redirect('https://hubpages.com/travel/Exploring-the-City-of-Korean-Drama-A-Travel-in-South-Korea')

if __name__=="__main__": #如果以主程式執行
    app.run() #立刻啟動伺服器
```

```html
<!doctype html>
<html>
  <head>
    <title>崑山科技大學10902伺服網頁程式設計期中考</title> 
    <link rel="stylesheet" type="text/css" href="{{url_for('static', filename='style.css')}}">
   
  </head>
  <body>
 
    <img style="width: 20%" src="{{url_for('static', filename='ksu1.png')}}" class="left"/><a href="http://elearning2.ksu.edu.tw/" target='_blank'><h1>點擊 View More 了解更多</h1></a>
    
    
 
    <div class="container">
 
      <div class="card">
        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Taipei_Skyline_2020.jpg/1200px-Taipei_Skyline_2020.jpg" alt="">
        <div class="info">
          <form action="/ksu1" method="post"> 
            <button name="forwardBtn1" type="submit">View More</button> 
          </form>
          <p>Kun Shan University</p>
        </div>
      </div>
 
      <div class="card">
        <img src="https://www.budgetdirect.com.au/blog/wp-content/uploads/2018/03/Japan-Travel-Guide.jpg" alt="">
        <div class="info">
          <form action="/ksu2" method="post"> 
            <button name="forwardBtn2" type="submit">View More</button> 
          </form>
          <p>Kun Shan University</p>
        </div>
      </div>
      
      <div class="card">
        <img src="https://usercontent2.hubstatic.com/15155427_f496.jpg" alt="">
        <div class="info">
          <form action="/ksu3" method="post"> 
            <button name="forwardBtn3" type="submit">View More</button> 
          </form>
          <p>Kun Shan University</p>
        </div>
      </div>
    </div>
  </body>
</html>
```

```css
body{
    background: url(http://insightreport.debeersgroup.com/_images/backgrounds/global-consumer-demand-bg.jpg);
  }
  .container{
    width: 900px;
    margin: 0 auto;
  }
  .card{
    /* 設定父親定位點 */
    position: relative;
    width: 270px;
    float:left;
    margin: 10px;
  }
  img{
    display: block;
    width: 100%;
    height: auto;
  }
  img01{
    display: block;
    width: 30%;
    height: auto;
  }
  .info{
  /*   display: none; */
    opacity: 0;
    position: absolute;
    box-sizing: border-box;
    background-color: rgba(0,0,0,.3);
    top: 0;
    width: 100%;
    height: 100%;
    text-align: center;
    padding-top: 40px;
  }
  .info p{
    color: #fff;
  }
  .info:hover{
    -webkit-transition: 500ms;
    opacity: 1;
  }
```
