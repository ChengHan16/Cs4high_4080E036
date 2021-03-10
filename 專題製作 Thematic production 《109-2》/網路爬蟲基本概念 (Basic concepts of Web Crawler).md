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
### 由於`<div>`標籤下有多個`<a>`標籤的子節點，所以可以利用select()方法(Method)
### 選取其下所有的`<a>`標籤，且為串列(List)的資料型態。
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
# [●] 以CSS屬性搜尋節點
### 搜尋符合指定的HTML標籤及css屬性值的節點
```
import requests
from bs4 import BeautifulSoup
response = requests.get(
    "https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")
soup = BeautifulSoup(response.text, "html.parser")
titles = soup.find("p", class_="summary")
print(titles)
```
### 顯示結果_以CSS屬性搜尋節點
```
<p class="summary" itemprop="description">聖誕節即將到來，全台各地今年聖誕活動也陸續開跑！全台就有3處會下雪的浪漫耶誕村，從即日起陸續登場，活動更一直持續到2021年，讓旅客可以享受濃濃耶誕氛圍，還能在冬日中享受走進浪漫燈海裡盡情拍照。</p>

-----------------------------------------
注意(ちゅうい)：
因為這裡使用 find 所以(だから)才顯示一個而已
要多個查詢要使用find_all
```
# [●] find_all()屬性搜尋節點
### 搜尋網頁中符合指定的HTML標籤及css屬性值的所有節點
```
import requests
from bs4 import BeautifulSoup
response = requests.get(
    "https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")
soup = BeautifulSoup(response.text, "html.parser")
titles = soup.find_all("p", class_="summary")
print(titles)
```
### 顯示結果_find_all()屬性搜尋節點
```
[<p class="summary" itemprop="description">聖誕節即將到來，全台各地今年聖誕活動也陸續開跑！全台就有3處會下雪的浪漫耶誕村，從即日起陸續登場，活動更一直持續到2021年，讓旅客可以享受濃濃耶誕氛圍，還能在冬日中享受走進浪漫燈海裡盡情拍照。</p>, <p class="summary" itemprop="description">超有氣氛的「聖誕市集」來了！位於桃園中壢的大江購物中心首波公布耶誕造景，今年以自家門牌號碼501號為發想，規劃5大主題的「501號聖誕市集」，美美的歐洲小木屋中販賣烘焙甜點、巧克力及特調熱紅酒等市集美食。堪稱北台灣最大規模的手工薑餅城，也預計在12月19日正式點燈。                                                <em content="2020-11-18T11:45:00+08:00" itemprop="datePublished">(2020-11-18 11:45)</em>
</p>, <p class="summary" itemprop="description">台版普羅旺斯提前到來！原訂11月28日才開始的「桃園仙草花節」，連日遇上好天氣，昨（17日）已盛開約7成，紫色花朵隨風擺動，洋溢幸福氣息；而每年吸引破百萬人朝聖的「2020桃園花彩節」大溪展區也壓軸登場，建議開車民眾可將車停在第二停車場，再步行進入會場。                                                <em content="2020-11-18T10:42:00+08:00" itemprop="datePublished">(2020-11-18 10:42)</em>
</p>, <p class="summary" itemprop="description">桃園花彩節進入倒數計時，壓軸場大溪展區從即日起登場，大溪花海區今年以「動物派對」為主題，在花海間可看到許多可愛動物造景，活動至11月22日為止，想賞花可要把握最後倒數機會。                                                <em content="2020-11-16T15:09:00+08:00" itemprop="datePublished">(2020-11-16 15:09)</em>
</p>, <p class="summary" itemprop="description">桃園每年夏秋必辦的綠色生活悠遊節，今年以花現好時光為主題，搭配小農市集、音樂、好食等元素，打造出浪漫無比的約會聖地，不論親子、情侶或網美都很愛；活動連續九天不間斷，像是巨大雙愛心花海、稻草卷、落羽松林、巨大泡泡屋等都超美，男友們只要負責拍就對了。

                                                <em content="2020-11-15T14:51:00+08:00" itemprop="datePublished">(2020-11-15 14:51)</em>
</p>, <p class="summary" itemprop="description">無車族前往東眼山更方便了！桃園觀旅局宣布再加開「台灣好行東眼山線」班次，明（14日）起假日固定增開4班次，在疫情仍籠罩的當下，可以節能減碳進入1212公尺高的山林中森呼吸，與大自然來場親密接觸。                                                <em content="2020-11-13T13:41:00+08:00" itemprop="datePublished">(2020-11-13 13:41)</em>
</p>, <p class="summary" itemprop="description">今年的桃園可說是話題不斷！多處讓人眼睛一亮的新旅遊熱點讓人流連忘返，一甩大家對桃園總是無聊的刻板印象，桃園忠烈祠暨神社文化園區在11月底再度出招，集結20間特色攤商，打造全台首場神社市集，要挑戰最狂的偽出國！

                                                <em content="2020-11-11T14:25:00+08:00" itemprop="datePublished">(2020-11-11 14:25)</em>
</p>]
```
# [●] 搜尋父節點(find_parents)
### 以上皆為向下的搜尋節點方式
### 若想要從某一個節點向上搜尋，使用BeautifulSoup套件(Package)的find_parent()或find_parents()方法
### 搜尋 `<a>` 標籤且itemprop屬性值為url的節點，透過find_parents()，向上搜尋 `<h3>`標籤的父節點。
```
import requests
from bs4 import BeautifulSoup
response = requests.get(
    "https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")
soup = BeautifulSoup(response.text, "html.parser")
result = soup.find("a", itemprop="url")
parents = result.find_parents("h3")
print(parents)
```
### 顯示結果_搜尋父節點(find_parents)
```
[<h3 itemprop="headline">
<a href="https://travel.ettoday.net/article/1859651.htm" itemprop="url">這個冬天必去！全台3處「會飄雪的耶誕村」..</a>
</h3>]
```
# [●] 搜尋前、後節點 (find_previous_siblings)
### 在同一層級的節點，要搜尋前一個節點，使用BeautifulSoup套件(Package)の find_previous_siblings()
```
import requests
from bs4 import BeautifulSoup
response = requests.get(
    "https://travel.ettoday.net/category/%E6%A1%83%E5%9C%92/")
soup = BeautifulSoup(response.text, "html.parser")
result = soup.find("h3", itemprop="headline")
previous_node = result.find_previous_siblings("a") # previous_node(前のノード)
print(previous_node)
```
### 顯示結果_搜尋前、後節點 (find_previous_siblings)
```
[<a class="pic" href="https://travel.ettoday.net/article/1859651.htm">
<img data-original="https://cdn2.ettoday.net/images/5284/c5284491.jpg" itemprop="image" onerror="this.src='//cdn2.ettoday.net/style/travel/images/fb_ettoday_travel_logo.jpg'" src="https://cdn2.ettoday.net/style/misc/loading_200x150.gif"/>
</a>]
```
# ![虛擬環境架設](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E4%BC%BA%E6%9C%8D%E7%B6%B2%E9%A0%81%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%8A109-2%E3%80%8B/%E8%99%9B%E6%93%AC%E7%92%B0%E5%A2%83%E6%9E%B6%E8%A8%AD.md)
# 參考資料
```
https://medium.com/young-tsai/%E5%AD%B8%E7%BF%92-%E7%B6%B2%E8%B7%AF%E7%88%AC%E8%9F%B2-web-crawler-b4833ec7d7dd
```
