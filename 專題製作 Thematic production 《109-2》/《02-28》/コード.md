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
