Web_Crawler
===========
# [●] BeautifulSoup
```
● BeautifulSoup 是一個用來解析HTML結構的Python套件(Package)，將取回的網頁HTML結構
● Beautifulsoup套件(Package)可透過pip指令來進行安裝，如下範例：pip install beautifulsoup4
```
BeautifulSoup 應用
-----------------
```
● import requests as rq

● from bs4 import BeautifulSoup

● url = “https://www.ptt.cc/bbs/NBA/index.html”     # PTT NBA 板

● response = rq.get(url)     # 用 requests 的 get 方法把網頁抓下來

● html_doc = response.text      # text 屬性就是 html 檔案

● soup = BeautifulSoup(response.text, “lxml”)   # 指定 lxml 作為解析器

● print(soup.prettify())      # 把排版後的 html 印出來
```
BeautifulSoup 的屬性或方法
-------------------------
```
• title 屬性

• title.name 屬性

• title.string 屬性

• title.parent.name 屬性

• a 屬性

• find_all() 方法
```
```
import requests as rq
from bs4 import BeautifulSoup

url = "https://www.ptt.cc/bbs/NBA/index.html" 
response = rq.get(url) 
html_doc = response.text soup = BeautifulSoup(response.text, "lxml")

print(soup.title) 	# 把 tag 抓出來
print("---")

print(soup.title.name) 	# 把 title 的 tag 名稱抓出來
print("---")

print(soup.title.string) 	# 把 title tag 的內容欻出來
print("---")

print(soup.title.parent.name) 	# title tag 的上一層 tag
print("---")

print(soup.a) 	# 把第一個 <a></a> 抓出來

print("---")
print(soup.find_all('a')) 	# 把所有的 <a></a> 抓出來
```
bs4 元素 (素子そし)
------------------
```
Beautiful Soup 幫我們將 html 檔案轉換為 bs4 的物件，像是標籤（Tag）
標籤中的內容（NavigableString）與 BeautifulSoup 物件本身。
```
### 標籤（Tag）
```
import requests as rq
from bs4 import BeautifulSoup

url = “https://www.ptt.cc/bbs/NBA/index.html” 	# PTT NBA 板
response = rq.get(url) 	# 用 requests 的 get 方法把網頁抓下來
html_doc = response.text 	# text 屬性就是 html 檔案
soup = BeautifulSoup(response.text, “lxml”) 	# 指定 lxml 作為解析器

print(type(soup.a))
print("---")
print(soup.a.name) 	# 抓標籤名 a
print("---")
print(soup.a[‘id’]) 	# 抓<a></a>的 id 名稱
```
標籤中的內容（NavigableString）
-----------------------------
```
import requests as rq
from bs4 import BeautifulSoup

url = “https://www.ptt.cc/bbs/NBA/index.html” 
response = rq.get(url) 
html_doc = response.text 
soup = BeautifulSoup(response.text, “lxml”)

print(type(soup.a.string))
print("---")
soup.a.string
```
# [●] requests
```
● 解析網頁的HTML程式碼前，還需要安裝Python的requests套件(Package)，將要爬取的網頁HTML程式碼取回來

● 安裝方式如下：
    pip install requests
```
