## Transfer learning
### [ksu_1128_transfer_learning_with_hub.ipynb](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/Artificial%20Intelligence%E3%80%8A111-1%E3%80%8B/11-28/ksu_1128_transfer_learning_with_hub.ipynb)
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
### 2022-11-28 Assignment [Result]
![image](https://user-images.githubusercontent.com/55220866/204210853-5f40a521-7dff-4d42-85e8-c50105d755e7.png)
![image](https://user-images.githubusercontent.com/55220866/204210910-9e3bdbc2-0ac1-4ca9-8796-5fa538623209.png)
------------------------------------------------------------
### feature_vector 可在最後加上一層做判斷(此為 Transfer learning)
![image](https://user-images.githubusercontent.com/55220866/204214051-a7ec5ac3-058c-4570-9804-0455d574cc72.png)
```py
mobilenet_v2 = "https://tfhub.dev/google/tf2-preview/mobilenet_v2/feature_vector/4"
inception_v3 = "https://tfhub.dev/google/tf2-preview/inception_v3/feature_vector/4"

feature_extractor_model = mobilenet_v2 #@param ["mobilenet_v2", "inception_v3"] {type:"raw"}
```

------------------------------------------------------------
### 參考資料
 [Transfer Learning (C3W2L07)](https://www.youtube.com/watch?v=yofjFQddwHE) <br>
 [Transfer learning with TensorFlow Hub](https://www.tensorflow.org/tutorials/images/transfer_learning_with_hub) <br>
