from flask import Flask,render_template,url_for,request
import pandas as pd 
# pip3 install pandas
import pickle
from sklearn.feature_extraction.text import CountVectorizer
# pip3 install scikit-learn
from sklearn.naive_bayes import MultinomialNB
from sklearn.externals import joblib

app = Flask(__name__)

@app.route('/')
def home():
    return render_template('home.html')

@app.route('/predict')
def predict():
    df= pd.read_csv("YoutubeSpamMergedData.csv")
    df_data = df[["CONTENT","CLASS"]]
    # Features and Labels
    df_x = df_data['CONTENT']
    df_y = df_data.CLASS
    # Extract Feature With CountVectorizer
    corpus = df_x
    cv = CountVectorizer()
    return render_template('result.html')

if __name__ == '__main__':
    app.run(debug=True)
