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
```
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
