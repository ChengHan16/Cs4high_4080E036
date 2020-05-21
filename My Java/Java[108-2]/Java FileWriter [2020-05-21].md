# FileWriter
 ```
 //準備寫入檔案的Writer物件 out
        PrintWriter out
           = new PrintWriter(
                   new BufferedWriter(
                        new FileWriter("./data/customer_out.txt")));//寫入檔案路徑
```
# 將jsoup抓到的網頁，寫入檔案 [UTF-8]編碼 不新增新類別
```
package org.jsoup.examples; //套件package名稱

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;


/**
 * A simple example, used on the jsoup website.
 */
public class MyHTMLParser_using_jsoup{ //類別名稱
    
    public static String charset = "UTF-8";

    //主函式
    public static void main(String[] args) throws IOException {
        
        //準備寫入檔案的Writer物件 out       
        //BufferedFileWriter out = new BufferedFileWriter("./data/BOTrate.html");
        
        BufferedWriter out = new BufferedWriter(
                new OutputStreamWriter(
                        new FileOutputStream("./data/BOTrate.html"), "UTF-8"));
        
        String url = "https://rate.bot.com.tw/xrt?Lang=zh-TW";
        Document doc = Jsoup.connect(url).get();
        
        System.out.println(doc.toString());
        out.write(doc.toString()); 
        out.close();
    }

}
```
# FileWriter Test
```
package org.jsoup.examples; //套件package名稱

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.URL;
import java.nio.file.Files;
import java.util.Scanner;

/**
 * A simple example, used on the jsoup website.
 */
public class MyHTMLParser_using_jsoup{ //類別名稱
    
    public static String charset = "UTF-8";

    //主函式
    public static void main(String[] args) throws IOException {
        
         //準備寫入檔案的Writer物件 out       
        BufferedFileWriter out = new BufferedFileWriter("./data/BOTrate.html");
        String url = "https://rate.bot.com.tw/xrt?Lang=zh-TW";
        
        Document doc = Jsoup.parse(new URL(url).openStream(), charset, url);
        System.out.println(doc.toString());
        out.write(doc.toString()); 
        out.close();
    }

}
--------------------------------------------------------------------------------------------------------------------
package org.jsoup.examples;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.nio.charset.Charset;

/**
 * Created with IntelliJ IDEA.
 * User: Eugene Chipachenko
 * Date: 20.09.13
 * Time: 10:21
 */
public class BufferedFileWriter extends OutputStreamWriter
{
  public BufferedFileWriter( String fileName ) throws IOException
  {
    super( new FileOutputStream( fileName ), Charset.forName( "UTF-8" ) );
  }

  public BufferedFileWriter( String fileName, boolean append ) throws IOException
  {
    super( new FileOutputStream( fileName, append ), Charset.forName( "UTF-8" ) );
  }

  public BufferedFileWriter( String fileName, String charsetName, boolean append ) throws IOException
  {
    super( new FileOutputStream( fileName, append ), Charset.forName( charsetName ) );
  }

  public BufferedFileWriter( File file ) throws IOException
  {
    super( new FileOutputStream( file ), Charset.forName( "UTF-8" ) );
  }

  public BufferedFileWriter( File file, boolean append ) throws IOException
  {
    super( new FileOutputStream( file, append ), Charset.forName( "UTF-8" ) );
  }

  public BufferedFileWriter( File file, String charsetName, boolean append ) throws IOException
  {
    super( new FileOutputStream( file, append ), Charset.forName( charsetName ) );
  }
}
```
# 顯示結果：
```
         <td data-table="本行現金買入" class="rate-content-cash text-right print_hide">0.02259</td> 
         <td data-table="本行現金賣出" class="rate-content-cash text-right print_hide">0.02649</td> 
         <td data-table="本行即期買入" class="rate-content-sight text-right print_hide" data-hide="phone">-</td> 
         <td data-table="本行即期賣出" class="rate-content-sight text-right print_hide" data-hide="phone">-</td> 
         <td data-table="遠期匯率買入/賣出" class="text-center print_hide phone-small-font"><a href="/xrt/forward/KRW">查詢</a></td> 
         <td data-table="歷史匯率" class="text-center print_hide phone-small-font"><a href="/xrt/history/KRW" target="_blank">查詢</a></td> 
         <td data-table="本行現金買入" class="text-right display_none_print_show print_width">0.02259</td> 
         <td data-table="本行現金賣出" class="text-right display_none_print_show print_width">0.02649</td> 
         <td data-table="本行即期買入" class="text-right display_none_print_show print_width">-</td> 
         <td data-table="本行即期賣出" class="text-right display_none_print_show print_width">-</td> 
        </tr> 
        <tr> 
         <td data-table="幣別" class="currency phone-small-font"> 
          <div> 
           <div class="sp-div sp-vietnam-div"> 
            <img title="幣別國旗" alt="幣別國旗" src="/Content/images/sprite_lateral.png" class="sp-img sp-vietnam-img"> 
           </div> 
           <br class="visible-phone print_hide"> 
           <div class="visible-phone print_hide">
             越南盾 (VND) 
           </div> 
           <div class="hidden-phone print_show" style="text-indent:30px;">
             越南盾 (VND) 
           </div> 
          </div> </td> 
         <td data-table="本行現金買入" class="rate-content-cash text-right print_hide">0.00091</td> 
         <td data-table="本行現金賣出" class="rate-content-cash text-right print_hide">0.00141</td> 
         <td data-table="本行即期買入" class="rate-content-sight text-right print_hide" data-hide="phone">-</td> 
         <td data-table="本行即期賣出" class="rate-content-sight text-right print_hide" data-hide="phone">-</td> 
         <td data-table="遠期匯率買入/賣出" class="text-center print_hide phone-small-font"><a href="/xrt/forward/VND">查詢</a></td> 
         <td data-table="歷史匯率" class="text-center print_hide phone-small-font"><a href="/xrt/history/VND" target="_blank">查詢</a></td> 
         <td data-table="本行現金買入" class="text-right display_none_print_show print_width">0.00091</td> 
         <td data-table="本行現金賣出" class="text-right display_none_print_show print_width">0.00141</td> 
         <td data-table="本行即期買入" class="text-right display_none_print_show print_width">-</td> 
         <td data-table="本行即期賣出" class="text-right display_none_print_show print_width">-</td> 
        </tr> 
        <tr> 
         <td data-table="幣別" class="currency phone-small-font"> 
          <div> 
           <div class="sp-div sp-malaysia-div"> 
            <img title="幣別國旗" alt="幣別國旗" src="/Content/images/sprite_lateral.png" class="sp-img sp-malaysia-img"> 
           </div> 
           <br class="visible-phone print_hide"> 
           <div class="visible-phone print_hide">
             馬來幣 (MYR) 
           </div> 
           <div class="hidden-phone print_show" style="text-indent:30px;">
             馬來幣 (MYR) 
           </div> 
          </div> </td> 
         <td data-table="本行現金買入" class="rate-content-cash text-right print_hide">5.773</td> 
         <td data-table="本行現金賣出" class="rate-content-cash text-right print_hide">7.398</td> 
         <td data-table="本行即期買入" class="rate-content-sight text-right print_hide" data-hide="phone">-</td> 
         <td data-table="本行即期賣出" class="rate-content-sight text-right print_hide" data-hide="phone">-</td> 
         <td data-table="遠期匯率買入/賣出" class="text-center print_hide phone-small-font"><a href="/xrt/forward/MYR">查詢</a></td> 
         <td data-table="歷史匯率" class="text-center print_hide phone-small-font"><a href="/xrt/history/MYR" target="_blank">查詢</a></td> 
         <td data-table="本行現金買入" class="text-right display_none_print_show print_width">5.773</td> 
         <td data-table="本行現金賣出" class="text-right display_none_print_show print_width">7.398</td> 
         <td data-table="本行即期買入" class="text-right display_none_print_show print_width">-</td> 
         <td data-table="本行即期賣出" class="text-right display_none_print_show print_width">-</td> 
        </tr> 
        <tr> 
         <td data-table="幣別" class="currency phone-small-font"> 
          <div> 
           <div class="sp-div sp-china-div"> 
            <img title="幣別國旗" alt="幣別國旗" src="/Content/images/sprite_lateral.png" class="sp-img sp-china-img"> 
           </div> 
           <br class="visible-phone print_hide"> 
           <div class="visible-phone print_hide">
             人民幣 (CNY) 
           </div> 
           <div class="hidden-phone print_show" style="text-indent:30px;">
             人民幣 (CNY) 
           </div> 
          </div> </td> 
         <td data-table="本行現金買入" class="rate-content-cash text-right print_hide">4.111</td> 
         <td data-table="本行現金賣出" class="rate-content-cash text-right print_hide">4.273</td> 
         <td data-table="本行即期買入" class="rate-content-sight text-right print_hide" data-hide="phone">4.183</td> 
         <td data-table="本行即期賣出" class="rate-content-sight text-right print_hide" data-hide="phone">4.233</td> 
         <td data-table="遠期匯率買入/賣出" class="text-center print_hide phone-small-font"><a href="/xrt/forward/CNY">查詢</a></td> 
         <td data-table="歷史匯率" class="text-center print_hide phone-small-font"><a href="/xrt/history/CNY" target="_blank">查詢</a></td> 
         <td data-table="本行現金買入" class="text-right display_none_print_show print_width">4.111</td> 
         <td data-table="本行現金賣出" class="text-right display_none_print_show print_width">4.273</td> 
         <td data-table="本行即期買入" class="text-right display_none_print_show print_width">4.183</td> 
         <td data-table="本行即期賣出" class="text-right display_none_print_show print_width">4.233</td> 
        </tr> 
       </tbody> 
      </table> 
      <div class="text-center"> 
       <div class="btn-group"> <a class="btn" href="/xrt/fltxt/0/day">下載文字檔</a> <a class="btn" href="/xrt/flcsv/0/day">下載 Excel (CSV) 檔</a> <button type="button" class="btn click_print">列印本頁</button> <button type="button" class="btn click_close">關閉本頁</button> 
       </div> 
      </div> 
      <noscript> 
       <ul> 
        <li>列印本頁請按Ctrl + P</li> 
        <li>關閉本頁請按Ctrl + W</li> 
        <li>取得新報價請按F5</li> 
       </ul> 
      </noscript> 
     </div> 
    </div> 
    <div class="container doPrintDiv" style="display:none;"> <button class="btn doPrintBtn" style="display:none"> 列印本頁 </button> <button class="btn doCloseBtn" style="display:none"> 關閉本頁 </button> 
    </div> 
    <style>
            .footer {font-size: 11px}
            .footer a {white-space: nowrap}
            .footer .box {margin: 1em 0 0em 1em}
            .footer .clear {clear: both; margin-bottom: 1em}
            @media (min-width: 435px) {
                .footer {font-size: 12px;}
            }
            @media (min-width: 600px) {
                .footer {font-size: 14px;}
                .footer .box {margin: 3em 0 0em 3em}
                .footer .left, .fotter .right {width: 460px;}
                .footer .clear {margin-bottom: 3em}
            }
            </style> 
    <div class="container footer print_hide"> 
     <hr style="border-top:1px solid #ddd"> 
     <div class="box"> 
      <div class="pull-left left">
        客服中心：0800-025-168
       <br> 臺灣銀行版權所有 Bank Of Taiwan All Rights Reserved. 
      </div> 
      <div class="pull-left"> <a href="http://www.bot.com.tw/Copyright/Pages/default.aspx" target="_blank">資料開放宣告</a> &nbsp;|&nbsp; <a href="http://www.bot.com.tw/Protect/Pages/default.aspx" target="_blank">隱私權宣告</a> &nbsp;|&nbsp; <a href="http://www.twfhc.com.tw/security_policy.aspx" target="_blank">資訊安全政策</a> &nbsp;|&nbsp; <a href="http://www.bot.com.tw/Services/pages/relatedURL.aspx" target="_blank">相關連結</a> &nbsp;|&nbsp; <a href="https://www2.bot.com.tw/mailbox/mail.aspx" target="_blank">意見信箱</a>
       <br> 地址：10007 臺北市中正區重慶南路一段 120 號 
      </div> 
     </div> 
     <div class="clear"></div> 
    </div> 
   </main> 
  </div> 
  <script>
        if (navigator.userAgent.indexOf("MSIE") >= 0) {
            document.getElementById("h1_small_id").textContent = "";
            document.getElementById("h1_id").textContent = "請更新您的瀏覽器";
            document.getElementById("ie11andabove").style.display = "none";
            document.getElementById("ie10andbelow").style.display = "block";
        }
        if (!Function.prototype.bind) {
            Function.prototype.bind = function (oThis) {
                if (typeof this !== 'function') {
                    throw new TypeError('Function.prototype.bind - what is trying to be bound is not callable');
                }
                var aArgs = Array.prototype.slice.call(arguments, 1),
                    fToBind = this,
                    fNOP = function () { },
                    fBound = function () {
                        return fToBind.apply(this instanceof fNOP && oThis
                               ? this
                               : oThis,
                               aArgs.concat(Array.prototype.slice.call(arguments)));
                    };
                fNOP.prototype = this.prototype;
                fBound.prototype = new fNOP();
                return fBound;
            };
        }
        if (top != self) { top.location = encodeURI(self.location); }
    </script> 
  <script src="/Scripts/main-local.js?3.3.0"></script> 
  <script src="/Scripts/jquery-ui.min.js"></script> 
  <script>
        var controller = 'xrt'.toLowerCase();

        // Autocomplete
        $(function () {
            var search = [
                { url: "/xrt", label: "牌告匯率" },
                { url: "/xrt/history", label: "歷史匯率" },
                { url: "/cr", label: "臺灣銀行外幣結帳價格表" },
                { url: '/ir', label: '牌告利率' },
                { url: '/ir', label: '外匯存款牌告利率' },
                { url: '/ir/history', label: '歷史外匯存款牌告利率查詢' },
                { url: '/twd', label: '新臺幣存(放)款牌告利率' },
                { url: '/use', label: '外幣遠期信用狀牌告利率' },
                { url: '/gold', label: '新臺幣黃金牌價' },
                { url: '/gold/obu', label: '外幣計價黃金存摺牌價' },
                { url: '/gold/history', label: '歷史黃金牌價' },
                { url: '/gold/passbook', label: '歷史黃金存摺牌價' },
                { url: '/xrt/obu', label: '臺灣銀行 OBU 牌告匯率' },
                { url: '/xrt/obuhx', label: 'OBU 歷史匯率查詢' },
                { url: '/ir/obu', label: 'OBU 外匯存款牌告利率' },
                { url: '/use/obu', label: 'OBU 外幣遠期信用狀牌告利率' }
            ];
            $('#search').autocomplete({
                source: search,
                select: function (e, ui) {
                    location.href = "/?q=" + ui.item.label;
                }
            });
            $('#search').keypress(function (e) {
                var value = $(this).val();
                if (e.which == 13) {
                    /*var result = $.grep(search, function (x) {
                        return x.label === value;
                    });*/
                    location.href = "/?q=" + encodeURI(value);
                    return false;
                }
            });
            $('#search').focus(function () {
                if ($(window).width() >= 768) {
                    $(this).animate({ width: '250px' }, 500);
                }
            });
            $('#search').blur(function () {
                if ($(window).width() >= 768) {
                    $(this).animate({ width: '183px' }, 500);
                } else {
                    $('.search').removeClass('clicked');
                    $('#search').hide(500);
                    $('.search').animate({ top: '9px' }, 500);
                    $('.search button').css('cssText', 'font-size: 30px !important');
                    $('.search button').removeClass('clicked', 500);
                    $('.hero.container').animate({ marginBottom: '0' }, 500);
                }
            });
            $('.search button').click(function () {
                if ($(window).width() < 768) {
                    $('.search').addClass('clicked');
                    $('#search').css('width', '250px').show(500);
                    $('.search').animate({ right: '20px', top: '70px' }, 500);
                    $('.search button').css('cssText', 'font-size: 17px !important');
                    $('.search button').addClass('clicked', 500);
                    $('.hero.container').animate({ marginBottom: '28px' }, 500);
                    $('.search input').focus();
                    return false;
                }
            });

            $('.tabPage').on('DOMSubtreeModified', '#___gcse_0', function () {
                if ($(this).text().indexOf('沒有結果') >= 0) {
                    $('#list').show();
                } else {
                    $('#list').hide();
                }
            });
        });

        //停用 Row Toggle 功能
        function footable_off() {
            $('.footable tr').off();
            $('.footable td').off();
        }
        //判斷是否含中文
        function isChinese(str) {
            var patrn = /[\u4e00-\u9fff]/gi;
            if (patrn.exec(str)) {
                return true;
            }
            else {
                return false;
            }
        }
        var h1_size_from_css = 28;//parseInt($("#h1_id").css('font-size'));
        //自適應H1大小
        function minsize() {
            if ($("#h1_id").width() > $(".container").width()) {
                var oldH1size = parseFloat($("#h1_id").css('font-size'));
                var h1size = (oldH1size - 1).toString() + "px";
                $("#h1_id").css('font-size', h1size);
                $("#h1_small_id").css('font-size', h1size);
                //app px & pt fix
                if (parseFloat($("#h1_id").css('font-size')) > oldH1size) {
                    $("#h1_id").css('font-size', ((oldH1size - 1) / 1.73).toString() + "px");
                    $("#h1_small_id").css('font-size', ((oldH1size - 1) / 1.73).toString() + "px");
                }
            } else if ($("#h1_id").width() < $(".container").width()) {
                if (parseInt($("#h1_id").css('font-size')) < h1_size_from_css) {
                    $("#h1_id").css('font-size', parseInt($("#h1_id").css('font-size')) + 1 + 'px');
                    $("#h1_small_id").css('font-size', parseInt($("#h1_small_id").css('font-size')) + 1 + 'px');
                }
            } else {

            }
        }
        var h1_margin_from_css = $(".hero__header").css("margin");
        function setH1Size() {
            var H1_Str = "[blue]本行[/blue][red]營業時間[/red][blue]牌告匯率[/blue]";
            if (isChinese(H1_Str)) {
                //中文不破版縮小&放大
                for (var i = 1; i < 10; i++) {
                    window.setTimeout(function () {
                        minsize();
                    }, 1 * i);
                }
            }
        }

        //設定說明標籤高&文字置中
        function setRowChartKeyValuesMaxHeight() {
            $('div.chart-key-value').each(function () {
                $(this).find(".key").css("height", "");
                $(this).find(".value").css("height", "");
                $(this).find(".key").css("line-height", "");
                $(this).find(".value").css("line-height", "");
            })

            var window_width = $(window).width();
            if (window_width <= 750) {
                //小版型：分開看，value高決定key高
                $("div.chart-key-value").each(function () {
                    if ($(this).find(".key").height() > $(this).find(".value").height()) {
                        $(this).find(".value").height($(this).find(".key").height() + "px");
                        $(this).find(".value").css("line-height", $(this).find(".key").height() + "px");
                    } else {
                        $(this).find(".key").height($(this).find(".value").height() + "px");
                        $(this).find(".key").css("line-height", $(this).find(".value").height() + "px");
                    }
                });
            } else {
                //大版型：一起看，高統一看最高的
                var key_value_highest = 0;
                //找出最高
                $('div.chart-key-value').each(function () {
                    if ($(this).find(".key").height() > key_value_highest) {
                        key_value_highest = $(this).find(".key").height();
                    }
                    if ($(this).find(".value").height() > key_value_highest) {
                        key_value_highest = $(this).find(".value").height();
                    }
                })

                $('div.chart-key-value').each(function () {
                    if ($(this).find(".key").height() != key_value_highest) {
                        var key_value_height = 32 * (key_value_highest / $(this).find(".key").height());
                        $(this).find(".key").css("line-height", key_value_height + "px");
                    }
                    if ($(this).find(".value").height() != key_value_highest) {
                        var key_value_height = 32 * (key_value_highest / $(this).find(".value").height());
                        $(this).find(".value").css("line-height", key_value_height + "px");
                    }
                    $(this).find(".key").height(key_value_highest + "px");
                    $(this).find(".value").height(key_value_highest + "px");
                });
            }
        }

        function blurcommafy(num) {
            if (num.split(".").length == 1) {
                num = commafy(num);
            } else if (num.split(".").length == 2) {
                //小數部份不用加千分位
                num = commafy(num.split(".")[0]) + "." + num.split(".")[1];
            }
            return num;
        }

        //加上千分位
        function commafy(num) {
            num = num + "";
            var re = /(-?\d+)(\d{3})/
            while (re.test(num)) {
                num = num.replace(re, "$1,$2")
            }
            return num;
        }
        //移除千分位
        function removeCommafy(num) {
            return num.replace(/[,]+/g, "");
        }

        //RWD加入千分位
        function tableAddCommafy() {
            $(".table > tbody > tr > td").each(function () {
                var td = $(this).text();
                if (!isNaN(td)) {
                    if (td.split(".").length == 1) {
                        $(this).text(commafy(td));
                    } else if (td.split(".").length == 2) {
                        //小數部份不用加千分位
                        $(this).text(commafy(td.split(".")[0]) + "." + td.split(".")[1]);
                    }
                }
            })
        }

        //小數尾去0
        function removeTableDoubleZero() {
            $(".table > tbody > tr > td").each(function () {
                var td = $(this).text();
                if (!isNaN(td)) {
                    if (td.split(".").length == 1) {
                        $(this).text(commafy(td));
                    } else if (td.split(".").length == 2) {
                        //小數部份不用加千分位
                        //小數尾去0
                        if (td.split(".")[1].replace(/0+$/, '') == "") {
                            $(this).text(commafy(td.split(".")[0]));
                        } else {
                            $(this).text(commafy(td.split(".")[0]) + "." + td.split(".")[1].replace(/0+$/, ''));
                        }
                    }
                }
            })
        }

        //判斷瀏覽器類型
        function detectBrowser() {
            var Sys = {};
            var ua = navigator.userAgent.toLowerCase();
            var s;
            (s = ua.match(/rv:([\d.]+)\) like gecko/)) ? Sys.ie = s[1] :
            (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
            (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
            (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
            (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
            (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;

            if (Sys.ie) return "IE";
            if (Sys.firefox) return "Firefox";
            if (Sys.chrome) return "Chrome";
            if (Sys.opera) return "Opera";
            if (Sys.safari) return "Safari";
        }

        //xrt/all頁面table 第一行 th 隱藏
        function hideTableTh() {
            var all_width = $(window).width();//console.log(all_width);
            if (all_width < 980) {
                $(".tablet_hide").hide();
            } else {
                $(".tablet_hide").show();
            }

            if (all_width < 480) {
                $(".phone_hide").hide();
            } else {
                $(".phone_hide").show();
            }
        }

        //設定語系位置
        function setTitleLangDiv() {
            //ie8不使用 其他要用
            if (!-[1, ]) {
                $(".TitleLang").addClass("TitleLangDivIE");
            }
            else {
                $(".TitleLang").addClass("TitleLangDiv");
            }
        }

        //寬小於768px的手機 TABLE靠邊貼齊
        //這邊一定要用class指定，不可直接用table，不然emarketing進來的table也會被動到，造成手機版破版。
        function setTableWidthInMiniPhone() {
            var window_width = $(window).width();
            if (window_width <= 767) {
                $(".table").css("width", window_width - 2);
                $(".table").css("margin-right", "-20px");
                $(".table").css("margin-left", "-20px");
            } else {
                $(".table").css("width", "");
                $(".table").css("margin-right", "");
                $(".table").css("margin-left", "");
            }
        }

        //加上列印style
        function setPrintStyle() {

            /*main.css*/
            $(".visible-print").show();
            $(".hidden-print").hide();
            $("blockquote").css("page-break-inside", "avoid");
            $("img").css("page-break-inside", "avoid");
            $("pre").css("page-break-inside", "avoid");
            $("tr").css("page-break-inside", "avoid");
            $("a").css("text-decoration", "underline");
            $("a:visited").css("text-decoration", "underline");
            $("abbr[title]:after").css("content", "' (' attr(title) ')'");
            $(".ir a:after").css("content", "");
            $("a[href^='javascript:']:after").css("content", "");
            $("a[href^='#']:after").css("content", "");
            $("blockquote").css("border", "1px solid #999");
            $("pre").css("border", "1px solid #999");
            $("thead").css("display", "table-header-group");
            $("img").css("max-width", "100% !important");

            $("h2").css({
                "orphans": "3",
                "widows": "3"
            });
            $("h3").css({
                "orphans": "3",
                "widows": "3"
            });
            $("p").css({
                "orphans": "3",
                "widows": "3"
            });
            $(".H1_div_ctrl").show();
            $("h2").css("page-break-after", "avoid");
            $("h3").css("page-break-after", "avoid");

            /*_layout*/
            $(".display_none_print_show").show();
            $(".print_hide").hide();
            $(".logo_div").show();
            $(".logo_div").css("margin-top", "-3em");
            $(".dl-horizontal").hide();
            $("dropdown").hide();
            $(".dropbtn").hide();
            $(".btn").hide();
            $("table.table").css("border", "1px solid black !important");
            $("table").css("border", "1px solid black !important");
            $(".table th").css("border", "1px solid black !important");
            $("th").css("border", "1px solid black !important");
            $(".table td").css("border", "1px solid black !important");
            $("td").css("border", "1px solid black !important");
            $(".phone-unset-font").css("font-size", "large !important");
            $(".phone-small-font").css("font-size", "large !important");

            $(".nav_ctn").hide();
            $(".hero").css("background-color", "white");
            $(".hero").css("background-image", "linear-gradient(to right,white,white)");

            $(".doPrintDiv").show();
            $(".doPrintBtn").show();
            $(".doCloseBtn").show();
        }

        /// 檢查輸入的日期是否是一個正確的日期格式：
        /// 支持 yyyy-M-d、yyyy-MM-dd、yyyy/M/d、yyyy/MM/dd 四種輸入格式。
        function CheckDate(strInputDate) {
            if (strInputDate == "")
                return false;
            strInputDate = strInputDate.replace(/-/g, "/");
            var d = new Date(strInputDate);
            if (isNaN(d))
                return false;
            var arr = strInputDate.split("/");
            return ((parseInt(arr[0], 10) == d.getFullYear()) && (parseInt(arr[1], 10) == (d.getMonth() + 1)) && (parseInt(arr[2], 10) == d.getDate()));
        }

        //比較幣別 防呆xrt/history xrt/obuhx 不可比較自己
        function onCurrencySelectChange() {
            $("select[name='compare'] span").each(function () {
                $(this).showOption();
            })
            $("select[name='compare'] option").each(function () {
                if ($(this).val() == $("select[name='currency']").val()) {
                    $(this).hideOption();
                }
            })
        }

        $.fn.hideOption = function () {
            var text = $(this).text(), val = this.value, span =
            $('<span/>').text(text).val(val).hide()

            var old = $(this).clone();
            $(this).replaceWith(span)
            $(span).data('ref', old);
        }

        $.fn.showOption = function () {
            if ($(this).data('ref'))
                $(this).replaceWith($(this).data('ref'))
        }
        window.mobileAndTabletcheck = function () {
            var check = false;
            (function (a) { if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino|android|ipad|playbook|silk/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4))) check = true; })(navigator.userAgent || navigator.vendor || window.opera);
            return check;
        };
        if (mobileAndTabletcheck()) {
            $('.click_print').hide();
        }
        // Read a page's GET URL variables and return them as an associative array.
        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }

        function getBreakPointType_5types(width) {
            if (width < 480) {
                return "phone"
            } else if (width >= 480 && width < 600) {
                return "tablet"
            } else if (width >= 600 && width < 940) {
                return "default600"
            } else if (width >= 940 && width < 1170) {
                return "default940"
            } else {
                //return "default1170"
                return "default"
            }
        }

        //最近一個營業日不可比較幣別，比較幣別為空時不顯示現金&即期
        function search_range_check(search_range) {
            if (search_range.val() == 'ltm' || search_range.val() == 'month' || search_range.val() == 'l6m' || search_range.val() == 'l1y' || search_range.val() == 'l3y') {
                $('select[name=compare]').prop('disabled', false);
                if ($('select[name=compare]').val()) { $('#datatype').show(); } else {
                    $('#datatype').hide();
                }
            } else {
                $('select[name=compare]').val('');
                $('select[name=compare]').prop('disabled', 'disabled');
                $('#datatype').hide();
            }
        }

        //去footable上面多的線&下面多的線
        function footableHideNodataBottom() {
            $(".footable-row-detail-row").each(function () {
                if ($(this).find("div.footable-row-detail-name").html() == "") {
                    $(this).hide();
                }
            })
            $(".footable-row-detail-row:last-child").css("border-bottom", "0px #ddd solid");
        }

        //去除url中lang參數
        function removeUrlLang(urlSearch) {
            var patternTW = new RegExp('\\?lang=zh-tw&|\\?lang=zh-tw', 'gi');
            var patternUS = new RegExp('\\?lang=en-us&|\\?lang=en-us', 'gi');
            var patternCN = new RegExp('\\?lang=zh-cn&|\\?lang=zh-cn', 'gi');

            urlSearch = urlSearch.replace(patternTW, "").replace(patternUS, "").replace(patternCN, "");

            urlSearch = urlSearch.replace("?", "");
            if (urlSearch != "") {
                return "&" + urlSearch;
            } else {
                return urlSearch;
            }
        }

        //觸發多語系連結
        function ChangeLanguage(lang) {
            lang = lang.toLowerCase();
            switch (lang) {
                case "zh-tw":
                    if (location.search == "") {
                        window.location.href = encodeURI(location.pathname) + "?Lang=zh-TW";
                    } else {
                        window.location.href = encodeURI(location.pathname) + "?Lang=zh-TW" + removeUrlLang(location.search);
                    }
                    break;
                case "zh-cn":
                    if (location.search == "") {
                        window.location.href = encodeURI(location.pathname) + "?Lang=zh-CN";
                    } else {
                        window.location.href = encodeURI(location.pathname) + "?Lang=zh-CN" + removeUrlLang(location.search);
                    }
                    break;
                case "en-us":
                    if (location.search == "") {
                        window.location.href = encodeURI(location.pathname) + "?Lang=en-US";
                    } else {
                        window.location.href = encodeURI(location.pathname) + "?Lang=en-US" + removeUrlLang(location.search);
                    }
                    break;
                case "ja-jp":
                    if (location.search == "") {
                        window.location.href = encodeURI(location.pathname) + "?Lang=ja-JP";
                    } else {
                        window.location.href = encodeURI(location.pathname) + "?Lang=ja-JP" + removeUrlLang(location.search);
                    }
                    break;
            }
        }

        //xrt/obuhx查詢畫面title等高判定
        function setFormTitleHigh() {
            if ($('.container').width() > 768) {
                $(".queryForm1 > fieldset > legend").height(40.2);
                if ($(".queryForm1 > fieldset > legend").height() > $(".queryForm2 > fieldset > legend").height()) {
                    $(".queryForm2 > fieldset > legend").height($(".queryForm1 > fieldset > legend").height());
                } else if ($(".queryForm1 > fieldset > legend").height() < $(".queryForm2 > fieldset > legend").height()) {
                    $(".queryForm1 > fieldset > legend").height($(".queryForm2 > fieldset > legend").height());
                }
            } else {
                $(".queryForm1 > fieldset > legend").css("height", "");
                $(".queryForm2 > fieldset > legend").css("height", "");
            }
        }

        //cr/手機版rwd表格高調整
        function setTableTitleHigh() {
            if ($("tr.colstr th:eq(0)").height() > $("tr.colstr th:eq(1)").height()) {
                $("tr.colstr th:eq(1)").height($("tr.colstr th:eq(0)").height());
            } else if ($("tr.colstr th:eq(0)").height() < $("tr.colstr th:eq(1)").height()) {
                $("tr.colstr th:eq(0)").height($("tr.colstr th:eq(1)").height());
            }
            //console.log($('.container').width());
            if ($('.container').width() > 460) {
                $("table tbody tr").each(function () {
                    $(this).find("td:eq(1)").css("height", "");
                    $(this).find("td:eq(3)").css("height", "");
                })
            } else {
                window.setTimeout(function () {
                    $("table tbody tr").each(function () {
                        $(this).find("td:eq(1)").height($(this).find("td:eq(0)").height());
                        $(this).find("td:eq(3)").height($(this).find("td:eq(2)").height());
                    })
                }, 100);
            }

        }

        $(document).ready(function () {
            var body_width = $("body").width();
            var container_width = $('.container').width();
            //ie加入logo
            if (!-[1, ]) {
                $(".main > div.hero > nav > div > a").hide();
                $(".page-wrapper > main > div.hero").css("height", "100px");
            }

            setH1Size(); // 自適應H1大小

            setRowChartKeyValuesMaxHeight(); // 設定說明標籤高&文字置中

            //寬小於768px的手機 TABLE靠邊貼齊
            setTableWidthInMiniPhone()

            //設定語系位置
            setTitleLangDiv();

            $(window).resize(function () {
                if ($('.search').hasClass('clicked')) {
                    if ($(window).width() >= 768) {
                        $('.search').removeAttr('style');
                        $('#search').css('width', '183px');
                    } else {
                        $('.search').css('top', '70px');
                    }
                } else {
                    if ($(window).width() >= 768) {
                        $('.search').removeAttr('style');
                        $('#search').removeAttr('style');
                        $('.search > button').removeAttr('style');
                    }
                }
                setH1Size();
                if (controller == 'xrt') {
                    hideTableTh(); // xrt/all頁面table 第一行 th 隱藏
                    setFormTitleHigh(); // xrt/obuhx查詢畫面title等高判定
                }

                if (controller == 'cr') {
                    //cr/手機版rwd表格高調整
                    setTableTitleHigh();
                }

                if (controller == 'use') {
                    //use/手機版rwd表格高調整
                    setTableTitleHigh();
                }

                //設定說明標籤高&文字置中
                setRowChartKeyValuesMaxHeight();

                //寬小於768px的手機 TABLE靠邊貼齊
                setTableWidthInMiniPhone();

                if ($(window).width() >= 768) {
                    $('#search').css('top', 0);
                } else {

                }
            });

            //Trial
            if (controller == 'trial') {
                $("#lang_ddl").hide();
                $(".TitleLang").hide();

                $("input:radio").width("12px");
                $("div.trailer > span.input-append > input:text").width("40px");
                //JavaScript 鎖右鍵
                document.oncontextmenu = new Function("return false");

                $(".trailer").css("line-height", "45px");
                $(".trailer").css("line-height", "0");
            }

            // 動態功能
            if (controller == 'ir') {
                // Bind
                $('.footable').bind('footable_breakpoint', function (e) {
                    // 展開所有表格內容
                    $('.footable').trigger('footable_expand_all');
                    // 依事件動態合併儲存格
                    var breakpoint;
                    if ($(this).hasClass('phone')) breakpoint = 'phone';
                    else if ($(this).hasClass('tablet')) breakpoint = 'tablet';
                    else breakpoint = 'default';

                    if (breakpoint == 'phone') {
                        $("td[class^='rowSP_Ctrl_']").removeAttr('rowspan');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '4');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '6');
                        $('.rowSP_Ctrl_0_2_2').attr('rowspan', '2');
                        $('.rowSP_Ctrl_0_0_2').attr('rowspan', '2');
                        $('.set-title-L-min-width-class').css("min-width", parseInt($('.container').css("width")) / 5 + "px");
                        $('.set-title-R-min-width-class').css("min-width", parseInt($('.container').css("width")) / 2 + "px");
                        $('.practice-date').css('float', 'left').css('margin-left', '20px');
                    }
                    else if (breakpoint == 'tablet') {
                        $("td[class^='rowSP_Ctrl_']").removeAttr('rowspan');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '4');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '6');
                        $('.rowSP_Ctrl_0_2_2').attr('rowspan', '2');
                        $('.rowSP_Ctrl_0_0_2').removeAttr('rowspan');
                        $('.set-title-L-min-width-class').css("min-width", parseInt($('.container').css("width")) / 5 + "px");
                        $('.set-title-R-min-width-class').css("min-width", parseInt($('.container').css("width")) / 2 + "px");
                        $('.practice-date').removeAttr('style');
                    }
                    else if (breakpoint == 'default') {
                        $("td[class^='rowSP_Ctrl_']").removeAttr('rowspan');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '2');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '3');
                        $('.rowSP_Ctrl_0_0_2').removeAttr('rowspan');
                        $('.practice-date').removeAttr('style');

                        //線條
                        $(".footable-row-detail").hide();
                    }

                    // 停用 Row Toggle 功能
                    $('.footable tr').off();
                    $('.footable td').off();
                    $('.title_sp').attr('rowspan', '2');
                });
                // Trigger Event
                $('.footable').trigger('footable_breakpoint');

                //去footable上面多的線&下面多的線
                footableHideNodataBottom();

                //小數尾去0
                removeTableDoubleZero();
            }
            if (controller == 'gold') {
                // Bind
                $('.footable').bind('footable_breakpoint', function (e) {
                    $("td[class^='rowSP_Ctrl_']").removeAttr('rowspan');
                    $(".rowSP_Ctrl_hidden").show();
                    // 展開所有表格內容
                    $(this).trigger('footable_expand_all');
                    // 依事件動態合併儲存格
                    var breakpoint;
                    if ($(this).hasClass('phone'))
                        breakpoint = 'phone';
                    else if ($(this).hasClass('tablet'))
                        breakpoint = 'tablet';
                    else breakpoint = 'default';
                    if (breakpoint == 'phone') {
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '4');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '6');
                        $('.rowSP_Ctrl_0_2_2').attr('rowspan', '2');
                        $('.rowSP_Ctrl_0_0_2').attr('rowspan', '2');
                    }
                    else if (breakpoint == 'tablet') {
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '4');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '6');
                        $('.rowSP_Ctrl_0_2_2').attr('rowspan', '2');
                        $('.rowSP_Ctrl_0_2_2').remove
                    }
                    else if (breakpoint == 'default') {
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '2');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '3');
                        //線條
                        $(".footable-row-detail").hide();
                    }

                    // 停用 Row Toggle 功能
                    window.setTimeout(function () {
                        footable_off();
                    }, 1000);

                    //去footable上面多的線&下面多的線
                    footableHideNodataBottom();

                    $(".rowSP_Ctrl_hidden").hide();
                    $('.title_sp').attr('rowspan', '2').attr('colspan', '2');

                    var all_width = $(".container").width();
                    if (all_width > 414) {
                        $('.set-title-L').css("width", all_width * 0.4 + "px");
                        $('.set-title-R').css("width", all_width * 0.6 + "px");
                        $('.set-title-L-min-width-class').css("width", all_width * 0.2 + "px");
                        $('.set-title-R-min-width-class').css("width", all_width * 0.2 + "px");
                    } else {
                        $('.set-title-L').css("width", all_width * 0.3 + "px");
                        $('.set-title-R').css("width", all_width * 0.7 + "px");
                        $('.set-title-L-min-width-class').css("width", all_width * 0.15 + "px");
                        $('.set-title-R-min-width-class').css("width", all_width * 0.15 + "px");
                    }

                    $('.set-title-L-min-width-class').css("min-width", "82px");
                    $('.set-title-R-min-width-class').css("min-width", "82px");
                });
                // Trigger Event
                $('.footable').trigger('footable_breakpoint');

                //resize時改變欄寬
                $('.footable').bind('footable_resize', function (e) {
                    var all_width = $(".container").width();

                    if (all_width > 414) {
                        $('.set-title-L').css("width", all_width * 0.4 + "px");
                        $('.set-title-R').css("width", all_width * 0.6 + "px");
                        $('.set-title-L-min-width-class').css("width", all_width * 0.2 + "px");
                        $('.set-title-R-min-width-class').css("width", all_width * 0.2 + "px");
                    } else {
                        $('.set-title-L').css("width", all_width * 0.3 + "px");
                        $('.set-title-R').css("width", all_width * 0.7 + "px");
                        $('.set-title-L-min-width-class').css("width", all_width * 0.15 + "px");
                        $('.set-title-R-min-width-class').css("width", all_width * 0.15 + "px");
                    }

                    $('.set-title-L-min-width-class').css("min-width", "85px");
                    $('.set-title-R-min-width-class').css("min-width", "85px");

                    //去footable上面多的線&下面多的線
                    footableHideNodataBottom();
                });
            }
            if (controller == 'twd') {
                // Bind
                $('.footable').bind('footable_breakpoint', function (e) {
                    $("td[class^='rowSP_Ctrl_']").removeAttr('rowspan');
                    $(".rowSP_Ctrl_hidden").show();
                    // 展開所有表格內容
                    $('.footable').trigger('footable_expand_all');
                    // 依事件動態合併儲存格
                    var breakpoint;
                    if ($(this).hasClass('phone')) breakpoint = 'phone';
                    else if ($(this).hasClass('tablet')) breakpoint = 'tablet';
                    else breakpoint = 'default';

                    if (breakpoint == 'phone') {
                        $('.rowSP_Ctrl_0_2_2').attr('rowspan', '2');
                        $('.rowSP_Ctrl_6_12_12').attr('rowspan', '12');
                        $('.rowSP_Ctrl_5_10_10').attr('rowspan', '10');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '4');
                        $('.rowSP_Ctrl_14_28_28').attr('rowspan', '28');
                    }
                    else if (breakpoint == 'tablet') {
                        $('.rowSP_Ctrl_0_2_2').attr('rowspan', '2');
                        $('.rowSP_Ctrl_6_12_12').attr('rowspan', '12');
                        $('.rowSP_Ctrl_5_10_10').attr('rowspan', '10');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '4');
                        $('.rowSP_Ctrl_14_28_28').attr('rowspan', '28');
                    }
                    else if (breakpoint == 'default') {
                        $('.rowSP_Ctrl_6_12_12').attr('rowspan', '6');
                        $('.rowSP_Ctrl_5_10_10').attr('rowspan', '5');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '2');
                        $('.rowSP_Ctrl_14_28_28').attr('rowspan', '14');

                        //線條
                        $(".footable-row-detail").hide();
                    }

                    if (getBreakPointType_5types(container_width) == "phone") {
                        if ("zh-TW" != "en-US") {
                            $('.set-title-L-min-width-class').css("width", "48px");
                        }
                        else {
                            $('.set-title-L-min-width-class').css("width", "90px");
                        }
                    } else if (getBreakPointType_5types(container_width) == 'tablet') {
                        $('.set-title-L-min-width-class').css("max-width", "200px");
                        $('.set-title-L-min-width-class').css("min-width", "100px");
                    } else {
                        $('.set-title-L-min-width-class').css("max-width", "200px");
                        $('.set-title-L-min-width-class').css("min-width", "110px");
                    }

                    //去footable上面多的線&下面多的線
                    footableHideNodataBottom();

                    // 停用 Row Toggle 功能
                    window.setTimeout(function () {
                        footable_off();
                    }, 1000);
                    $('.title_sp').attr('rowspan', '2');
                    $(".rowSP_Ctrl_hidden").hide();
                });

                // Trigger Event
                $('.footable').trigger('footable_breakpoint');

                //resize時改變欄寬
                $('.footable').bind('footable_resize', function (e) {
                    $('.set-title-L-min-width-class').css("width", "");
                    $('.set-title-L-min-width-class').css("max-width", "");
                    $('.set-title-L-min-width-class').css("min-width", "");

                    if (getBreakPointType_5types(container_width) == "phone") {
                        if ("zh-TW" != "en-US") {
                            $('.set-title-L-min-width-class').css("width", "48px");
                        }
                        else {
                            $('.set-title-L-min-width-class').css("width", "90px");
                        }
                    } else if (getBreakPointType_5types(container_width) == 'tablet') {
                        $('.set-title-L-min-width-class').css("max-width", "200px");
                        $('.set-title-L-min-width-class').css("min-width", "100px");
                    } else {
                        $('.set-title-L-min-width-class').css("max-width", "200px");
                        $('.set-title-L-min-width-class').css("min-width", "110px");
                    }

                    //去footable上面多的線&下面多的線
                    footableHideNodataBottom();
                });
                // 網銀按鈕

            }
            if (controller == 'xrt') {
                $('.footable').bind('footable_breakpoint', function (e) {
                    // 展開所有表格內容
                    $(this).trigger('footable_expand_all');
                    // 依事件動態合併儲存格
                    var breakpoint;
                    if ($(this).hasClass('phone'))
                        breakpoint = 'phone';
                    else if ($(this).hasClass('tablet'))
                        breakpoint = 'tablet';
                    else breakpoint = 'default';
                    if (breakpoint == 'phone') {
                        $("td[class^='rowSP_Ctrl_']").removeAttr('rowspan');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '4');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '6');
                        $('.rowSP_Ctrl_0_2_2').attr('rowspan', '2');
                        $('.rowSP_Ctrl_0_0_2').attr('rowspan', '2');
                    }
                    else if (breakpoint == 'tablet') {
                        $("td[class^='rowSP_Ctrl_']").removeAttr('rowspan');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '4');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '6');
                        $('.rowSP_Ctrl_0_2_2').attr('rowspan', '2');
                        $('.rowSP_Ctrl_0_2_2').remove
                    }
                    else if (breakpoint == 'default') {
                        $("td[class^='rowSP_Ctrl_']").removeAttr('rowspan');
                        $('.rowSP_Ctrl_2_4_4').attr('rowspan', '2');
                        $('.rowSP_Ctrl_3_6_6').attr('rowspan', '3');

                        //線條
                        $(".footable-row-detail").hide();
                    }

                    // 停用 Row Toggle 功能
                    window.setTimeout(function () {
                        footable_off();
                    }, 1000);
                });

                $('.rowSP_Ctrl_2_2_2').attr('rowspan', '2');

                // Trigger Event
                $('.footable').trigger('footable_breakpoint');

                var all_width = $(".container").width();
                if (all_width < 720) {
                    //$("thead > tr > th").first().css("background-color", "black");
                    $("thead > tr > th").css("width", all_width * 0.2 + "px");
                }
                hideTableTh();

                //xrt/obuhx查詢畫面title等高判定
                setFormTitleHigh();

                //小數尾去0
                removeTableDoubleZero();
            }

            if (controller == 'home') {
                $('.footable').trigger('footable_expand_all');
            }

            if (controller == 'cr') {
                //cr/手機版rwd表格高調整
                setTableTitleHigh();
            }

            if (controller == 'use') {
                //use/手機版rwd表格高調整
                setTableTitleHigh();
            }

            $('.footable').footable({
                addRowToggle: false
            });
            flag = false;

            // 查詢功能
            // 單一幣別歷史匯率查詢
            $("#single").on("click", function (e) {
                var action = 'Index';
                var url = action == 'history' ? '/xrt/quote' : '/xrt/obuquote';
                var range = $('input[name="search_range"]:checked').val();
                //查詢範圍限前一年度起至最近營業日
                if (range == 'month') {
                    var Today = new Date();
                    if ($('select[name=year]').val() > Today.getFullYear() || ($('select[name=year]').val() >= Today.getFullYear() && $('select[name=month]').val().replace(/\b(0+)/gi, "") > parseInt(Today.getMonth()) + 1)) {
                        if ("".toLowerCase() == "true") {
                            switch ("zh-TW") {
                                case "en-US":
                                    alert("The range of specified year-month must be within last 3 year.");
                                    break;
                                case "zh-TW":
                                    alert("指定年月有效範圍為最近三年之內。");
                                    break;
                                case "zh-CN":
                                    alert("指定年月有效范??最近三年之?。");
                                    break;
                            }
                        } else {
                            switch ("zh-TW") {
                                case "en-US":
                                    alert("Inquiry Period starts from previous year to the last business day.");
                                    break;
                                case "zh-TW":
                                    alert("查詢範圍限前一年度起至最近營業日。");
                                    break;
                                case "zh-CN":
                                    alert("查?范?限前一年度起至最近??日。");
                                    break;
                            }
                        }
                        return false;
                    }
                }

                var cur = $('select[name=currency]').val();
                var hours = $('input[name="search_hours"]:checked').val();
                var type = $('input[name="rate_type"]:checked').val();
                if ($('input[name=obu]').val() == 1) type = "spot";
                var compare = $('select[name=compare]').is(':enabled') ? $('select[name=compare]').val() : "";
                // 查詢期間
                if (range == 'day' || range == 'ltm' || range == 'l6m' || range == 'l1y' || range == 'l3y') url += ("/" + range);
                if (range == 'month') url += ("/" + $('select[name=year]').val() + "-" + $('select[name=month]').val());
                // 查詢幣別
                url += '/' + (cur ? cur : 'USD');
                url += compare ? "-" + compare : "";
                if (hours == '1') {
                    url += '/' + type + '/1';
                } else {
                    if (type == 'cash') url += '/cash';
                }
                $(this).attr('href', url);
            });

            // 全部幣別歷史匯率查詢
            $("#all").on("click", function (e) {
                var url = '/xrt/all';
                var range = $('input[name="all_range"]:checked').val();
                var day = $('select[name=all_day]').val();
                // 查詢期間
                if (range == 'day') url += ("/" + range);
                //查詢範圍限前一年度起至最近營業日
                if (range == 'date') {
                    if (!CheckDate($('select[name=all_year]').val() + "/" + $('select[name=all_month]').val().replace(/\b(0+)/gi, "") + "/" + $('select[name=all_day]').val().replace(/\b(0+)/gi, ""))) {
                        switch ("zh-TW") {
                            case "en-US":
                                alert("The historical data is not valid.");
                                break;
                            case "zh-TW":
                                alert("您輸入的歷史資料日期不是一個有效值。");
                                break;
                            case "zh-CN":
                                alert("您?入的?史?据日期不是一?有效值。");
                                break;
                        }
                        return false;
                    }
                    var Today = new Date();
                    if ($('select[name=all_year]').val() > Today.getFullYear() ||
                        ($('select[name=all_year]').val() >= Today.getFullYear() && $('select[name=all_month]').val().replace(/\b(0+)/gi, "") > (parseInt(Today.getMonth()) + 1)) ||
                        ($('select[name=all_year]').val() >= Today.getFullYear() && $('select[name=all_month]').val().replace(/\b(0+)/gi, "") >= (parseInt(Today.getMonth()) + 1) && $('select[name=all_day]').val().replace(/\b(0+)/gi, "") > (parseInt(Today.getDate()))) ||
                        $('select[name=all_year]').val() < Today.getFullYear() - 3 ||
                        ($('select[name=all_year]').val() <= Today.getFullYear() - 3 && $('select[name=all_month]').val().replace(/\b(0+)/gi, "") < (parseInt(Today.getMonth()) + 1)) ||
                        ($('select[name=all_year]').val() <= Today.getFullYear() - 3 && $('select[name=all_month]').val().replace(/\b(0+)/gi, "") <= (parseInt(Today.getMonth()) + 1) && $('select[name=all_day]').val().replace(/\b(0+)/gi, "") < (parseInt(Today.getDate())))) {
                        if ("".toLowerCase() == "true") {
                            switch ("zh-TW") {
                                case "en-US":
                                    alert("The range of specified year-month must be within last 3 year.");
                                    break;
                                case "zh-TW":
                                    alert("指定日期有效範圍為最近三年之內。");
                                    break;
                                case "zh-CN":
                                    alert("指定日期有效范??最近三年之?。");
                                    break;
                            }
                        } else {
                            switch ("zh-TW") {
                                case "en-US":
                                    alert("Inquiry period starts from previous year to the last business day which Closing Rate had been produced.");
                                    break;
                                case "zh-TW":
                                    alert("查詢範圍限前一年度起至最近一個已產生收盤價之營業日。");
                                    break;
                                case "zh-CN":
                                    alert("查?范?限前一年度起至最近一?已?生收?价之??日。");
                                    break;
                            }
                        }
                        return false;
                    }
                }

                if (range == 'date') url += ("/" + $('select[name=all_year]').val() + "-" + $('select[name=all_month]').val() + "-" + day);
                if ($('input[name=obu]').val() == 1) url += '/1';

                $(this).attr('href', url);
            });
            $("#systemdate").change(function (e) {
                var r = /^-[0-9]*[1-9][0-9]*$/;
                if (r.test(getUrlVars()["backtimes"])) {
                    backtimes = parseInt(getUrlVars()["backtimes"]) - 1;
                } else {
                    backtimes = -1;
                }
                self.location.href = '//' + encodeURI(location.host + location.pathname) + "?sysdate=" + $('select[name=sysdate]').val() + "&backtimes=" + (backtimes);
            });

            //最近一個營業日不可比較幣別，比較幣別為空時不顯示現金&即期
            $('input:radio[name="search_range"]').change(function () {
                //最近一個營業日不可比較幣別，比較幣別為空時不顯示現金&即期
                search_range_check($('input:radio:checked[name="search_range"]'));
            });

            if ($("#ltm").is(":checked") || $("#month").is(":checked"))
                $('select[name=compare]').prop('disabled', false);

            // 匯率種類控制
            $('select[name=compare]').change(function () {
                if ($(this).val()) {
                    $('#datatype').show();
                } else {
                    $('#datatype').hide();
                }
            });
            if ($('select[name=compare]').val()) { $('#datatype').show(); } else { $('#datatype').hide(); }

            // 外幣結帳價格表查詢
            $("#cr").on("click", function (e) {
                var Today = new Date();
                if ($('select[name=year]').val() > Today.getFullYear() ||
                    ($('select[name=year]').val() >= Today.getFullYear() && $('select[name=month]').val().replace(/\b(0+)/gi, "") > (parseInt(Today.getMonth()) + 1))) {
                    if (controller == 'ir') {
                        switch ("zh-TW") {
                            case "en-US":
                                alert("The historical data must be less than or equal to today.");
                                break;
                            case "zh-TW":
                                alert("歷史資料日期不可大於今天。");
                                break;
                            case "zh-CN":
                                alert("?史?料日期不可大于今天。");
                                break;
                        }
                    }
                    else {
                        switch ("zh-TW") {
                            case "en-US":
                                alert("The selected query date is not date of history data, please select it again");
                                break;
                            case "zh-TW":
                                alert("你輸入之查詢日期非為歷史資料日期");
                                break;
                            case "zh-CN":
                                alert("您?入之查?日期非??史?据日期");
                                break;
                        }
                    }
                    return;
                }

                var url = '/cr';
                url += ("/" + $('select[name=year]').val() + "-" + $('select[name=month]').val());
                $(this).attr('href', url);
            });

            // 歷史外匯存款牌告利率查詢 / 新臺幣存(放)款牌告利率查詢
            $("#ir").on("click", function (e) {
                //檢查輸入的日期是否是一個正確的日期格式
                if ($('select[name=day]').val() != "") {
                    if (!CheckDate($('select[name=year]').val() + "/" + $('select[name=month]').val().replace(/\b(0+)/gi, "") + "/" + $('select[name=day]').val().replace(/\b(0+)/gi, ""))) {
                        if (controller == 'ir') {

                            switch ("zh-TW") {
                                case "en-US":
                                    alert("The historical data is not valid.");
                                    break;
                                case "zh-TW":
                                    alert("您輸入的歷史資料日期不是一個有效值。");
                                    break;
                                case "zh-CN":
                                    alert("您?入的?史?据日期不是一?有效值。");
                                    break;
                            }
                        }
                        else {
                            switch ("zh-TW") {
                                case "en-US":
                                    alert("History data query input error");
                                    break;
                                case "zh-TW":
                                    alert("歷史資料查詢輸入錯誤。");
                                    break;
                                case "zh-CN":
                                    alert("?史?据查??入??。");
                                    break;
                            }
                        }
                        return;
                    }
                }
                // 查詢範圍限前一年度起至最近營業日
                var Today = new Date();
                if ($('select[name=year]').val() > Today.getFullYear() ||
                    ($('select[name=year]').val() >= Today.getFullYear() && $('select[name=month]').val().replace(/\b(0+)/gi, "") > (parseInt(Today.getMonth()) + 1)) ||
                    ($('select[name=year]').val() >= Today.getFullYear() && $('select[name=month]').val().replace(/\b(0+)/gi, "") >= (parseInt(Today.getMonth()) + 1) && $('select[name=day]').val().replace(/\b(0+)/gi, "") > (parseInt(Today.getDate())))) {
                    if (controller == 'ir') {
                        switch ("zh-TW") {
                            case "en-US":
                                alert("The historical data must be less than or equal to today.");
                                break;
                            case "zh-TW":
                                alert("歷史資料日期不可大於今天。");
                                break;
                            case "zh-CN":
                                alert("?史?料日期不可大于今天。");
                                break;
                        }
                    }
                    else {
                        switch ("zh-TW") {
                            case "en-US":
                                alert("The selected query date is not date of history data, please select it again");
                                break;
                            case "zh-TW":
                                alert("你輸入之查詢日期非為歷史資料日期");
                                break;
                            case "zh-CN":
                                alert("您?入之查?日期非??史?据日期");
                                break;
                        }
                    }
                    return;
                } else if (controller == "twd") {
                    //twd在1998-7-7前沒有值
                    if ($('select[name=year]').val() < 1988 ||
                    ($('select[name=year]').val() <= 1988 && $('select[name=month]').val().replace(/\b(0+)/gi, "") < (7)) ||
                        ($('select[name=year]').val() <= 1988 && $('select[name=month]').val().replace(/\b(0+)/gi, "") <= (7) && $('select[name=day]').val().replace(/\b(0+)/gi, "") < (7))) {
                        alert("無此歷史資料日期牌告利率可供查詢");
                        return;
                    }
                }

                var action = 'index';
                var url = "";
                if (controller == 'ir') {
                    url = action == 'index' ? '/ir/index' : '/ir/obu';
                } else {
                    url = '/twd';
                }
                url += ("/" + $('select[name=year]').val() + "-" + $('select[name=month]').val() + "-" + $('select[name=day]').val());
                $(this).attr('href', url);
            });

            // 歷史黃金牌價查詢
            $("#gold").on("click", function (e) {
                var range = $('input[name="search_range"]:checked').val();
                //查詢範圍限前一年度起至最近營業日
                if (range == 'date') {
                    var Today = new Date();
                    if (!CheckDate($('select[name=year]').val() + "/" + $('select[name=month]').val().replace(/\b(0+)/gi, "") + "/" + $('select[name=day]').val().replace(/\b(0+)/gi, ""))) {
                        switch ("zh-TW") {
                            case "en-US":
                                alert("The specified date is not valid.");
                                break;
                            case "zh-TW":
                                alert("指定日期是一個無效值。");
                                break;
                            case "zh-CN":
                                alert("指定日期是一??效值。");
                                break;
                        }
                        return;
                    }
                    if ($('select[name=year]').val() > Today.getFullYear() ||
                    ($('select[name=year]').val() >= Today.getFullYear() && $('select[name=month]').val().replace(/\b(0+)/gi, "") > (parseInt(Today.getMonth()) + 1)) ||
                    ($('select[name=year]').val() >= Today.getFullYear() && $('select[name=month]').val().replace(/\b(0+)/gi, "") >= (parseInt(Today.getMonth()) + 1) && $('select[name=day]').val().replace(/\b(0+)/gi, "") > (parseInt(Today.getDate())))) {
                        switch ("zh-TW") {
                            case "en-US":
                                alert("The historical data is not valid.");
                                break;
                            case "zh-TW":
                                alert("您輸入的歷史資料日期不是一個有效值。");
                                break;
                            case "zh-CN":
                                alert("您?入的?史?据日期不是一?有效值。");
                                break;
                        }
                        return;
                    }
                }
                var url = '/gold/quote';
                // 查詢期間
                if (range == 'recent' || range == 'preceding') url += ("/" + range);
                if (range == 'date') url += ("/" + $('select[name=year]').val() + "-" + $('select[name=month]').val() + "-" + $('select[name=day]').val());
                $(this).attr('href', url);
            });
            // 歷史黃金存摺牌價查詢
            $("#passbook").on("click", function (e) {
                // 基本變數
                var url = '/gold/chart';
                var range = $('input[name="search_range"]:checked').val();
                var cur = $('select[name=currency]').val();
                var hours = $('input[name="search_hours"]:checked').val();
                //查詢範圍限前一年度起至最近營業日
                var Today = new Date();
                if ($('select[name=year]').val() > Today.getFullYear() ||
                    ($('select[name=year]').val() >= Today.getFullYear() && $('select[name=month]').val().replace(/\b(0+)/gi, "") > (parseInt(Today.getMonth()) + 1))) {
                    if (range == "date") {
                        if ("".toLowerCase() == "true") {
                            switch ("zh-TW") {
                                case "en-US":
                                    alert("The range of specified year-month must be within last 3 year.");
                                    break;
                                case "zh-TW":
                                    alert("指定年月有效範圍為最近三年之內。");
                                    break;
                                case "zh-CN":
                                    alert("指定年月有效范??最近三年之?。");
                                    break;
                            }
                        } else {
                            switch ("zh-TW") {
                                case "en-US":
                                    alert("The range of specified year-month must be within last 1 year.");
                                    break;
                                case "zh-TW":
                                    alert("指定年月有效範圍為最近一年之內。");
                                    break;
                                case "zh-CN":
                                    alert("指定年月有效范??最近一年之?。");
                                    break;
                            }
                        }
                        return;
                    }
                }

                // 查詢期間
                if (range == 'day' || range == 'ltm' || range == 'half' || range == 'year' || range == 'l3y') url += ("/" + range);
                if (range == 'date') url += ("/" + $('select[name=year]').val() + "-" + $('select[name=month]').val());
                // 查詢幣別
                url += '/' + (cur ? cur : 'USD');
                // 查詢項目
                if (hours == '1') {
                    url += '/1';
                }
                $(this).attr('href', url);
            });
            $("#bias").on("click", function (e) {
                var url = '/bias/chart';
                var range = $('input[name="date"]:checked').val();
                $(this).attr('href', url + "/" + range);
            });

            //RWD加入千分位
            tableAddCommafy();

            $(".footable-row-detail-value").each(function () {
                var td = $(this).text();
                if (!isNaN(td)) {
                    if (td.split(".").length == 1) {
                        $(this).text(commafy(td));
                    } else if (td.split(".").length == 2) {
                        //小數部份不用加千分位
                        $(this).text(commafy(td.split(".")[0]) + "." + td.split(".")[1]);
                    }
                }
            })

            //多語系下拉顯示文字(依現行語系顯示)
            //電腦版下拉
            $('#lang_ddl')
                .find('option')
                .filter(function () {
                    return this.value == "zh-TW";
                })
                .prop('selected', true);

            //手機版下拉
            switch ("zh-TW") {
                case "en-US":
                    $("#lang_ddl_phone").html("En");
                    break;
                case "zh-TW":
                    $("#lang_ddl_phone").html("中");
                    break;
                case "zh-CN":
                    $("#lang_ddl_phone").html("?");
                    break;
            }

            //電腦版多語系
            $("#lang_ddl").change(function () {
                ChangeLanguage($(this).val());
            })

            //手機版多語系
            $(".lang_ddl_css").click(function () {
                ChangeLanguage($(this).data("value"));
            })

            $(".click_print").on("click", function (e) {
                if (!-[1, ]) {
                    //IE8
                    //wb.execwb(7, 1);
                    if (location.search == "") {
                        window.open(encodeURI(location.pathname) + "?page=print", 'Print');
                    } else {
                        setPrintStyle();
                    }
                }
                else {
                    if (detectBrowser() == "IE") {
                        //IE9~11
                        //wb.execwb(7, 1);
                        if (location.search == "") {
                            window.open(encodeURI(location.pathname) + "?page=print&", 'Print');
                        } else {
                            setPrintStyle();
                        }
                    }
                    else if (detectBrowser() == "Firefox") {
                        //Firefox
                        //window.print();
                        if (location.search == "") {
                            window.open(encodeURI(location.pathname) + "?page=print", 'Print');
                        } else {
                            setPrintStyle();
                        }
                    }
                    else {
                        window.print();
                    }
                }
            });
            $(".doPrintBtn").on("click", function () {
                window.print();
            })
            $(".doCloseBtn").on("click", function () {
                window.close();
            })

            //判斷列印頁 & 加上列印style
            var location_search = location.search;
            if (location_search.split("page=print").length > 1) {
                setPrintStyle();
            }

            var backtimes = -1;
            //自定上一頁
            $(".click_back").on("click", function (e) {
                var r = /^-[0-9]*[1-9][0-9]*$/;
                if (r.test(getUrlVars()["backtimes"])) {
                    backtimes = parseInt(getUrlVars()["backtimes"]) - 1;
                } else {
                    backtimes = -1;
                }
                window.history.go(backtimes);
                return false;
            });

            $(".click_back_times").on("click", function (e) {
            });

            $(".click_close").on("click", function (e) {
                window.close();
            });

            //class多語系顯示控制
            $(".zh-TW_show").hide();
            switch ("zh-TW") {
                case "en-US":
                    $(".zh-TW_show").hide();
                    $(".zh-CN_show").hide();
                    $(".en-US_show").show();
                    break;
                case "zh-TW":
                    $(".zh-CN_show").hide();
                    $(".en-US_show").hide();
                    $(".zh-TW_show").show();
                    break;
                case "zh-CN":
                    $(".zh-TW_show").hide();
                    $(".en-US_show").hide();
                    $(".zh-CN_show").show();
                    break;
            }

            //比較幣別 防呆xrt/history xrt/obuhx 不可比較自己
            onCurrencySelectChange();

            //補history查詢lable改div後點文字無法自動選擇
            //單一幣別
            $(".click_select_month").click(function () {
                $("#month").prop("checked", true);
                //最近一個營業日不可比較幣別，比較幣別為空時不顯示現金&即期
                search_range_check($('input:radio:checked[name="search_range"]'));
            })
            //比較幣別
            $(".click_select_date").click(function () {
                $("#input_date").prop("checked", true);
            })

            //右上角切換語言鍵，改為點選開關
            $("#lang_ddl_phone").click(function () {
                //alert($(".dropdown-content").css("display"));
                if ($(".dropdown-content").css("display") == "none") {
                    $(".dropdown-content").show();
                    $(this).css("background-color", "white");
                    $(this).css("color", "#8a0050");
                } else {
                    $(".dropdown-content").hide();
                    $(this).css("background-color", "black");
                    $(this).css("color", "white");
                }
            })

            //footable 展開所有表格內容
            $(".click_ExpandAll").click(function () {
                $('.footable').trigger('footable_expand_all');
            })

            //footable 關閉所有fsear表格內容
            $(".click_CollapseAll").click(function () {
                $('.footable').trigger('footable_collapse_all');
            })

            //取得最新xx
            $(".click_reload").on("click", function (e) {
                location.reload();
            });
            
        });

        $(window).load(function () {
            //最近一個營業日不可比較幣別，比較幣別為空時不顯示現金&即期(for chrome)
            search_range_check($('input:radio:checked[name="search_range"]'));
            //alert("load");
        })
    </script>  
 </body>
</html>
```
