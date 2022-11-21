###

### 建立虛擬環境
> conda create -n tf-gpu tensorflow-gpu <br>
> conda activate tf-gpu
#### 查看虛擬環境  <br>
> conda env list <br>
#### 查看虛擬環境套件  <br>
> conda list <br>
#### 啟動虛擬環境
> conda activate tf-gpu
#### 關閉虛擬環境
> conda deactivate

### Install Package
 - pip install tensorflow-gpu
 - pip install opencv-python 
 - pip install matplotlib 
 - pip install tqdm

###
### [第一階段_建模_訓練_測試_儲存雲端_Code_File](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/Artificial%20Intelligence%E3%80%8A111-1%E3%80%8B/11-21/Code_File/AI_1121-Ver.2.ipynb)
### [第二階段_讀取雲端模型_手動測試](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/Artificial%20Intelligence%E3%80%8A111-1%E3%80%8B/11-21/Code_File/load_tf_model_20221121_Ver1.0.ipynb)
```py
# Display the model's architecture

model.summary()
```
```py
import os
from google.colab import drive
MOUNTPOINT = "/content/gdrive"
DATADIR = os.path.join(MOUNTPOINT, "MyDrive")
drive.mount(MOUNTPOINT)
```
```py
#————儲存模型到雲端資料夾————
import os
DATADIR = os.path.join(MOUNTPOINT, "MyDrive/TF_Models") #MyDrive_我的雲端, TF_Models_資料夾
saved_model_path = os.path.join(DATADIR,"cats_and_dogs.h5") #cats_and_dogs.h5_模型名稱
model.save(saved_model_path)
```
```py
#————儲存模型到雲端目錄————
saved_model_path =os.path.join(DATADIR, "cats_and_dogs.h5")
model.save(saved_model_path)
```
------------------------------------------------------------
![image](https://user-images.githubusercontent.com/55220866/202994142-268bc6dc-8458-415f-a3e4-0ae08d846815.png)

------------------------------------------------------------
### 參考資料
### [TensorFlow Hub.](https://tfhub.dev/)
### [faster_rcnn/openimages_v4/inception_resnet_v2](https://tfhub.dev/google/faster_rcnn/openimages_v4/inception_resnet_v2/1)
