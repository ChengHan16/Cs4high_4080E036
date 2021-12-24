# 2021-12-24 雲端運算概論

###  ⚠ 安裝 Python 3.9.6 (記得勾選安裝的首頁最下面的 Add Python 3.9 to PATH)
> ###  PowerShell ISE
>> 1. get-executionpolicy (會回傳 Restricted
>> 2. set-executionpolicy remotesigned
>> 3. set-executionpolicy -Scope CurrentUser remotesigned
>> 4. get-executionpolicy 
> ### PowerShell Complete (會回傳 RemoteSigned
---
> ### pip install
>> 1. 安裝虛擬環境軟體 pip3 install virtualenv  
>> 2. 建立虛擬環境 virtualenv venv_flask2021
>> 3. 開啟虛擬環境 .\venv_flask2021\Scripts\activate
>> 4. 在虛擬環境下安裝flask套件 pip3 install flask
> ### pip install Complete
---

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
