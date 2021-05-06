# ● Python os.listdir()

```python
import os, sys

# 打开文件
path = "/4080E000/MyFlask2021/mp3Dload"
dirs = os.listdir( path )

# 输出所有文件和文件夹
for file in dirs:
   print (file)
```
# ● Results(執行結果)
```
PS D:\4080E000\MyFlask2021\mp3Dload> python OpenFile.py
app.py
OpenFile.py
Tomp3.py
新冠病毒全球疫情｜更新時間 20210503 1700.mp4
過馬路走輸小綠人 恐罹肺動脈高壓｜華視新聞 20210505.mp4
醉男騎電動滑板車 自摔重創頭部送醫｜華視新聞 20210506.mp4
```

---
# ● Error
### SyntaxError: Missing parentheses in call to 'print'” mean in Python?
> `https://stackoverflow.com/questions/25445439/what-does-syntaxerror-missing-parentheses-in-call-to-print-mean-in-python`
---
# ● 參考資料 
### Python os.listdir() 方法
> `https://www.runoob.com/python/os-listdir.html`
### Python 列出目錄中所有檔案教學：os.listdir 與 os.walk
> `https://blog.gtwang.org/programming/python-list-all-files-in-directory/`
# ノート
## 如果目录下有中文目录，打印时遇到乱码解决方法：
```python
cPath = os.getcwd()

# 如果目录名字为中文 需要转码处理
uPath = unicode(cPath,'utf-8')
for fileName in os.listdir(uPath) :
    print fileName
```
