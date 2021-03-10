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
```
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
