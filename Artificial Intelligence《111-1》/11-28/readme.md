### Anaconda 啟動步驟
> 建立虛擬環境：`conda create -n tf-gpu tensorflow-gpu` <br>
> 啟動虛擬環境：`conda activate tf-gpu`<br>
> 查看虛擬環境：`conda env list` &emsp; 查看虛擬環境套件：`conda list` <br>
> 啟動虛擬環境：`conda activate tf-gpu` &emsp; 關閉虛擬環境：`conda deactivate`

### Install Package
 - pip install tensorflow-gpu
 - pip install opencv-python 
 - pip install matplotlib 
 - pip install tqdm
------------------------------------------------------------
###
### [第一階段]()
### [第二階段]()
![image](https://user-images.githubusercontent.com/55220866/204206463-1cf5594c-d4c0-4e9c-b28b-54547b3ddabf.png)
![image](https://user-images.githubusercontent.com/55220866/204206793-745e0244-c461-4d39-a8a3-b05f0dfc7a75.png)
Select GPU Mode
<br>
分類器選擇使用, 在 Tensorflow 裡的 hub.KerasLayer
```py
classifier = tf.keras.Sequential([
    hub.KerasLayer(classifier_model, input_shape=IMAGE_SHAPE+(3,)) 
```
範例圖更換 (URL)
```py
grace_hopper = tf.keras.utils.get_file('image.jpg','https://storage.googleapis.com/download.tensorflow.org/example_images/grace_hopper.jpg')
grace_hopper = Image.open(grace_hopper).resize(IMAGE_SHAPE)
grace_hopper
```
### 2022-11-28 Assignment
![image](https://user-images.githubusercontent.com/55220866/204210853-5f40a521-7dff-4d42-85e8-c50105d755e7.png)
![image](https://user-images.githubusercontent.com/55220866/204210910-9e3bdbc2-0ac1-4ca9-8796-5fa538623209.png)

------------------------------------------------------------
### 參考資料
 [Transfer Learning (C3W2L07)](https://www.youtube.com/watch?v=yofjFQddwHE) <br>
 [Transfer learning with TensorFlow Hub](https://www.tensorflow.org/tutorials/images/transfer_learning_with_hub) <br>
