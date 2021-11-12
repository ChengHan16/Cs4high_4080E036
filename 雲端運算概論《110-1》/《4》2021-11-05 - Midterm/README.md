## 開始安裝套件 (順序篇)
> ### 1. 安裝虛擬環境軟體 pip3 install virtualenv
> ### 2. 建立虛擬環境 virtualenv venv_midterm_project_1112
> ### 3. 開啟虛擬環境 .\venv_midterm_project_1112\Scripts\activate
> ### 4. 在虛擬環境以下安裝套件
>> ### pip install Flask  (Flask套件)
>> ### pip3 install pandas
>> ### pip3 install scikit-learn
---
## 資料夾配置 D：槽
> static
>> css  
>>> style.css
> templates
>> home
>> result
> venv_midterm_flask (此為虛擬環境自動生成)
> app.py
> YoutubeSpamMergedData.csv
---
## Code
### app.py
``` py 
from flask import Flask,render_template,url_for,request
import pandas as pd #常用於讀取檔案
# pip3 install pandas
import pickle
from sklearn.feature_extraction.text import CountVectorizer
# pip3 install scikit-learn
from sklearn.naive_bayes import MultinomialNB
#from sklearn.externals import joblib

app = Flask(__name__)

@app.route('/')
def home():
    return render_template('home.html')

@app.route('/predict',methods=['POST'])
def predict():
    df= pd.read_csv("YoutubeSpamMergedData.csv")
    df_data = df[["CONTENT","CLASS"]]
    # Features and Labels
    df_x = df_data['CONTENT']
    df_y = df_data.CLASS
    # Extract Feature With CountVectorizer
    corpus = df_x
    cv = CountVectorizer()
    X = cv.fit_transform(corpus) # Fit the Data
    from sklearn.model_selection import train_test_split
    X_train, X_test, y_train, y_test = train_test_split(X, df_y, test_size=0.33, random_state=42)
    #Naive Bayes Classifier
    from sklearn.naive_bayes import MultinomialNB
    clf = MultinomialNB()
    clf.fit(X_train,y_train)
    clf.score(X_test,y_test)
    #Alternative Usage of Saved Model
    # ytb_model = open("naivebayes_spam_model.pkl","rb")
    # clf = joblib.load(ytb_model)
 
    if request.method == 'POST':
        comment = request.form['comment']
        data = [comment]
        vect = cv.transform(data).toarray()
        my_prediction = clf.predict(vect)
    return render_template('result.html',prediction = my_prediction)
 
if __name__ == '__main__':
    app.run(debug=True)
```
### style.css
```css
body{
	font:15px/1.5 Arial, Helvetica,sans-serif;
	padding: 0px;
	background-color:#f4f3f3;
}

.container{
	width:100%;
	margin: auto;
	overflow: hidden;
}

header{
	background:#03A9F4;
	border-bottom:#448AFF 3px solid;
	height:120px;
	width:100%;
	padding-top:30px;

}

.main-header{
			text-align:center;
			background-color: blue;
			height:100px;
			width:100%;
			margin:0px;
		}
#brandname{
	float:left;
	font-size:30px;
	color: #fff;
	margin: 10px;
}

header h2{
	text-align:center;
	color:#fff;

}

.btn-info {background-color: #2196F3;
	height:40px;
	width:100px;} /* Blue */
.btn-info:hover {background: #0b7dda;}


.resultss{
	border-radius: 15px 50px;
    background: #345fe4;
    padding: 20px; 
    width: 200px;
    height: 150px;
}
```
### home.html
```html
<!DOCTYPE html>
<html>
<head>
	<title>Home</title>
	<!-- <link rel="stylesheet" type="text/css" href="../static/css/styles.css"> -->
	<link rel="stylesheet" type="text/css" href="{{ url_for('static', filename='css/styles.css') }}">
</head>
<body>

	<header>
		<div class="container">
		<div id="brandname">
			ML App
		</div>
		<h2>Spam Detection For Youtube Comments</h2>
		
	</div>
	</header>

	<div class="ml-container">

		<form action="{{ url_for('predict')}}" method="POST">
			<p>Enter Your Comment Here</p>
			<!-- <input type="text" name="comment"/> -->
			<textarea name="comment" rows="4" cols="50"></textarea>
			<br/>

			<input type="submit" class="btn-info" value="predict">
			
	</form>
		
	</div>
</body>
</html>
```
result.html
```html
<!DOCTYPE html>
<html>
	<head>
	<title></title>
    <link rel="stylesheet" type="text/css" href="{{ url_for('static', filename='css/styles.css') }}">
</head>
<body>

	<header>
		<div class="container">
		<div id="brandname">
			ML App
		</div>
		<h2>Spam Detection For Youtube Comments</h2>
		
	</div>
	</header>
	<p style="color:blue;font-size:20;text-align: center;"><b>Results for Comment</b></p>
	<div class="results">
	{% if prediction == 1%}
	<h2 style="color:red;">Spam</h2>
	{% elif prediction == 0%}
	<h2 style="color:blue;">Not a Spam (It is a Ham)</h2>
	{% endif %}
	</div>

	</body>
</html>
```
