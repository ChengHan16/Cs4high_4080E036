```
import urllib.request as req 
url = "https://www.ptt.cc/bbs/movie/index.html"
# 建立一個 request  物件, 附加 Request Headers 的資訊
request = req.Request(url,headers={
    "User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36"
})
with req.urlopen(request) as response:
        data = response.read().decode("utf-8")
#解析原始碼,取得文章標題
import bs4
root = bs4.BeautifulSoup(data,"html_parser")
titles = root.find ("div",class_="title") #尋找 class = "title" 的 div 標籤
#print(root.title.a.string)
for title in titles:
    if title.a != None:
        print(title.a.string)
```
