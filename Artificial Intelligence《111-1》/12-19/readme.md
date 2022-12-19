### 利用 tensorflow 影像分類模型 建立一個 flask網頁 tensorflow-image-classification-flask-deployment

### －建置虛擬環境：
> ###  PowerShell ISE
>> 1. get-executionpolicy (會回傳 Restricted
>> 2. set-executionpolicy remotesigned
>> 3. set-executionpolicy -Scope CurrentUser remotesigned
>> 4. get-executionpolicy (會回傳 RemoteSigned
> ### PowerShell Complete 
---
> ### pip install
>> 1. 安裝虛擬環境軟體 pip3 install virtualenv  
>> 2. 建立虛擬環境 virtualenv venv-All-Project
>> 3. 開啟虛擬環境 .\venv-All-Project\Scripts\activate
>> 4. 在虛擬環境下安裝專案所需套件 pip3 install "套件名稱"
> ### pip install Complete
---
> ### pip install
>> 1. pip install --upgrade pip
>> 2. pip install Flask
>> 3. pip install Pillow
>> 4. pip install tensorflow-hub
> ### pip install Complete

### 使用自己的模型在 Flask 做辨識

### 模型儲存要點 (加入 activation='softmax')

```py
num_classes = len(class_names)

model = tf.keras.Sequential([
  feature_extractor_layer,
  tf.keras.layers.Dense(num_classes, activation='softmax')
])

model.summary()
```
### 模型儲存名稱不要 .副檔名
```py
#————儲存模型到雲端資料夾————
import os
DATADIR = os.path.join(MOUNTPOINT, "MyDrive/TF_Models") #MyDrive_我的雲端, TF_Models_資料夾
saved_model_path = os.path.join(DATADIR,"fruit_model_1219") #cats_and_dogs.h5_模型名稱
model.save(saved_model_path)
```
### **模型放置位置(fruit_model_1219)**
![image](https://user-images.githubusercontent.com/55220866/208368088-8d7cb217-edd2-4369-911a-26d19080a760.png)

### **Result**
![image](https://user-images.githubusercontent.com/55220866/208367969-333faa6d-56b5-4d2b-b531-5baa1be21ae3.png)
```py
import os
os.environ['TF_ENABLE_ONEDNN_OPTS'] = '1'
import uuid
import flask
import urllib
import tensorflow as tf
from PIL import Image
import tensorflow_hub as hub
from tensorflow.keras.models import load_model
from flask import Flask , render_template  , request , send_file
from tensorflow.keras.preprocessing.image import load_img , img_to_array
 
app = Flask(__name__)
BASE_DIR = os.path.dirname(os.path.abspath(__file__))
 
model_path = os.path.join(BASE_DIR , 'fruit_model_1219')
model = tf.keras.models.load_model(model_path)
 
#model = hub.load((model_path))
#model = load_model(os.path.join(BASE_DIR , 'model.hdf5'))
 
ALLOWED_EXT = set(['jpg' , 'jpeg' , 'png' , 'jfif'])
def allowed_file(filename):
    return '.' in filename and \
           filename.rsplit('.', 1)[1] in ALLOWED_EXT
 
#classes = ['airplane' ,'automobile', 'bird' , 'cat' , 'deer' ,'dog' ,'frog', 'horse' ,'ship' ,'truck']
classes = ['Actinidia deliciosa', 'banana', 'lemon', 'orange', 'strawberry']
'''classes = ['Cherry', 'Coffee-plant' ,'Cucumber' ,'Fox_nut(Makhana)' ,'Lemon',
 'Olive-tree', 'Pearl_millet(bajra)' ,'Tobacco-plant', 'almond', 'banana',
 'cardamom', 'chilli', 'clove', 'coconut', 'cotton', 'gram', 'jowar', 'jute',
 'maize', 'mustard-oil', 'papaya', 'pineapple', 'rice' ,'soyabean', 'sugarcane',
 'sunflower' ,'tea', 'tomato' ,'vigna-radiati(Mung)', 'wheat']'''
 
def predict(filename , model):
    img = load_img(filename , target_size = (224 , 224))
    img = img_to_array(img)
    img = img.reshape(1 , 224 ,224 ,3)
 
    img = img.astype('float32')
    img = img/255.0
    result = model.predict(img)
    print("result***********************************")
    print(len(result))
    print(result)
 
    dict_result = {}
    for i in range(len(classes)):
        dict_result[result[0][i]] = classes[i]
 
    res = result[0]
    res.sort()
    res = res[::-1]
    prob = res[:3]
   
    prob_result = []
    class_result = []
 
    for i in range(3):
        prob_result.append((prob[i]*30).round(2))
        #print("prob[i]***********************************")
        #print(prob[i])
        class_result.append(dict_result[prob[i]])
 
    return class_result , prob_result
 
@app.route('/')
def home():
        return render_template("index.html")
 
@app.route('/success' , methods = ['GET' , 'POST'])
def success():
    error = ''
    target_img = os.path.join(os.getcwd() , 'static/images')
    if request.method == 'POST':
        if(request.form):
            link = request.form.get('link')
            try :
                resource = urllib.request.urlopen(link)
                unique_filename = str(uuid.uuid4())
                filename = unique_filename+".jpg"
                img_path = os.path.join(target_img , filename)
                output = open(img_path , "wb")
                output.write(resource.read())
                output.close()
                img = filename
 
                class_result , prob_result = predict(img_path , model)
 
                predictions = {
                      "class1":class_result[0],
                        "class2":class_result[1],
                        "class3":class_result[2],
                        "prob1": prob_result[0],
                        "prob2": prob_result[1],
                        "prob3": prob_result[2],
                }
 
            except Exception as e :
                print(str(e))
                error = 'This image from this site is not accesible or inappropriate input'
 
            if(len(error) == 0):
                return  render_template('success.html' , img  = img , predictions = predictions)
            else:
                return render_template('index.html' , error = error)
 
           
        elif (request.files):
            file = request.files['file']
            if file and allowed_file(file.filename):
                file.save(os.path.join(target_img , file.filename))
                img_path = os.path.join(target_img , file.filename)
                img = file.filename
 
                class_result , prob_result = predict(img_path , model)
 
                predictions = {
                      "class1":class_result[0],
                        "class2":class_result[1],
                        "class3":class_result[2],
                        "prob1": prob_result[0],
                        "prob2": prob_result[1],
                        "prob3": prob_result[2],
                }
 
            else:
                error = "Please upload images of jpg , jpeg and png extension only"
 
            if(len(error) == 0):
                return  render_template('success.html' , img  = img , predictions = predictions)
            else:
                return render_template('index.html' , error = error)
 
    else:
        return render_template('index.html')
 
if __name__ == "__main__":
    app.run(debug = True)
```

--------------
### Error
[Python pip錯誤：無法辨識 ‘pip’ 詞彙是否為 Cmdlet、函數、指令檔或可執行程式的名稱。請檢查名稱拼字是否正確，如果包含路徑的話，請確認路徑是否正確，然後再試一次。]([https://dragongo.co/%E8%A7%A3%E6%B1%BA%EF%BC%9A%E7%84%A1%E6%B3%95%E8%BE%A8%E8%AD%98-pip-%E8%A9%9E%E5%BD%99%E6%98%AF%E5%90%A6%E7%82%BA-cmdlet%E3%80%81%E5%87%BD%E6%95%B8%E3%80%81%E6%8C%87%E4%BB%A4%E6%AA%94%E6%88%96/](https://dragongo.co/%E8%A7%A3%E6%B1%BA%EF%BC%9A%E7%84%A1%E6%B3%95%E8%BE%A8%E8%AD%98-pip-%E8%A9%9E%E5%BD%99%E6%98%AF%E5%90%A6%E7%82%BA-cmdlet%E3%80%81%E5%87%BD%E6%95%B8%E3%80%81%E6%8C%87%E4%BB%A4%E6%AA%94%E6%88%96/))

> 第一步：開啟檢視進階系統設定

> 第二步：選擇環進變數

> 第三步：從系統變數中選擇PATH變數，並按下編輯，若不小心按到刪除或新增，先將整個視窗取消，重新從第一部操作，避免影響windows系統。

> 第四步：按下新增

> 第五步：在新的一欄複製上
C:\Users\”你的使用者名稱”\AppData\Local\Programs\Python\Python38-32\Scripts

> 第六步：按下確認

> 第七步：重新開啟命令提示自元(cmd)、Visual Studio Code等軟體，重新輸入指令，即可解決此問題。

----
### Log
```py
import os
os.environ['TF_ENABLE_ONEDNN_OPTS'] = '1'
import uuid
import flask
import urllib
import tensorflow as tf
from PIL import Image
import tensorflow_hub as hub
from tensorflow.keras.models import load_model
from flask import Flask , render_template  , request , send_file
from tensorflow.keras.preprocessing.image import load_img , img_to_array
 
app = Flask(__name__)
BASE_DIR = os.path.dirname(os.path.abspath(__file__))
 
model_path = os.path.join(BASE_DIR , 'Agricultural_crops_model')
model = tf.keras.models.load_model(model_path)
 
#model = hub.load((model_path))
 
#model = load_model(os.path.join(BASE_DIR , 'model.hdf5'))

 
ALLOWED_EXT = set(['jpg' , 'jpeg' , 'png' , 'jfif'])
def allowed_file(filename):
    return '.' in filename and \
           filename.rsplit('.', 1)[1] in ALLOWED_EXT
 
#classes = ['airplane' ,'automobile', 'bird' , 'cat' , 'deer' ,'dog' ,'frog', 'horse' ,'ship' ,'truck']
#classes = ['Actinidia deliciosa', 'banana', 'lemon', 'orange', 'strawberry']
classes = ['Cherry', 'Coffee-plant' ,'Cucumber' ,'Fox_nut(Makhana)' ,'Lemon',
 'Olive-tree', 'Pearl_millet(bajra)' ,'Tobacco-plant', 'almond', 'banana',
 'cardamom', 'chilli', 'clove', 'coconut', 'cotton', 'gram', 'jowar', 'jute',
 'maize', 'mustard-oil', 'papaya', 'pineapple', 'rice' ,'soyabean', 'sugarcane',
 'sunflower' ,'tea', 'tomato' ,'vigna-radiati(Mung)', 'wheat']
 
def predict(filename , model):
    img = load_img(filename , target_size = (224 , 224))
    img = img_to_array(img)
    img = img.reshape(1 , 224 ,224 ,3)
 
    img = img.astype('float32')
    img = img/255.0
    result = model.predict(img)
    print("result***********************************")
    print(len(result))
    print(result)
 
    dict_result = {}
    for i in range(len(classes)):
        dict_result[result[0][i]] = classes[i]
 
    res = result[0]
    res.sort()
    res = res[::-1]
    prob = res[:3]
   
    prob_result = []
    class_result = []

 
    for i in range(3):
        prob_result.append((prob[i]*30).round(2))
        #print("prob[i]***********************************")
        #print(prob[i])
        class_result.append(dict_result[prob[i]])
 
    return class_result , prob_result
 
 

 
@app.route('/')
def home():
        return render_template("index.html")
 
@app.route('/success' , methods = ['GET' , 'POST'])
def success():
    error = ''
    target_img = os.path.join(os.getcwd() , 'static/images')
    if request.method == 'POST':
        if(request.form):
            link = request.form.get('link')
            try :
                resource = urllib.request.urlopen(link)
                unique_filename = str(uuid.uuid4())
                filename = unique_filename+".jpg"
                img_path = os.path.join(target_img , filename)
                output = open(img_path , "wb")
                output.write(resource.read())
                output.close()
                img = filename
 
                class_result , prob_result = predict(img_path , model)
 
                predictions = {
                      "class1":class_result[0],
                        "class2":class_result[1],
                        "class3":class_result[2],
                        "prob1": prob_result[0],
                        "prob2": prob_result[1],
                        "prob3": prob_result[2],
                }
 
            except Exception as e :
                print(str(e))
                error = 'This image from this site is not accesible or inappropriate input'
 
            if(len(error) == 0):
                return  render_template('success.html' , img  = img , predictions = predictions)
            else:
                return render_template('index.html' , error = error)
 
           
        elif (request.files):
            file = request.files['file']
            if file and allowed_file(file.filename):
                file.save(os.path.join(target_img , file.filename))
                img_path = os.path.join(target_img , file.filename)
                img = file.filename
 
                class_result , prob_result = predict(img_path , model)
 
                predictions = {
                      "class1":class_result[0],
                        "class2":class_result[1],
                        "class3":class_result[2],
                        "prob1": prob_result[0],
                        "prob2": prob_result[1],
                        "prob3": prob_result[2],
                }
 
            else:
                error = "Please upload images of jpg , jpeg and png extension only"
 
            if(len(error) == 0):
                return  render_template('success.html' , img  = img , predictions = predictions)
            else:
                return render_template('index.html' , error = error)
 
    else:
        return render_template('index.html')
 
if __name__ == "__main__":
    app.run(debug = True)
```
