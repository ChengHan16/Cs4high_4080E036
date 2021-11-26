# 2021-11-26 雲端運算概論
## 安裝步驟：
###  ⚠ 安裝 Python 3.9.6 (記得勾選安裝的首頁最下面的 Add Python 3.9 to PATH)
> ###  PowerShell
>> 1. get-executionpolicy
>> 2. set-executionpolicy remotesigned
>> 3. set-executionpolicy -Scope CurrentUser remotesigned
>> 4. get-executionpolicy 
> ### PowerShell Complete
---
> ### pip install
>> 1. 安裝虛擬環境軟體 pip3 install virtualenv  
>> 2. 建立虛擬環境 virtualenv venv_flask2021
>> 3. 開啟虛擬環境 .\venv_flask2021\Scripts\activate
>> 4. 在虛擬環境下安裝flask套件 pip3 install flask
> ### pip install Complete
---
---
## 所有套件：
> ### pip3 install virtualenv
> ### pip install Flask
> ### pip3 install pandas
> ### pip3 install scikit-learn
---
## Start
> ### 新增 ML_on_Flask_1126 資料夾 (D:\FLASK2021\ML_on_Flask_1126)
> ### 到 krishnaik06/Deployment-Deep-Learning-Model 下載 <br> ● Download ZIP
>> https://github.com/krishnaik06/Deployment-Deep-Learning-Model
![Download](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E9%9B%B2%E7%AB%AF%E9%81%8B%E7%AE%97%E6%A6%82%E8%AB%96%E3%80%8A110-1%E3%80%8B/%E3%80%8A6%E3%80%8B2021-11-26/Image/%E4%B8%8B%E8%BC%89%20Deployment-Deep-Learning-Model-master.PNG)
> ### 檔案放在 ML_on_Flask_1126 內解壓縮
> ### 環境選擇(資料夾)剛剛下載的 Deployment-Deep-Learning-Model-master 
> ### pip3 install numpy
> ### pip3 install keras
```py
from __future__ import division, print_function
# coding=utf-8
import sys
import os
import glob
import re
import numpy as np

# Keras
from keras.applications.imagenet_utils import preprocess_input, decode_predictions
from keras.models import load_model
from keras.preprocessing import image

# Flask utils
from flask import Flask, redirect, url_for, request, render_template
from werkzeug.utils import secure_filename
#from gevent.pywsgi import WSGIServer

# Define a flask app
app = Flask(__name__)

# Model saved with Keras model.save()
#MODEL_PATH = 'models/model_resnet.h5'

# Load your trained model
#model = load_model(MODEL_PATH)
#model._make_predict_function()          # Necessary
# print('Model loaded. Start serving...')

# You can also use pretrained model from Keras
# Check https://keras.io/applications/
from keras.applications.vgg16 import VGG16
model = VGG16(weights='imagenet')
#model.save('')
print('Model loaded. Check http://127.0.0.1:5000/')


def model_predict(img_path, model):
    img = image.load_img(img_path, target_size=(224, 224))

    # Preprocessing the image
    x = image.img_to_array(img)
    # x = np.true_divide(x, 255)
    x = np.expand_dims(x, axis=0)

    # Be careful how your trained model deals with the input
    # otherwise, it won't make correct prediction!
    x = preprocess_input(x, mode='caffe')

    preds = model.predict(x)
    return preds


@app.route('/', methods=['GET'])
def index():
    # Main page
    return render_template('index.html')


@app.route('/predict', methods=['GET', 'POST'])
def upload():
    if request.method == 'POST':
        # Get the file from post request
        f = request.files['file']

        # Save the file to ./uploads
        basepath = os.path.dirname(__file__)
        file_path = os.path.join(
            basepath, 'uploads', secure_filename(f.filename))
        f.save(file_path)

        # Make prediction
        preds = model_predict(file_path, model)

        # Process your result for human
        # pred_class = preds.argmax(axis=-1)            # Simple argmax
        pred_class = decode_predictions(preds, top=1)   # ImageNet Decode
        result = str(pred_class[0][0][1])               # Convert to string
        return result
    return None


if __name__ == '__main__':
    app.run(debug=True)
```
