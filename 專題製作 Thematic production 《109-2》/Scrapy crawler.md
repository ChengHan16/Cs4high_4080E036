Scrapy crawler
=============
[虛擬環境設定](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/%E8%99%9B%E6%93%AC%E7%92%B0%E5%A2%83%E6%9E%B6%E8%A8%AD.md)
----------
>檢查目前版本 ： conda –v
>>進行更新命令： conda update conda
>>>查看目前系統已有的虛擬環境： conda env list
>>>>建立一個叫做 myenv 的虛擬環境，且安裝python 3.5的版本
  ：conda create --name myflash01 python=3.8
>>>>>啟動一個新的虛擬環境：conda activa安裝 scrapyte myflash01
```
安裝 scrapy
  ：pip install scrapy

  ：scrapy startproject apple 
```
爬蟲模組在 apple 資料夾下
### 【●】Items.py 定義資料該怎麼做儲存
### 【●】pipelines.py 定義資料該怎麼做處理
### 【●】settings.py 包含所有設定檔
###  ->接下來所有的爬蟲程式都寫在spidersファイル中に，在spiders下開新檔案定義爬蟲就能開始

# 【●】範例1
## 抓取蘋果即時新聞
### [crawler.py](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/Scrapy%20Python%20Crawler%20%E3%82%B3%E3%83%BC%E3%83%89.md)
```
import scrapy
from bs4 import BeautifulSoup

class AppleCrawler(scrapy.Spider):
    name = 'apple'
    start_urls = ['https://tw.appledaily.com/realtime/new/']
    def parse(self, response):
        res = BeautifulSoup(response.body)
            for news in res.select('.flex-feature'):
                print news.select('timestamp"')[0].text
![image](https://user-images.githubusercontent.com/55220866/110632532-b25d8f00-81e2-11eb-8d11-4e4dcaad3f02.png)
```
>完成後 
>> ls 查看目前資料夾
>>> cd apple
>>>> dir 看目前目錄裡的檔案
>>>>> 輸入 scrapy crawl apple 執行

# 【●】範例2
## 清單連結抓取下一層的內容頁面
### crawler.py!
### 先抓取看使否能成功將連結抓取出來
```
import scrapy
from bs4 import BeautifulSoup
class AppleCrawler(scrapy.Spider):
    name = 'apple'
    start_urls = ['https://tw.appledaily.com/home/']
    def parse(self,response):
        domain = 'https://tw.appledaily.com/'
        res = BeautifulSoup(response.body)
        for news in res.select('.flex-feature'):
            #print (news.select('headline  truncate truncate--3')[0].text)
            #print domain+(news.select('a')[0]['href'])
```
### 可成功抓取後加上 ` domain = 'https://tw.appledaily.com/‘` 讓網址完整

### `yield scrapy.Request(domain + news.select('a')[0]['href'],self.parse_detail)`
### 這段是能夠抓取頁面後抓取`標題、網址`
### yield 是個產生器，在調取後不會立即執行，只有for迴圈在執行呼叫到yield的時候才會繼續
### 透過self.parse_detail 解析內容
### [crawler.py](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/Scrapy%20Python%20Crawler%20%E3%82%B3%E3%83%BC%E3%83%89.md)
```
import scrapy
from bs4 import BeautifulSoup

class AppleCrawler(scrapy.Spider):
    name = 'apple'
    start_urls = ['https://tw.appledaily.com/home/']
    def parse(self,response):
        domain = 'https://tw.appledaily.com/'
        res = BeautifulSoup(response.body)
        for news in res.select('.flex-feature'):
            #print (news.select('headline  truncate truncate--3')[0].text)
            #print domain+(news.select('a')[0]['href'])
            yield scrapy.Request(domain + news.select('a')[0]['href'],self.parse_detail)
    def parse_detail(self,response):
        res = BeautifulSoup(response.body)
        res.select('#h1')[0].text
```
