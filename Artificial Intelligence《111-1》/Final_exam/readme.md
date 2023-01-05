## 4080E036 吳承翰 11101人工智慧_四資工四Ａ 期末報告
### 如有他人雷同屬實抄襲本作業

------
### 使用圖檔[1]
![image](https://user-images.githubusercontent.com/55220866/210820293-506008eb-0163-4f5a-9a12-ff31382223e1.png)
### [圖1檔連結](https://www.techspot.com/review/2391-intel-core-i7-12700/)
### Result[1]
![image](https://user-images.githubusercontent.com/55220866/210817781-a066e0a4-cd70-414e-a5d5-baf41d858805.png)

------
###  使用圖檔[2]
![image](https://user-images.githubusercontent.com/55220866/210820386-dc6080c6-dfb6-4d3d-9320-5d66c9bf0af2.png)
### [圖2檔連結](https://www.4gamers.com.tw/news/detail/55595/intel-raptor-lake-13th-gen-core-i9-13900k-and-i5-13600k-review)
### Result[2]
![image](https://user-images.githubusercontent.com/55220866/210817466-c3121226-fa41-4b04-8095-60fda56b1248.png)

------
### 使用圖檔[3]
![image](https://user-images.githubusercontent.com/55220866/210820186-bd0efb6a-1ee4-471d-8df4-f60d4f84bbd6.png)
### [圖3檔連結](https://www.4gamers.com.tw/news/detail/55261/amd-ryzen-9-7950x-review)
### Result[3]
![image](https://user-images.githubusercontent.com/55220866/210817220-6fafd942-5190-403d-9ec2-c7d9840d2d51.png)

------
### 使用圖檔[4]
![image](https://user-images.githubusercontent.com/55220866/210820715-ad392175-f989-44b0-819c-af27a1c23105.png)
### [圖4檔連結](https://www.tomshardware.com/reviews/amd-ryzen-9-5950x-5900x-zen-3-review)
### Result[4]
![image](https://user-images.githubusercontent.com/55220866/210820605-c7f85308-c5c7-4bdb-8d0f-36af94ba3570.png)

------
### 使用圖檔[5]
![image](https://user-images.githubusercontent.com/55220866/210821374-2d284ae4-bebc-416d-863f-675378a7d0c5.png)
### [圖5檔連結](https://www.techspot.com/review/2391-intel-core-i7-12700/)
### Result[5]
![image](https://user-images.githubusercontent.com/55220866/210821112-9a5df84c-afa4-4bf2-bdf0-2ca2f5e48386.png)

------

### [Google Colab 製作模型](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/Artificial%20Intelligence%E3%80%8A111-1%E3%80%8B/Final_exam/Final_exam_transfer_learning_with_hub.ipynb)

### [CPU_Model](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/Artificial%20Intelligence%E3%80%8A111-1%E3%80%8B/Final_exam/CPU_Model.zip)

### [Flask 網頁執行檔](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/Artificial%20Intelligence%E3%80%8A111-1%E3%80%8B/Final_exam/Ksu_AI_Final_Exam%20111-1.zip)

------

### app.py
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
 
model_path = os.path.join(BASE_DIR , 'CPU_Model')
model = tf.keras.models.load_model(model_path)
 
#model = hub.load((model_path))
#model = load_model(os.path.join(BASE_DIR , 'model.hdf5'))
 
ALLOWED_EXT = set(['jpg' , 'jpeg' , 'png' , 'jfif'])
def allowed_file(filename):
    return '.' in filename and \
           filename.rsplit('.', 1)[1] in ALLOWED_EXT
 
classes = ['12700','13900k','5950x','7600x','7950x']
 
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


