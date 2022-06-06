## 需安裝套件
> ### pip install mpld3

## ● 練習範例
> https://www.kaggle.com/code/buddhiniw/breast-cancer-prediction/notebook

## ● Result
![#1](https://user-images.githubusercontent.com/55220866/172087678-60ca418c-622c-46de-bc9e-1a55944fe179.png)

## ● Error
### (1) No module named 'sklearn.cross_validation'
### `from sklearn.model_selection import KFold` <br>
![image](https://user-images.githubusercontent.com/55220866/172082966-9bbe571d-e045-48f1-957b-c2480c3f7ff1.png)

參考資料：https://blog.csdn.net/qq_35962520/article/details/85295228

---

### (2) AttributeError: ‘Rectangle’ object has no property ‘normed’
### 找到 `normed = True` 改為 `density = True`
![image](https://user-images.githubusercontent.com/55220866/172083071-9b0d3abd-287a-4341-b5d5-dc1b7f8e2830.png)

參考資料：https://blog.csdn.net/qq_45069279/article/details/105636669
