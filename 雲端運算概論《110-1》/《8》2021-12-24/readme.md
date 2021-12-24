# 2021-12-24 雲端運算概論

###  ⚠ 安裝 Python 3.9.6 (記得勾選安裝的首頁最下面的 Add Python 3.9 to PATH)
> ###  PowerShell ISE
>> 1. get-executionpolicy (會回傳 Restricted
>> 2. set-executionpolicy remotesigned
>> 3. set-executionpolicy -Scope CurrentUser remotesigned
>> 4. get-executionpolicy (會回傳 RemoteSigned
> ### PowerShell Complete 
---
> ### pip install
>> 1. 安裝虛擬環境軟體 pip3 install virtualenv  
>> 2. 建立虛擬環境 virtualenv venv_flask2021
>> 3. 開啟虛擬環境 .\venv_flask2021\Scripts\activate
>> 4. 在虛擬環境下安裝flask套件 pip3 install flask
> ### pip install Complete
---
## > jade sqlite chrome
## 6:33 安裝 jade sqlite chrome <br> ![image](https://user-images.githubusercontent.com/55220866/147331973-c84c6590-5d3c-451e-81e4-c7172d1718a0.png)

## [ - Code _程式碼 html & css](https://github.com/ChengHan16/Cs4high_4080E036/tree/master/%E9%9B%B2%E7%AB%AF%E9%81%8B%E7%AE%97%E6%A6%82%E8%AB%96%E3%80%8A110-1%E3%80%8B/%E3%80%8A8%E3%80%8B2021-12-24/Code%20_%E7%A8%8B%E5%BC%8F%E7%A2%BC%20html%20%26%20css)
## - Result
## - Error 
### 1. jinja2.exceptions.TemplateNotFound (已解決)
```
1、項目下面是否有templates文件夾，你的html文件是否放進了裡面；
2、templates文件夾是否和你運行的py文件在同一級目錄；
3、render_template('***.html')這裡面的名字是否正確，別打錯了；
4、app = Flask(__name__, template_folder='templates', static_folder="****",static_url_path="****") 
   在最開始的這句話中，template_folder後面一定要跟上templates；
```
> https://blog.csdn.net/shangxiaqiusuo1/article/details/103684463
