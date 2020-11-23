Web_Crawler
===========
BeautifulSoup
-------------
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
