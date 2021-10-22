# 2021-10-22 雲端運算概論
## Download Python 3.9.6
> ### https://www.python.org/downloads/
>> ### 位置：D:\FLASK2021\software\python-3.9.6-amd64
## 安裝步驟：
> ### 安裝時 勾選 Add Python 3.9 to PATH
> ### 安裝完成後測試：檔案總管 -> 上方輸入 cmd -> 檢查 python 有無安裝成功
> ### 檢查 pip 指令：cmd -> 輸入 pip 
---
## 安裝套件：
> ### pip3 install virtualenv (虛擬環境套件)
> ### pip install --upgrade pip (更新虛擬環境版本)
> ### 切換到資料夾 d: 
>> ### -> cd FLASK2021 
>>> ### -> cd 4080E036 
>>>> ### -> 在要安裝虛擬環境的資料夾下打 virtualenv flask2021 
> ### .\flask2021\Script\activate (開啟虛擬環境) 
> ### deactivate (離開虛擬環境)
## 新增資料夾 (在 D 槽)
> ### project_flask_1022 (名稱)
## 開啟 VScode 選擇 project_flask_1022 資料夾
> ### 開啟終端機 cd ..
>> ### ./4080E036\flask2021\Scripts\activate
>>> ### 解決 PowerShell 問題
>>> ### http://limitedcode.blogspot.com/2016/03/powershell-ps1.html
>>> ### 到檔案總管 輸入 PowerShell ISE 再輸入 get-executionpolicy (會看到Restricted
>>> ### 接著輸入 set-executionpolicy remotesigned 後按是，再輸入 set-executionpolicy -Scope CurrentUser remotesigned 後按是
>>> ### 檢查 get-executionpolicy 會出現 RemoteSigned
>>>> ### 就可以重回 VScode 輸入./4080E036\flask2021\Scripts\activate 開啟虛擬環境
---
## VScode 切換語言
> ### https://oranwind.org/vs-code-lang/
