# Java org.jsoup.examples
```
package org.jsoup.examples; //套件project名稱

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;

/**
 * A simple example, used on the jsoup website.
 */
	public class MyHTMLParser_using_jsoup{ //類別名稱
		public static void main(String[] args) throws IOException {
			Document doc = Jsoup.connect("https://rate.bot.com.tw/xrt?Lang=zh-TW").get();
			System.out.println("網頁標題:" + doc.title());//網頁標題
			System.out.println("網頁網址:"+ doc.baseUri());//網頁網址

			//解析所有 <tr> 標籤
			Elements trs = doc.select("tr"); //利用select函式，選擇Document(doc)中html的所有 <tr> 標籤  Elements類別(是ArrayList的子類別)
			//System.out.println("trs.toString(): \n" + trs.toString() + "\n"); //l列印所有trs Elements中的內容
			String[] token; //預備切割字串後，存放字串切割片段的字串陣列
			for(Element tr : trs){  
				System.out.println(tr.text() + ", ");
				token = tr.text().split(" "); //對每一行tr字串的文字(text)，進行切割字串
				for(int i = 0; i < token.length; i++) { //列印出所切割的字串結果 
					System.out.println(token[i]);
				}  
			}
        
			//解析所有 <td> 標籤 
			Elements tds = doc.select("td");//利用select函式，選擇Document(doc)中html的所有 <td> 標籤   Elements類別(是ArrayList的子類別)
			//System.out.println("tds.toString(): \n" + tds.toString() + "\n");    //l列印所有tds Elements中的內容
			for(Element td : tds){
				System.out.println(td.text() + ", ");
				token = td.text().split(" ");  //對每一筆td字串的文字(text)，進行切割字串
				for(int i = 0; i < token.length; i++) {  //列印出所切割的字串結果
					System.out.println(token[i]);
				}  
			}
        
			//Elements newsHeadlines = doc.select("#mp-itn b a");
			//for (Element headline : newsHeadlines) {
			//    log("%s\n\t%s", headline.attr("title"), headline.absUrl("href"));
			//}
		}

		private static void log(String msg, String... vals) {
			System.out.println(String.format(msg, vals));
		}
	}
```
# Gra time
```
package org.jsoup.examples; //套件project名稱

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;

/**
 * A simple example, used on the jsoup website.
 */
	public class MyHTMLParser_using_jsoup{ //類別名稱
		public static void main(String[] args) throws IOException {
			Document doc = Jsoup.connect("https://rate.bot.com.tw/xrt?Lang=zh-TW").get();
			System.out.println("網頁標題:" + doc.title());//網頁標題
			System.out.println("網頁網址:"+ doc.baseUri());//網頁網址

			//解析所有 <tr> 標籤
			Elements trs = doc.select("span"); //利用select函式，選擇Document(doc)中html的所有 <tr> 標籤  Elements類別(是ArrayList的子類別)
			//System.out.println("trs.toString(): \n" + trs.toString() + "\n"); //l列印所有trs Elements中的內容
			String[] token; //預備切割字串後，存放字串切割片段的字串陣列
			for(Element tr : trs){  
				System.out.println(tr.text() + ", ");
				token = tr.text().split(" "); //對每一行tr字串的文字(text)，進行切割字串
				for(int i = 0; i < token.length; i++) { //列印出所切割的字串結果 
					System.out.println(token[i]);
				}  
			}
        
			//解析所有 <td> 標籤 
			Elements tds = doc.select("time");//利用select函式，選擇Document(doc)中html的所有 <td> 標籤   Elements類別(是ArrayList的子類別)
			//System.out.println("tds.toString(): \n" + tds.toString() + "\n");    //l列印所有tds Elements中的內容
			for(Element td : tds){
				System.out.println(td.text() + ", ");
				token = td.text().split(" ");  //對每一筆td字串的文字(text)，進行切割字串
				for(int i = 0; i < token.length; i++) {  //列印出所切割的字串結果
					System.out.println(token[i]);
				}  
			}
        
			//Elements newsHeadlines = doc.select("#mp-itn b a");
			//for (Element headline : newsHeadlines) {
			//    log("%s\n\t%s", headline.attr("title"), headline.absUrl("href"));
			//}
		}

		private static void log(String msg, String... vals) {
			System.out.println(String.format(msg, vals));
		}
	}
```
# 顯示結果：
```
網頁標題:臺灣銀行牌告匯率
網頁網址:https://rate.bot.com.tw/xrt?Lang=zh-TW
, 

2020/05/21, 
2020/05/21
本行營業時間牌告匯率, 
本行營業時間牌告匯率
本行, 
本行
營業時間, 
營業時間
牌告匯率, 
牌告匯率
, 

2020/05/21 14:55, 
2020/05/21
14:55
遠期匯率, 
遠期匯率
本行買入, 
本行買入
本行買入, 
本行買入
本行賣出, 
本行賣出
本行賣出, 
本行賣出
本行買入, 
本行買入
本行買入, 
本行買入
本行賣出, 
本行賣出
本行賣出, 
本行賣出
本行買入, 
本行買入
本行賣出, 
本行賣出
本行買入, 
本行買入
本行賣出, 
本行賣出
```
# Grab time_1 / current time
```
package org.jsoup.examples; //套件package名稱

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;

/**
 * A simple example, used on the jsoup website.
 */
public class MyHTMLParser_using_jsoup{ //類別名稱
    
    //主函式
    public static void main(String[] args) throws IOException {
        Document doc = Jsoup.connect("https://rate.bot.com.tw/xrt?Lang=zh-TW").get(); //藍色的UR，可以更換成你要抓的網頁
        System.out.println("網頁標題:" + doc.title()); //doc.title()函式: 取得網頁標題
        System.out.println("網頁網址:"+ doc.baseUri()); //doc.baseUri()函式: 取得網頁網址

        Elements trs = doc.select(".time"); //利用select函式，選擇Document(doc)中html的所有 <tr> 標籤  Elements類別(是ArrayList的子類別)
		
        //System.out.println("trs.toString(): \n" + trs.toString() + "\n"); //l列印所有trs Elements中的內容
		String[] token; //預備切割字串後，存放字串切割片段的字串陣列
		for(Element tr : trs){  
			System.out.println(tr.text() + ", ");
			token = tr.text().split(" "); //對每一行tr字串的文字(text)，進行切割字串
			for(int i = 0; i < token.length; i++) { //列印出所切割的字串結果 
				System.out.println(token[i]);
			} 
			
		}
	}

}
```
# 顯示結果：
```
網頁標題:臺灣銀行牌告匯率
網頁網址:https://rate.bot.com.tw/xrt?Lang=zh-TW
2020/05/21 15:15, 
2020/05/21
15:15
```
# Geab image
```
package org.jsoup.examples; //套件package名稱

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;

/**
 * A simple example, used on the jsoup website.
 */
public class MyHTMLParser_using_jsoup{ //類別名稱
    
    //主函式
    public static void main(String[] args) throws IOException {
        Document doc = Jsoup.connect("https://rate.bot.com.tw/xrt?Lang=zh-TW").get(); //藍色的UR，可以更換成你要抓的網頁
        System.out.println("網頁標題:" + doc.title()); //doc.title()函式: 取得網頁標題
        System.out.println("網頁網址:"+ doc.baseUri()); //doc.baseUri()函式: 取得網頁網址

        Elements trs = doc.select("img"); //利用select函式，選擇Document(doc)中html的所有 <tr> 標籤  Elements類別(是ArrayList的子類別)
		
        //System.out.println("trs.toString(): \n" + trs.toString() + "\n"); //l列印所有trs Elements中的內容
		String[] token; //預備切割字串後，存放字串切割片段的字串陣列
		for(Element tr : trs){  
			System.out.println(tr.attr("title") + "\t"+tr.absUrl("src"));
			token = tr.text().split(" "); //對每一行tr字串的文字(text)，進行切割字串
			for(int i = 0; i < token.length; i++) { //列印出所切割的字串結果 
				System.out.println(token[i]);
			} 
			
		}
	}
}

```
# 顯示結果：
```
網頁標題:臺灣銀行牌告匯率
網頁網址:https://rate.bot.com.tw/xrt?Lang=zh-TW
臺灣銀行logo	https://rate.bot.com.tw/Content/images/logo.png

臺灣銀行logo	https://rate.bot.com.tw/Content/images/logo_color.png

	https://rate.bot.com.tw/Content/images/browser-ie.png

	https://rate.bot.com.tw/Content/images/browser-chrome.png

	https://rate.bot.com.tw/Content/images/browser-firefox.png

	https://rate.bot.com.tw/Content/images/browser-safari.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png

幣別國旗	https://rate.bot.com.tw/Content/images/sprite_lateral.png
```
# Grab html data
```
package org.jsoup.examples; //套件package名稱

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;

/**
 * A simple example, used on the jsoup website.
 */
public class MyHTMLParser_using_jsoup{ //類別名稱
    
    //主函式
    public static void main(String[] args) throws IOException {
        Document doc = Jsoup.connect("https://www.tna.gov.tw/tw/index.php?option=com_tnn_departures").get();
        System.out.println("網頁標題:" + doc.title());//網頁標題
        System.out.println("網頁網址:"+ doc.baseUri());//網頁網址

        Elements tags = doc.select(".content_padding table tr td");
        //利用select函式，選擇Document(doc)中html的所有 <tr> 標籤  Elements類別(是ArrayList的子類別)
          
        for(Element tag : tags){  
            System.out.println(tag.text());
        }
    }

}
```
# 顯示結果：
```
網頁標題:臺南航空站 - 離站班機資訊
網頁網址:https://www.tna.gov.tw/tw/index.php?option=com_tnn_departures

臺南航空站班機離站時刻表（今日）

臺灣時間 (GMT+8hrs)：109-05-21 下午 03:55:03 　　　　各航空公司櫃檯資訊｜本月到站｜本月離站 臺南航空站班機離站時刻表（今日） 航空公司 班次 飛往 預計起飛 預計抵達 登機門 班機狀態（實際起飛） 立榮 B7 8675 澎湖MZG 07:20 07:50 1 離站Departed 立榮 B7 8981 金門KNH 09:40 10:30 1 離站Departed 立榮 B7 8679 澎湖MZG 12:00 12:30 1 離站Departed 越捷 VJ 859 胡志明SGN 14:00 16:15 1 取消Cancelled 立榮 B7 8991 金門KNH 14:30 15:20 1 離站Departed 中華 CI 7863 香港HKG 16:45 18:25 1 取消Cancelled 立榮 B7 8681 澎湖MZG 17:40 18:10 1 準時ON TIME 航空公司資訊 航空公司 客服專線 機場櫃檯 網址 立榮航空公司 (02) 2508-6999 (06) 260-3683 立榮航空公司網站（另開新視窗） 中華航空公司 (02) 412-9000 (06) 260-1020 中華航空公司網站（另開新視窗） 越捷航空公司 （立榮航空代理） 0800-661-886 (06) 260-3683 越捷航空公司網站（另開新視窗） RSS 臺南航空站旅客時刻表（即時）
臺灣時間 (GMT+8hrs)：109-05-21 下午 03:55:03 　　　　各航空公司櫃檯資訊｜本月到站｜本月離站 臺南航空站班機離站時刻表（今日） 航空公司 班次 飛往 預計起飛 預計抵達 登機門 班機狀態（實際起飛） 立榮 B7 8675 澎湖MZG 07:20 07:50 1 離站Departed 立榮 B7 8981 金門KNH 09:40 10:30 1 離站Departed 立榮 B7 8679 澎湖MZG 12:00 12:30 1 離站Departed 越捷 VJ 859 胡志明SGN 14:00 16:15 1 取消Cancelled 立榮 B7 8991 金門KNH 14:30 15:20 1 離站Departed 中華 CI 7863 香港HKG 16:45 18:25 1 取消Cancelled 立榮 B7 8681 澎湖MZG 17:40 18:10 1 準時ON TIME
臺灣時間 (GMT+8hrs)：109-05-21 下午 03:55:03 　　　　各航空公司櫃檯資訊｜本月到站｜本月離站
立榮 B7
8675
澎湖MZG
07:20
07:50
1
離站Departed
立榮 B7
8981
金門KNH
09:40
10:30
1
離站Departed
立榮 B7
8679
澎湖MZG
12:00
12:30
1
離站Departed
越捷 VJ
859
胡志明SGN
14:00
16:15
1
取消Cancelled
立榮 B7
8991
金門KNH
14:30
15:20
1
離站Departed
中華 CI
7863
香港HKG
16:45
18:25
1
取消Cancelled
立榮 B7
8681
澎湖MZG
17:40
18:10
1
準時ON TIME


航空公司資訊 航空公司 客服專線 機場櫃檯 網址 立榮航空公司 (02) 2508-6999 (06) 260-3683 立榮航空公司網站（另開新視窗） 中華航空公司 (02) 412-9000 (06) 260-1020 中華航空公司網站（另開新視窗） 越捷航空公司 （立榮航空代理） 0800-661-886 (06) 260-3683 越捷航空公司網站（另開新視窗） RSS 臺南航空站旅客時刻表（即時）
立榮航空公司
(02) 2508-6999
(06) 260-3683
立榮航空公司網站（另開新視窗）
中華航空公司
(02) 412-9000
(06) 260-1020
中華航空公司網站（另開新視窗）
越捷航空公司 （立榮航空代理）
0800-661-886
(06) 260-3683
越捷航空公司網站（另開新視窗）

TOP
TOP
```
