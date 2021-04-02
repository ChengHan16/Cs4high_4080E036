## Image Download
> ### `conda create --name ImgDload python=3.8`
>> ### `pip install requests`
>> ### `pip install beautifulsoup4`
>> ### `pip install lxml`
```python
from bs4 import BeautifulSoup
import requests
import os
```
# 下載單張圖片 (ホームページのイメージの住所で)
```python
import requests
from urllib.request import urlretrieve
import os


saveDir = "./images"
if not os.path.isdir(saveDir):
    os.mkdir(saveDir)

url = "https://www.mymypic.net/data/attachment/forum/202104/01/19564705x4sar445kb72xa.jpg"
urlretrieve(url,saveDir + 'Congestus_con.jpg')

url = "https://www.mymypic.net/data/attachment/forum/202104/01/1956447qdkf68fqqzdm2qi.jpg"
urlretrieve(url,saveDir + 'Congestus_con1.jpg')
```

# ノート
```python
import requests
from bs4 import BeautifulSoup
import lxml
import os
#import urllib.request
from urllib.request import urlretrieve
import sys


r1=requests.get('https://www.mymypic.net/data/attachment/forum/202103/25/180906a3luhambr3t8ttky.jpg')
soup=BeautifulSoup(r1.text,'lxml')
image=soup.find_all('div')


#下面的迴圈是找圖片網址再把結果放到陣列裡
links=[]
for d in image:
	if d.find('img'):        #再從div找img裡面的src  
		result=d.find('img')['src']
		links.append(result)

x=1
for link in links:
	local = os.path.join(r"C:\Users\harry\OneDrive\桌面\-#Program-\Python\Image Download\images\%s.jpg" % x)
	urlretrieve(link,local) #link是下載的網址 local是儲存圖片的檔案位址
	x+=1
```
```python
import requests
import os

saveDir = "./images"
if not os.path.isdir(saveDir):
    os.mkdir(saveDir)

url = "https://www.jkforum.net/thread-13478848-1-1.html"
img = requests.get(url)
with open(saveDir+'Congests_con.jpg,'wb') as f:
    f.write(img.content)
```
```python
import requests
from urllib.request import urlretrieve
import os

'''
saveDir = "./images"
if not os.path.isdir(saveDir):
    os.mkdir(saveDir)
'''

url = "https://www.jkforum.net/thread-13478848-1-1.html"
urlretrieve(url,'Congestus_con.jpg')
```
# 質問
> ### Error：AttributeError: module 'urllib' has no attribute 'urlretrieve'
>> ### Urlretrieve 的 Python3 寫法 `https://oxygentw.net/blog/computer/urlretrieve-python3/`
> ### Error：SyntaxError: (unicode error) 'unicodeescape' codec can't decode bytes in position 2-3: truncated \UXXXXXXXX escape
>> ### `http://jasonyychiu.blogspot.com/2019/10/python-syntaxerror-unicode-error.html`
> ### Error：`urllib.urlretrieve` urllib.urlretrieve file python 3.3 
>> `https://stackoverflow.com/questions/21171718/urllib-urlretrieve-file-python-3-3`
___
# 參考資料
### `https://jennaweng0621.pixnet.net/blog/post/404383372-%5Bpython%2B%E7%88%AC%E8%9F%B2%5D-%E4%B8%8B%E8%BC%89%E7%B6%B2%E9%A0%81%E7%9A%84%E5%9C%96%E7%89%87`
___
# 📝メモ
> ### Python 影像處理套件 PIL `https://ithelp.ithome.com.tw/articles/10226578`
> ### 
