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
### 顯示結果_(HTML 原始碼 此部分輸出資料多 只放部分)
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
### 尋第一個符合條件的HTML節點，傳入要搜尋的標籤名稱
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
### 顯示結果_find()
```
<h3 itemprop="headline">
<a href="https://travel.ettoday.net/article/1859651.htm" itemprop="url">這個冬天必去！全台3處「會飄雪的耶誕村」..</a>
</h3>
```
# [●] find_all()
### 搜尋網頁中所有符合條件的HTML節點，傳入要搜尋的HTML標籤名稱
### 由於執行結果可能會搜出許多的HTML內容，所以最後也可以利用limit關鍵字參數，限制搜尋的節點數量
```
import requests
from bs4 import BeautifulSoup

response = requests.get(
    “https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/”)

soup = BeautifulSoup(response.text, "html.parser")
result = soup.find_all("h3", itemprop="headline", limit=6)
print(result)

# find_all()方法(Method)回傳了一個串列(List)
# 包含了網頁中所有的<h3>標籤，且itemprop屬性值為headline的節點
```
### 顯示結果_find_all
```
[<h3 itemprop="headline">
<a href="https://travel.ettoday.net/article/1859651.htm" itemprop="url">這個冬天必去！全台3處「會飄雪的耶誕村」..</a>
</h3>, <h3 itemprop="headline">
<a href="https://travel.ettoday.net/article/1857950.htm" itemprop="url">定時飄雪、聖誕市集超浪漫！桃園「華泰名品..</a>
</h3>, <h3 itemprop="headline">
<a href="https://travel.ettoday.net/article/1857518.htm" itemprop="url">桃園「巧虎夢想樂園」12月開幕！300坪..</a>
</h3>, <h3 itemprop="headline">
<i class="icon_type_video"></i>
<a href="https://travel.ettoday.net/article/1857034.htm" itemprop="url">桃園免費「聖誕市集」來了！熱紅酒、甜點都有...巨型薑餅城12/19點燈</a>
</h3>, <h3 itemprop="headline">
<i class="icon_type_video"></i>
<a href="https://travel.ettoday.net/article/1856929.htm" itemprop="url">粉紫天堂「台版普羅旺斯」提前開花！花彩節大溪還有4公尺獨角獸</a>
</h3>, <h3 itemprop="headline">
<a href="https://travel.ettoday.net/article/1855527.htm" itemprop="url">融化少女心！桃園花彩節壓軸場大溪登場　4公尺夢幻獨角獸站在花海間</a>
</h3>]

# 反之在 find_add() 後不加 limit 來限制的話則全部顯示出來
```
# [●] 同時搜尋多個HTML標籤
### 將標籤名稱打包成串列(List)後，傳入find_all()方法
```
import requests
from bs4 import BeautifulSoup
response = requests.get(
    "https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")
soup = BeautifulSoup(response.text, "html.parser")
result = soup.find_all(["h3", "p"],limit=3)
print(result)

# 範例中同時搜尋了網頁中所有<h3>及<p>的HTML標籤內容，這邊限定只搜尋兩個節點。
```
### 顯示結果_同時搜尋多個HTML標籤
```
[<h3 itemprop="headline">
<a href="https://travel.ettoday.net/article/1859651.htm" itemprop="url">這個冬天必去！全台3處「會飄雪的耶誕村」..</a>
</h3>, <p class="summary" itemprop="description">聖誕節即將到來，全台各地今年聖誕活動也陸續開跑！全台就有3處會下雪的浪漫耶誕村，從即日起陸續登場，活動更一直持續到2021年，讓旅客可以享受濃濃耶誕氛圍，還能在冬日中享受走進浪漫燈海裡盡情拍照。</p>, <h3 itemprop="headline">
<a href="https://travel.ettoday.net/article/1857950.htm" itemprop="url">定時飄雪、聖誕市集超浪漫！桃園「華泰名品..</a>
</h3>]
```
# [●] select_one()
### 當某一節點下只有單個子節點時，可以利用BeautifulSoup套件(Package)的select_one()方法
```
import requests
from bs4 import BeautifulSoup
response = requests.get(
    "https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")
soup = BeautifulSoup(response.text, "html.parser")
result = soup.find("h3", itemprop="headline") # (標題)headline
print(result.select_one("a"))
```
### 顯示結果_select_one()
```
<a href="https://travel.ettoday.net/article/1859651.htm" itemprop="url">這個冬天必去！全台3處「會飄雪的耶誕村」..</a>

-----------------------------------------
注意(ちゅうい)：
因為這裡使用 find 所以(だから)才顯示一個而已
要多個查詢要使用find_all
```
# [●] select()
### 如果某一節點下有多個子節點時，則使用select()方法(Method)，選取子節點
### 由於 <div> 標籤下有多個 <a> 標籤的子節點，所以可以利用select()方法(Method)
### 選取其下所有的<a>標籤，且為串列(List)的資料型態。
```
import requests
from bs4 import BeautifulSoup
response = requests.get(
    "https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")
soup = BeautifulSoup(response.text, "html.parser")
result = soup.find("div",itemprop="itemListElement") # 多個子節點時須改為(項目清單元素)itemListElement
print(result.select("a"))
```
### 顯示結果_ select()
```
[<a class="pic" href="https://travel.ettoday.net/article/1859651.htm">
<img data-original="https://cdn2.ettoday.net/images/5284/c5284491.jpg" itemprop="image" onerror="this.src='//cdn2.ettoday.net/style/travel/images/fb_ettoday_travel_logo.jpg'" src="https://cdn2.ettoday.net/style/misc/loading_200x150.gif"/>
</a>, <a href="https://travel.ettoday.net/article/1859651.htm" itemprop="url">這個冬天必去！全台3處「會飄雪的耶誕村」..</a>]
```
