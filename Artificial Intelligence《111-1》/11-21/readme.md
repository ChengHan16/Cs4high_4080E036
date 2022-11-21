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
