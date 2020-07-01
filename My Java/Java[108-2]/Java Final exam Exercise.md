# [中階]
```
package myHtml;

public class MyHtmlProcess {
	private String url;

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}
}

--------------------------------------------------------------------

package myHtml;

public class MyHtmlProcessTest {

	public static void main(String[] args) {
		MyHtmlProcess obj = new MyHtmlProcess();
		
		String url = "https://elearning2.ksu.edu.tw/learn/index.php";
		obj.setUrl(url);
		/*obj.setUrl("https://elearning2.ksu.edu.tw/learn/index.php");*/
		
		String url1 = obj.getUrl();
		System.out.println(url1);
		
		System.out.println(obj.getUrl());
	}

}

```
# 顯示結果：
```
https://elearning2.ksu.edu.tw/learn/index.php
https://elearning2.ksu.edu.tw/learn/index.php
```
# [高階]
```
package myJsoupHtml;

import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

public class MyJsoupHtmlParser {

    private String url;

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }
    
    public void downloadHtml() throws IOException, FileNotFoundException {
        //準備寫入檔案的Writer物件 out       
        BufferedWriter out = new BufferedWriter(
                new OutputStreamWriter(
                        new FileOutputStream("./data/BOTrate.html"), "UTF-8"));

        Document doc = Jsoup.connect(url).get();
        
        System.out.println(doc.toString());
        out.write(doc.toString()); 
        out.close();
    }  
}
-------------------------------------------------------------------------------
package myJsoupHtml;

import java.io.IOException;

public class MyJsoupHtmlParserTest {

	public static void main(String[] args) throws IOException, IOException {
		String url = "https://elearning2.ksu.edu.tw/learn/index.php";
		
		MyJsoupHtmlParser obj =new MyJsoupHtmlParser();
		obj.setUrl(url);
		obj.downloadHtml();
	}

}

```
# 顯示結果：
```
<!doctype html>
<html lang="" xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://ogp.me/ns#" xmlns:fb="http://www.facebook.com/2008/fbml"> 
 <head> 
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8"> 
  <meta http-equiv="X-UA-Compatible" content="IE=11"> 
  <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"> <!-- 把 charset 的 meta tag 調到最前面 --> <!-- fb --> 
  <meta name="title" content="崑山網路大學"> 
  <meta name="description" property="og:description" content="旭聯科技-15年線上學習專家．50%政府單位佔有率．80%大專院校佔有率．給你最專業、最便利、最多元的線上教學課程。"> 
  <meta property="og:site_name" content="崑山網路大學"> 
  <meta property="og:type" content="website"> 
  <meta property="og:title" content="崑山網路大學"> 
  <meta property="og:url" content="https://elearning2.ksu.edu.tw"> 
  <meta property="og:image" content="https://elearning2.ksu.edu.tw/base/10001/door/tpl/logo.png"> 
  <meta property="og:description" content="旭聯科技-15年線上學習專家．50%政府單位佔有率．80%大專院校佔有率．給你最專業、最便利、最多元的線上教學課程。"> 
  <link href="https://elearning2.ksu.edu.tw/base/10001/door/tpl/logo.png" rel="image_src" type="image/jpeg"> <!-- twitter --> 
  <meta name="twitter:card" content="summary"> 
  <meta name="twitter:title" content="崑山網路大學"> 
  <meta name="twitter:description" content="旭聯科技-15年線上學習專家．50%政府單位佔有率．80%大專院校佔有率．給你最專業、最便利、最多元的線上教學課程。"> 
  <meta name="twitter:url" content="https://elearning2.ksu.edu.tw"> 
  <meta name="twitter:image:src" content="https://elearning2.ksu.edu.tw/base/10001/door/tpl/logo.png"> 
  <title>崑山網路大學 </title> 
  <link href="/theme/default/bootstrap336/css/bootstrap.min.css" rel="stylesheet"> 
  <link rel="stylesheet" href="/sys/tpl/vendor/font-awesome/css/font-awesome.css"> 
  <link rel="stylesheet" href="/sys/tpl/css/theme.css"> 
  <link href="/public/css/application.css?feab05aa" rel="stylesheet"> 
  <link href="/theme/default/fancybox/jquery.fancybox.css" rel="stylesheet" type="text/css" media="screen"> 
  <link rel="stylesheet" href="/lib/jquery/jquery.mSimpleSlidebox.css"> 
  <link rel="icon" href="/base/10001/door/tpl/icon.ico"> 
  <link href="/public/css/common.css?feab05aa" rel="stylesheet"> 
  <link href="https://elearning2.ksu.edu.tw/public/css/orange/index1.css?feab05aa" rel="stylesheet"> 
  <script type="text/javascript" src="/lib/modernizr/modernizr.min.js"></script> 
  <script type="text/javascript" src="/lib/jquery/jquery.new.min.js"></script> 
  <script type="text/javascript" src="/theme/default/bootstrap336/js/bootstrap.min.js"></script> 
  <script type="text/javascript" src="/theme/default/fancybox/jquery.fancybox.pack.js"></script> 
  <script type="text/javascript" src="/lib/jquery/jquery.mSimpleSlidebox.js"></script> 
  <script type="text/javascript" src="/public/js/third_party/jquery-placeholder/jquery.placeholder.js"></script> 
  <script type="text/javascript" src="/public/js/third_party/jquery-message-box/messagebox.min.js"></script> 
  <script type="text/javascript" src="/public/js/third_party/bootbox/bootbox.min.js"></script> 
  <script type="text/javascript" src="/lib/jquery/jquery.cookie.js"></script> 
  <script type="text/javascript">
        var appRoot = 'https://elearning2.ksu.edu.tw',
            portalUrl = 'SYS_PORTAL_HOME_URL',
            generalDomain = 'elearning2.ksu.edu.tw',
            metaTitle = '崑山網路大學',
            metaDescription = '旭聯科技-15年線上學習專家．50%政府單位佔有率．80%大專院校佔有率．給你最專業、最便利、最多元的線上教學課程。',
            isPhoneDevice = '';
    </script> 
 </head> 
 <body> 
  <link href="/public/css/school.css" rel="stylesheet"> 
  <style>
        .container {
            height: auto !important;
        }

        #site_header {
            width: 100%;
            margin: auto;
        }

        #site_header_content {
            max-width: 1080px;
            width: 1080px;
            margin: auto;
        }

        .siteLogo {
            height: 50px;
        }

        #search_course_keyword{
            width: 338px;
            height: 36px;
            font-size: 15px;
            margin-top: 15px;
            -webkit-border-radius: 5px 0px 0px 5px;
            -moz-border-radius: 5px 0px 0px 5px;
            border-radius: 5px 0px 0px 5px;
            border: 1px solid #ccc;
            border-style: solid none solid solid;
        }

        #btn_search {
            height: 36px;
            margin-left: -10px;
            margin-bottom: 3px;
            -webkit-border-radius: 0px 5px 5px 0px;
            -moz-border-radius: 0px 5px 5px 0px;
            border-radius: 0px 5px 5px 0px;
        }

        .navbar-nav-item-background {
            border-radius: 30px;
            width: 110px;
            background: rgba(100%,100%,100%,0.3);
        }

        .nav .open>a, .nav .open>a:focus, .nav .open>a:hover {
            background-color: transparent;
        }

        .nav>li>a:focus, .nav>li>a:hover {
            background-color: transparent;
        }

        .site_keyword {
            font-size: 14px;
            color: #393939;
            padding-left:5px;
            padding-right:5px;
            cursor: pointer;
        }

        .button_search {
            font-family: "微軟正黑體";
            font-size: 16px;
            color: #fff;
            height: 40px;
            width: 40px;
            border: 1px rgba(255,255,255,0.5) solid;
            border-radius: 3px;
            background-color: rgba(255,255,255,0);
        }

        #div_username {
            padding-right: 0px;
            line-height: 32px;
        }

        .show-username {
            white-space: nowrap;
            overflow: hidden;
            overflow:-moz-hidden-unscrollable;
            text-overflow: ellipsis;
            max-width: 120px;
            font-size:1.2em;
            color:#FFFFFF;
            padding:0px 6px 6px 6px;
            display: inline-flex;
        }
        
        @supports (-webkit-overflow-scrolling: touch) {
            
            .fa-search {
                margin-left:-5px;
            }
            
		    .adjust {
		        margin-left:-7px;
		    }   
		}

        /* desktop */
        @media (min-width: 1320px) {
        }

        .search_box::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
            color: white;
            opacity: 1; /* Firefox */
        }

        .search_box:-ms-input-placeholder { /* Internet Explorer 10-11 */
            color: white;
        }

        .search_box::-ms-input-placeholder { /* Microsoft Edge */
            color: white;
        }
       
        #menu_lang {
            z-index: 1000;
            position: absolute;
            border: 1px solid #ccc;
            border: 1px solid rgba(0,0,0,.15);
            border-radius: 4px;
            background-color: #fff;
            left: 30%;
            margin-top: -10px;
        }

        #menu_lang .lang {
            height: 42px;       
            line-height:42px;
            border-bottom: 1px #E3E3E3 solid;
            font-size: 16px;
            padding:0 25px;
        } 

        /*平板直向、平板橫向*/
        @media (min-width: 768px) and (max-width: 992px) {

        }

        @media (max-width: 767px) {
            #site_header_content {
                width: 100%;
                max-width: 100%;
            }

            .but_login {
                width: initial;
            }

            .but_registered {
                width: initial;
            }

            #search_bar_phone {
                border: 5px solid rgb(5,178,146);
                margin: 0 auto;
                padding-left: 0px;
                background: #ffffff;
            }

            .search_box {
                color: #666666 !important;
                float: left;
            }

            .search_box::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
                color: #666666;
                opacity: 1; /* Firefox */
            }

            .search_box:-ms-input-placeholder { /* Internet Explorer 10-11 */
                color: #666666;
            }

            .search_box::-ms-input-placeholder { /* Microsoft Edge */
                color: #666666;
            }

        }

        /*大手機尺寸*/
        @media (min-width: 375px) and (max-width: 767px) {
            .nav_search {
                height: 50px;
            }

            #site_header_login_bar_phone {
                margin-top: 5px;
            }

            .siteHeaderOuterTable {
                width: 94%;
                height:85px;
            }

            .siteLogo {
                margin-top:0px;
            }

            #site_header {
                width: 100%;
            }

            .search_box {
                min-width: 300px;
            }
        }

        /*手機尺寸*/
        @media (max-width: 374px) {
            .nav_search {
                height: 50px;
            }

            #site_header_login_bar_phone {
                margin-top: 5px;
            }

            .siteHeaderOuterTable {
                width: 90%;
                height:85px;
            }

            .siteLogo {
                margin-top:0px;
            }

            #site_header {
                width: 100%;
            }

            .search_box {
                min-width: 250px;
            }

            #div_username {
                padding-left: 0px;
                padding-right: 0px;
            }

            #imgGotoExplorer {
                max-width: initial;
            }
        }

    </style> 
  <div id="site_header" class="bgBlack"> 
   <nav class="navbar navbar-default navigation-clean-button" style="font-size:18px;margin-bottom: 0px;"> 
    <div class="container" style="min-width: initial;padding-left: 0px; padding-right: 0px;"> 
     <div class="navbar-collapse navbar-left hidden-xs hidden-phone" style="margin-top:5px;"> <a href="/mooc/index.php"><img class="siteLogo" src="/base/10001/door/tpl/logo.png" alt="回首頁" title="回首頁" border="0"></a> 
     </div> 
     <div class="navbar-text navbar-right actions hidden-xs hidden-phone"> 
      <ul class="nav navbar-nav"> 
       <li><a href="javascript:;" onclick="gotoFaqList();">常見問題</a></li> 
       <li><a href="/mooc/download.php">下載專區</a></li> 
       <li><a href="/mooc/co_use.php">平台使用說明</a></li> 
       <li> 
        <div class="collapse navbar-collapse" style="padding-left: 0px;"> 
         <ul class="nav navbar-nav navbar-right"> 
          <li class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" style="width:100px;">正體中文<i class="fa fa-caret-down" aria-hidden="true" style="color:#FFFFFF;margin-left:0.3em;"></i></a>
           <ul class="dropdown-menu">
            <li style="height: 36px;"><a href="?lang=GB2312">?体中文</a></li>
            <li style="height: 36px;"><a href="?lang=en">English</a></li>
           </ul> </li> 
         </ul> 
        </div> </li> 
      </ul> 
     </div> 
     <div class="row visible-xs hidden-tablet hidden-desktop"> 
      <div class="col-xs-9 text-left">
       <a href="/mooc/index.php"><img class="siteLogo" src="/base/10001/door/tpl/logo.png" alt="回首頁" title="回首頁" border="0"></a>
      </div> 
      <div class="col-xs-3 text-center" style="line-height: 50px;"> <i class="fa fa-bars" style="color:#BBBBBB;font-size: 26px;padding-right: 15px;line-height: 50px;" onclick="showPhoneMenu();"></i> 
      </div> 
     </div> 
    </div> 
   </nav> 
  </div> 
  <div class="nav nav_search"> 
   <div class="container" style="min-width: initial;padding-left: 0px; padding-right: 0px;height:60px !important;"> 
    <div id="site_header_login_bar_phone" class="visible-xs hidden-tablet hidden-desktop"> 
     <div class="row col-xs-12"> 
      <div class="col-xs-2 text-left" style="padding-left: 5px;"> <a href="javascript:;" onclick="gotoExplorer();return false;"><img id="imgGotoExplorer" src="/theme/default/learn_mooc/coursesorts.png" width="40" height="40"></a> 
      </div> 
      <div class="col-xs-2 text-left" style="padding-left: 5px;"> <button class="button_search" onclick="showSearchBar();"><i class="fa fa-search" aria-hidden="true" style="font-size:20px;color:#FFFFFF;"></i></button> 
      </div> 
      <div id="div_username" class="col-xs-8 text-right"> 
       <table border="0" cellspacing="0" cellpadding="0" style="float:right;font-size:16px;color:#FFFFFF;"> 
        <tbody>
         <tr> 
          <td class="visible-xs" style="font-size:1em;padding-right:10px;"><input type="button" value="登入" class="but_login" onclick="gotoLogin();"></td> 
         </tr> 
        </tbody>
       </table> 
      </div> 
     </div> 
     <div id="search_bar_phone" class="row col-xs-12" style="display: none;"> 
      <input type="text" id="search_box_phone" value="" class="search_box" placeholder="課程搜尋" onchange="syncSearchBoxVal(this);"> <button class="button_search" onclick="doSearch_course();" style="border-color:#FF720A;width:36px;height: 36px;margin-top:2px;float:right;"><i class="fa fa-search adjust" aria-hidden="true" style="font-size:20px;color:#FF720A;"></i></button> 
     </div> 
    </div> 
    <table border="0" cellpadding="0" cellspacing="0" class="nav_box hidden-xs hidden-phone"> 
     <tbody>
      <tr> 
       <td width="40"><a href="javascript:;" onclick="gotoExplorer();return false;"><img src="/theme/default/learn_mooc/coursesorts.png" width="40" height="40" title="學院類別"></a></td> 
       <td width="20">&nbsp;</td> 
       <td width="80%" style="text-align: left"> <input type="text" id="search_box_pc" value="" class="search_box" style="width:700px;margin-bottom: 2px;" placeholder="課程搜尋" onchange="syncSearchBoxVal(this);"> <button class="button_search" onclick="doSearch_course();"><i class="fa fa-search" aria-hidden="true" style="font-size:20px;color:#FFFFFF;"></i></button> </td> 
       <td width="20"></td> 
       <td><input type="button" value="登入" class="but_login" onclick="gotoLogin();"></td> 
       <td width="10">&nbsp;</td> 
       <td width="20"></td> 
      </tr> 
     </tbody>
    </table> 
   </div> 
  </div> 
  <div id="phoneMenu" style="display:none;"> 
   <table border="0" cellpadding="0" cellspacing="0" width="100%" class="visible-xs"> 
    <tbody>
     <tr>
      <td class="phoneMenuItem"><a href="/learn/news/index_faq.php?da75cd652254fce37e953d7f261f132d">常見問題</a></td>
     </tr> 
     <tr>
      <td class="phoneMenuItem"><a href="/mooc/download.php">下載專區</a></td>
     </tr> 
     <tr>
      <td class="phoneMenuItem"><a href="/mooc/co_use.php">平台使用說明</a></td>
     </tr> 
     <tr>
      <td class="phoneMenuItem">
       <div style="float:left" onclick="showLang();">
        正體中文<i class="fa fa fa-caret-right" aria-hidden="true" style="margin-left:0.3em;"></i>
       </div>
       <div id="menu_lang" style="float:left;display:none">
        <div class="lang">
         <a href="?lang=GB2312">?体中文</a>
        </div>
        <div class="lang">
         <a href="?lang=en">English</a>
        </div>
       </div></td>
     </tr> 
    </tbody>
   </table> 
  </div> 
  <form name="faq_node_list" id="faq_node_list" method="POST" target="faqFrame" style="display: none;"> 
   <input type="hidden" name="token" value="d41d8cd98f00b204e9800998ecf8427e"> 
   <input type="hidden" name="cid"> 
   <input type="hidden" name="bid"> 
   <input type="hidden" name="nid"> 
  </form> 
  <form id="siteHeaderSearchForm" name="siteHeaderSearchForm" action="/mooc/explorer.php" method="post" style="display: none;"> 
   <input type="hidden" name="keyword" value=""> 
  </form> <iframe id="faqFrame" name="faqFrame" src="about:blank" style="display: none;" title="呈現常見問題的框架" height="600" width="100%"></iframe> 
  <script>
    var server_name = 'elearning2.ksu.edu.tw';
    var faq_url = '/learn/news/index_faq.php?da75cd652254fce37e953d7f261f132d';
    
        var isPhoneMenuVisible = false;
        function showPhoneMenu() {
            if ($('#phoneMenu').is(":visible")) {
                $('#phoneMenu').hide();
            } else {
                $('#phoneMenu').show();
            }
            isPhoneMenuVisible = $('#phoneMenu').is(":visible");
        }

        function syncSearchBoxVal(obj) {
            if ($('#search_box_pc').val() != obj.value){
                $('#search_box_pc').val(obj.value);
            }
            if ($('#search_box_phone').val() != obj.value){
                $('#search_box_phone').val(obj.value);
            }
        }

        function doSearch_course(){
            if (isPhoneDevice == '1') {
                adv_search($('#search_box_phone').val());
            }else{
                adv_search($('#search_box_pc').val());
            }
        }

        function gotoExplorer() {
            $('<form action="/mooc/explorer.php" method="post"></form>').appendTo('body').submit();
        }

        function gotoLogin() {
            top.document.location.href = '/mooc/login.php';
        }

        function gotoRegister() {
            top.document.location.href = '/mooc/register.php';
        }

        function showSearchBar() {
            if ($('#search_bar_phone').is(":visible")){
                $('#search_bar_phone').hide();
            }else{
                $('#search_bar_phone').show();
            }
        }

        function showLang() {
            if ($('#menu_lang').is(":visible")){
                $('#menu_lang').hide();
            }else{
                $('#menu_lang').show();
            }
        }

        function gotoFaqList() {
            
            
            if (navigator.userAgent.match(/(iPad)/i)) {
                $("form[name='faq_node_list']").prop('action', faq_url);
    		    $("form[name='faq_node_list']").prop('target', '_blank');
    		    $("form[name='faq_node_list']").submit();
    	    } else {
    	        var objForm = document.getElementById('faq_node_list');
    	        objForm.action = faq_url;
	            $.fancybox.open("#faqFrame", {
	                maxWidth: 960,
	                fitToView: false,
	                width: '100%',
	                autoSize: false,
	                'titlePosition': 'inline',
	                'transitionIn': 'none',
	                'transitionOut': 'none',
	                'closeBtn': true,
	                'scrolling': 'no',
	                beforeShow: function(){
	                    $("body").css({'overflow-y':'hidden'});
	                    $("#faqFrame").css({'width' : '100%'});
	                },
	                afterClose: function(){
	                    $("body").css({'overflow-y':'visible'});
	                },
	                helpers : {
	                    overlay : {
	                        locked : false
	                    }
	                }
	            });
	            objForm.submit();
            }
            
        }

        $(function () {
            $(window).resize(function () {
                var width = $('#realname').width();
                $('#realname').parent('td').width(width + 80 + 'px');
            }).resize();
            $('.dropdown-toggle').dropdown();
        });
    
</script> 
  <script language="javascript" src="/public/js/common.js"></script> 
  <script language="javascript" src="/mooc/public/js/search.js?1234"></script> 
  <script language="javascript" src="/mooc/public/js/site_header.js"></script>
  <style>

#loginBlockContainer {
    margin-top: 10px;
    text-align: center;
}

#loginBlockContainer > .container {
    width: 266px;
    padding-left: 0px;
    padding-right: 0px;
}

#course-tabs {
    max-width: 266px;
}

.alert {
    padding: 0px;
    margin-top: 20px;
    color: #FF0000;
}

#main {
    min-height: calc(100vh - 310px);
}

.input-text {
    width:266px;
    border:1px #edf1f2 solid;
    border-radius:3px;
    background-color:#edf1f2;
    margin-top: 5px;
    margin-bottom: 5px;
}

.input-text::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
    font-size: 14px;
    color: #9da0a4;
    opacity: 1; /* Firefox */
}

.input-text:-ms-input-placeholder { /* Internet Explorer 10-11 */
    font-size: 14px;
    color: #9da0a4;
}

.input-text::-ms-input-placeholder { /* Microsoft Edge */
    font-size: 14px;
    color: #9da0a4;
}

.t14_b {
    font-size: 14px !important;
    color: #9da0a4;
}

.fb-icon {
    margin-bottom: -4px;
}

#buttonLoginByAccount {
    width:100%;
    height:45px;
    border:1px #15bc97 solid;
    border-radius:3px 0px 0px 3px;
    background-color:#15bc97;
}

#buttonLoginByQrcode {
    width:100%;
    height:45px;
    border:1px #15bc97 solid;
    border-radius:0px 3px 3px 0px;
    background-color:#fff;
}

#captcha-picture {
    width:100%;
}

@media (min-width: 1320px) {
    #loginBlockContainer {
        margin-top: 30px;
        text-align: center;
    }
}


</style> 
  <div id="main"> 
   <div id="loginBlockHeader"> 
    <div class="container" style="max-width: 360px;"> 
     <div class="row" style="margin: 0 auto;"> 
      <div class="col-md-12 col-xs-12" style="text-align: center;border-bottom: 1px solid #dfdfdf;"> <span class="t28">登入</span>
      </div> 
     </div> 
    </div> 
   </div> 
   <form method="post" action="https://elearning2.ksu.edu.tw/login.php" id="loginForm" name="loginForm" onsubmit="return formSubmit();"> 
    <input type="hidden" name="reurl" value=""> 
    <input type="hidden" name="login_key" value="0b76f70a68790719f52b27c88f01167e"> 
    <input type="hidden" name="encrypt_pwd" value=""> 
    <input type="hidden" name="password1" value=""> 
    <div id="loginBlockContainer"> 
     <div class="container"> 
      <div id="course-tabs" class="row" style="margin:0 auto;"> 
       <div class="row" style="padding: 0px; margin: 0px;"> 
        <div class="col-md-12 col-xs-12" style="padding:0px;">
         <input id="buttonLoginByAccount" type="button" class="t16_w_b" style="" value="使用帳號登入" onclick="showLoginByAccount();">
        </div> <!--
                <div class="col-md-6 col-xs-6" style="padding:0px;max-width:133px;"><input id="buttonLoginByQrcode" type="button" class="t16_b" style="" value="QR code登入" onclick="showLoginByQrcode();"></div>
                --> 
       </div> 
      </div> 
     </div> 
     <div id="divLoginByAccount" class="container"> 
      <div class="row" style="margin:0 auto;"> 
       <input type="text" id="username" name="username" class="t14_b input-text" placeholder="帳號" value=""> 
      </div> 
      <div class="row" style="margin:0 auto;"> 
       <input type="password" id="password" name="password" class="t14_b input-text" placeholder="密碼"> 
      </div> <!--
        <div class="row" style="margin:0px;margin-top:15px;text-align: left;">
                                        <span style="text-align:left"><input type="checkbox" name="persist_login" value="1" style="margin:0 2px;" /></span>
                                        <span>記住我，保持登入</span>
        </div>
        <div class="row" style="margin:0px;margin-top:10px;text-align: left;">
            <span class="t13_o">為了避免個資被盜用，請勿在公用電腦或裝置選勾此項。</span>
        </div>
	--> 
      <div class="row" style="margin:0 auto;margin-top:15px;"> <button type="submit" class="t18_w" style="width:100%;height:45px;border:1px #15bc97 solid;border-radius:3px;background-color:#15bc97;" id="btnSignIn">登入</button> 
      </div> 
     </div> 
     <div id="divLoginByQrcode" class="container" style="margin-top: 30px;margin-bottom: 30px;display: none;"> 
      <div class="row" style="width:228px;margin:0 auto;"> 
       <div class="col-md-12 col-xs-12" style="width:228px;height:228px;border:8px solid #DFDFDF;padding:0px;"> <iframe id="iframe-qrcode" src="about:blank" scrolling="no" style="padding:0px;width:214px;height:214px;border:0px;margin:0px;"></iframe> 
       </div> 
      </div> 
     </div> 
    </div> 
   </form> 
  </div> 
  <form method="post" action="message.php?type=5" id="msgForm" name="msgForm"> 
   <input type="hidden" name="action" value="resend"> 
   <input type="hidden" name="login_key" value="0b76f70a68790719f52b27c88f01167e"> 
   <input type="hidden" name="username" value=""> 
   <input type="hidden" name="email" value=""> 
   <input type="hidden" name="encemail" value=""> 
  </form> 
  <script language="javascript" src="https://elearning2.ksu.edu.tw/lib/md5.js"></script> 
  <script language="javascript" src="https://elearning2.ksu.edu.tw/lib/des.js"></script> 
  <script language="javascript" src="https://elearning2.ksu.edu.tw/lib/base64.js"></script> 
  <script language="javascript" src="https://elearning2.ksu.edu.tw/sys/tpl/login.js?1593591870"></script> 
  <script language="javascript">
    var
        MSG_NEED_USERNAME = '請輸入帳號';
        MSG_NEED_PASSWORD = '請輸入密碼';
        MSG_NEED_CAPTCHA  = '請輸入圖形驗證碼';
        MSG_CAPTCHA_ERROR = '圖形驗證碼錯誤';
        QrcodeLoginTimer = null;
        QrcodeLoginTries = 0;
</script> 
  <script language="javascript">
    
    function QrcodeLoginTimerCheck() {
        QrcodeLoginTries++;
        if (QrcodeLoginTries > 36) {
            showLoginByAccount();
            return false;
        }
        $.ajax({
            'type': 'POST',
            'dataType': 'json',
            'data': {'action' : 'checkQrcodeLogin'},
            'url': appRoot + '/mooc/controllers/user_ajax.php',
            'async': false,
            'success': function (data) {
                console.log(data.code);
                if (parseInt(data.code) == 1){
                    clearInterval(QrcodeLoginTimer);
                    document.location.replace('/mooc/index.php');
                }
            },
            'error': function () {
                clearInterval(QrcodeLoginTimer);
            }
        });
    }

    function showLoginByAccount() {
        clearInterval(QrcodeLoginTimer);
        $('#buttonLoginByAccount').css('background-color', '#15bc97');
        $('#buttonLoginByAccount').css('color', '#FFFFFF');
        $('#buttonLoginByAccount').css('font-weight', 'bold');
        $('#buttonLoginByQrcode').css('background-color', '#FFFFFF');
        $('#buttonLoginByQrcode').css('color', '#000000');
        $('#buttonLoginByQrcode').css('font-weight', 'initial');
        $('#divLoginByQrcode').hide();
        $('#divLoginByAccount').show();
    }

    function showLoginByQrcode() {
        $('#buttonLoginByAccount').css('background-color', '#FFFFFF');
        $('#buttonLoginByAccount').css('color', '#000000');
        $('#buttonLoginByAccount').css('font-weight', 'initial');
        $('#buttonLoginByQrcode').css('background-color', '#15bc97');
        $('#buttonLoginByQrcode').css('color', '#FFFFFF');
        $('#buttonLoginByQrcode').css('font-weight', 'bold');
        getLoginQrcode4meUrl();
        $('#divLoginByQrcode').show();
        $('#divLoginByAccount').hide();
    }

    function getLoginQrcode4meUrl() {
        var rtn = '';
        $.ajax({
            'type': 'POST',
            'dataType': 'json',
            'data': {'action' : 'LoginQrcode4me'},
            'url': '/mooc/controllers/user_ajax.php',
            'async': false,
            'success': function (data) {
                if (parseInt(data.code) == 1){
                    rtn = data.data;
                    $('#iframe-qrcode').attr('src', rtn);
                    QrcodeLoginTimer = setInterval(function(){ QrcodeLoginTimerCheck() }, 5000);
                    QrcodeLoginTries = 0;
                }else{
                    rtn = 'about:blank';
                }
            },
            'error': function () {
                rtn = 'about:blank';
            }
        });
    }

    $(function () {
        $('#username').focus();
        $('#iframe-qrcode').on("load", function() {
            $('#iframe-qrcode').get(0).contentWindow.document.getElementsByTagName("body")[0].style.margin = '0px';
        });
    });

    function formSubmit() {
        $('.alert').remove();
        var check = checkLogin();
        if (check === false) {
            return false;
        } else {
            var check2 = checkTmpAccount();
            if (check2 === false) {
                $('#msgForm').submit();
                return false;
            } else if (check2 === -1) {
                return false;
            } else if (check2 === 'error'){
              return false;
            }else {
                return true;
            }
        }
    }

    // 確認帳號是否驗證
    function checkTmpAccount() {
        var rn = false;
        $.ajax({
            'type': 'POST',
            'dataType': 'json',
            'data': $('#loginForm').serialize() + '&action=getTmpAccount',
            // {'action' : 'getTmpAccount', 'username' : $('#username').val()},
            'url': appRoot + '/mooc/controllers/user_ajax.php',
            'async': false,
            'success': function (data) {
                data = json2array(data);
                switch(data[0].code) {
                    case 1:
                        rn = false;
                        $("#msgForm input[name='username']").val(data[0].username);
                        $("#msgForm input[name='email']").val(data[0].email);
                        $("#msgForm input[name='encemail']").val(data[0].encemail);
                        break;
                    case -1:
                        rn = -1;
                        alert(MSG_CAPTCHA_ERROR);
                        location.href = '/mooc/login.php';
                        break;
                    case 2:
                        rn = true;
                        break;
                    case 3:
                        rn = -1;
                        location.href = '/mooc/message.php?type=1';
                        break;
                }
            },
            'error': function () {
                alert('Ajax Error!');
            }
        });
        return rn;
    }
    
</script>  
  <style type="text/css">
    
        .footer {
            background-image: none;
            background-color: #1A1A1A;
            height: 180px;
            padding-top:1px;
            margin-top: 0px;
        }

        .footer > .container > .top {
            padding-top: 15px;
        }

        .infourl {
            font-size: 18px;
            color: #FFFFFF;
        }

        .online {
            right: 0px;
            color:#FFFFFF;border-bottom: 1px solid rgb(51, 51, 51);
            line-height: 42px;
        }

        .fa-facebook {
            font-size: 21px;
            color: #FFFFFF;
            padding-top: 3px;
            padding-right: 2px;
        }


        /*手機尺寸*/
        @media (max-width: 767px) {
            .footer {
                min-width: 320px;
                height: auto;
            }

            .footer > .narrow > .top > .share {
                margin-right: 0px;
                float: left;
                top: 180px;
            }
        }

        /*平板直向、平板橫向*/
        @media (min-width: 768px) and (max-width: 992px) {
            .footer {
                min-width: 320px;
                height: 240px;
            }

            .footer > .narrow > .top > .online {
                padding-left: 30px;
            }

            .footer > .narrow > .bottom > .info > div {
                padding-left: 30px;
            }

            .footer > .narrow > .top > .share {
                margin-right: 35px;
            }
        }




</style> 
  <footer class="footer navbar-fixed-bottom"> 
   <div class="container"> 
    <div class="top row"> 
     <div class="col-md-12"> 
      <div class="online"> <span class="infourl"><a href="/mooc/security.php" style="color: #E9D35A;">資訊安全政策</a>&nbsp;|&nbsp;</span> <span class="infourl"><a href="/mooc/privacy.php" style="color: #E9D35A;">隱私權宣告</a></span> 
      </div> 
     </div> 
     <div class="col-md-6 col-xs-12" style="margin-top:15px;"> 
      <div class="t14_White">
       洽詢單位：崑山科技大學 電子計算機中心 數位學習組
      </div> 
      <div class="t14_White">
       洽詢時間：星期一～星期五（早上 09:00～下午 17:00）
      </div> 
      <div class="t14_White">
       服務信箱：<a href="mailto:ksutetg@mail.ksu.edu.tw">ksutetg@mail.ksu.edu.tw</a>
      </div> 
     </div> 
     <div class="col-md-6 col-xs-12" style="margin-top:15px;"> 
      <div class="t14_White">
       服務電話：(06) 2727-175 #362
      </div> 
      <div class="t14_White">
       本校地址：(71070) 台南市永康區崑大路 195 號
      </div> 
      <div class="t14_White">
       崑山科技大學 著作權聲明 Copyright ? 2019
      </div> 
     </div> <!--
            <div id="index-share-icons" class="col-md-5 col-xs-12" style="margin-top:15px;">
                <div class="share row">
                    
                </div>
            </div>
	    --> 
    </div> 
   </div> 
  </footer> 
  <div id="inline-ln" class="inline-ln"> 
   <form class="well"> 
    <div>
     LINE分享功能只支援行動裝置
    </div> 
   </form> 
  </div> <!--
<div style="width: auto; height: auto; overflow: auto; position: relative;">
    <div id="inline-wct" class="inline-wct">
        <img src="https://chart.googleapis.com/chart?chs=400x400&cht=qr&chl=https://elearning2.ksu.edu.tw&choe=UTF-8"/>
    </div>
</div>

<!-- Current Page Vendor and Views --> 
  <script src="/sys/tpl/vendor/rs-plugin/js/jquery.themepunch.tools.min.js"></script> 
  <script src="/sys/tpl/vendor/rs-plugin/js/jquery.themepunch.revolution.min.js?20170620"></script> 
  <script language="javascript">
    var metaDescription = '旭聯科技-15年線上學習專家．50%政府單位佔有率．80%大專院校佔有率．給你最專業、最便利、最多元的線上教學課程。';
    var metaSitename = encodeURIComponent('崑山網路大學');
    var iosAppStoreUrl = '';
    var androidPlayStoreUrl = '';
    var appPortalRoot = 'SYS_PORTAL_HOME_URL';
    
        $(function () {
            //alert('window:'+$(window).width()+"\n"+'footer:'+$('footer').width());
        });
    
</script> 
  <script language="javascript" src="/mooc/public/js/site_footer.js?20180607"></script>
  <script src="/lib/enable.js" type="text/javascript"></script>
 </body>
</html>

```
```
