### - Google - drive
https://drive.google.com/drive/u/1/folders/1Jk-4lyOcSUsEbsoeJve9QuG1U4UxBnCg
### - 參考資料
https://hackmd.io/@ShenTengTu/r1baxV4pQ


### Raspberry Pi Address ：192.168.2.183
------------------------
### - 操作問題
可以輸入Python的關鍵字，例如print來獲得其相關的幫助。<br> 也可以輸入模組名或主題來獲取幫助資訊。如果要退出幫助資訊，可以按Q鍵。<br> 如果要退出互動式shell的幫助，可以按住Ctrl鍵，然後按一下D鍵，這個組合鍵寫作Ctrl+D。<br> 或者，也可以輸入quit並按下回車鍵來退出。 當用完了Python互動式shell後，只需輸入exit()然後按回車鍵，Python就會退出互動式shell，並回到命令列。 
 - Url： https://itw01.com/FQ76E54.html
------------------------
### - Note
```
useradd --help
useradd -m
sudo adduser -m 4080E036
useradd -m 4080E036
```
------------------------
### - 設定使用者
```
sudo useradd -m 4080E036
ls /home/ -la
groups 4080E036
```
------------------------
###  - 預設帳密
```
pi
raspberry
```
------------------------
###  - 更新時間設定
```
timedatectl
sudo timedatectl set-timezone Asia/Taipei
sudo timedatectl set-ntp 0
sudo timedatectl set-time "2021-11-23 11:17"
sudo timedatectl set-ntp 1
```
------------------------
###  - 更新套件庫"名稱"
```
sudo apt update -y
```
###  - python 權限問題設定
```
錯誤訊息
Traceback (most recent call last):
  File "/home/4080E036/Program_ch3/RGBLED/test.py", line 10, in <module>
    led = RGBLED(11,13,15,mode=0)
  File "/home/4080E036/Program_ch3/RGBLED/RGBLED.py", line 21, in __init__
    GPIO.setup(self.__redpin, GPIO.OUT)
RuntimeError: No access to /dev/mem.  Try running as root!

需再自己使用者設定
sudo usermod -a -G gpio 使用者帳號
sudo chown root.gpio /dev/gpiomem
sudo chmod g+rw /dev/gpiomem
```
