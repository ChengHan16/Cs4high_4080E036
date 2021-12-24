## - Error 

### 1. jinja2.exceptions.TemplateNotFound (已解決)
```
1、項目下面是否有templates文件夾，你的html文件是否放進了裡面；
2、templates文件夾是否和你運行的py文件在同一級目錄；
3、render_template('***.html')這裡面的名字是否正確，別打錯了；
4、app = Flask(__name__, template_folder='templates', static_folder="****",static_url_path="****") 在最開始的這句話中，template_folder後面一定要跟上templates；
```
> !(https://blog.csdn.net/shangxiaqiusuo1/article/details/103684463)
