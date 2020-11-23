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
### 開始步驟
```
首先引用 requests 套件，透過get()方法存取網址。
測試使用網頁為：	https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/(ETtoday旅遊雲的桃園景點)
-------------------------------------------------------------------------------
import requests
respones = requests.get("https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")
```
### 抓取 HTML 內容
```
import requests

from bs4 import BeautifulSoup

response = requests.get(
    "https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")

soup = BeautifulSoup(response.text, "html.parser")

print(soup.prettify())  #輸出排版後的HTML內容
```
### 顯示結果 (HTML 原始碼 此部分輸出資料多 只放部分)
```
<!DOCTYPE html>
<html>
 <head>
  <meta charset="utf-8"/>
  <meta content="width=device-width, initial-scale=1" name="viewport"/>
  <title>
   看板 NBA 文章列表 - 批踢踢實業坊
  </title>
  <link href="//images.ptt.cc/bbs/v2.27/bbs-common.css" rel="stylesheet" type="text/css"/>
  <link href="//images.ptt.cc/bbs/v2.27/bbs-base.css" media="screen" rel="stylesheet" type="text/css"/>
  <link href="//images.ptt.cc/bbs/v2.27/bbs-custom.css" rel="stylesheet" type="text/css"/>
  <link href="//images.ptt.cc/bbs/v2.27/pushstream.css" media="screen" rel="stylesheet" type="text/css"/>
  <link href="//images.ptt.cc/bbs/v2.27/bbs-print.css" media="print" rel="stylesheet" type="text/css"/>
 </head>
 <body>
  <div id="topbar-container">
   <div class="bbs-content" id="topbar">
    <a href="/bbs/" id="logo">
     批踢踢實業坊
    </a>
```
# [●] find() 
# 尋第一個符合條件的HTML節點，傳入要搜尋的標籤名稱
```
# find()
# 只搜尋第一個符合條件的HTML節點，傳入要搜尋的標籤名稱

import requests
from bs4 import BeautifulSoup
response = requests.get(
    “https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/”)

soup = BeautifulSoup(response.text, "html.parser")
result = soup.find("h3")
print(result)
```
# [●] find_all()
# 搜尋網頁中所有符合條件的HTML節點，傳入要搜尋的HTML標籤名稱
# 由於執行結果可能會搜出許多的HTML內容，所以最後也可以利用limit關鍵字參數，限制搜尋的節點數量
```
import requests
from bs4 import BeautifulSoup

response = requests.get(
    “https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/”)

soup = BeautifulSoup(response.text, "html.parser")
result = soup.find_all("h3", itemprop="headline", limit=6)
print(result)
```
# find_all()方法(Method)回傳了一個串列(List)
# 包含了網頁中所有的<h3>標籤，且itemprop屬性值為headline的節點
