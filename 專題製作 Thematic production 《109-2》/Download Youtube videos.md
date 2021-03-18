# ● Download Youtube videos
> # 需安裝的套件
>> ### 1.`pip install pytube3 --upgrade`<br>
>> ### 2.pip install pytube==10.4.1
>> ### 3.然後輸入 `python`，再輸入 `from pytube import YouTube` 
>> ### 來測試套件是否正常，如果沒報錯就沒問題。<br>

# ● tese01
```python
from pytube import YouTube

link = 'https://www.youtube.com/watch?v=efyS2QK_4ic'      #想下載的影片連結
YouTube(link).streams.get_highest_resolution().download() #下載影片
```
# ● tese01 Results(執行結果)
![1.video Download](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/1.video%20Download.png)
![1.video Download](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/2.video%20Download.png.PNG)<br>

# ● tese02
```

```
# 筆記
> ## subprocess.py 更改資料路徑在：
> ### `File "C:\***\***\AppData\Local\Programs\Python\Python39\lib\subprocess.py"`
> ### 上 `***` 為個人電腦儲存路經

# ● 問題解決/參考資料/安裝套件：
## `https://www.ffmpeg.org/`
## `https://github.com/pytube/pytube/issues/614`
## `pip install pytube==10.4.1`
## `https://zh-tw.coderbridge.com/series/c471d97bb201460ab137c5e4955987df/posts/0baeb8bf25e543ed8462bd742cd1946f`
## `https://www.itread01.com/content/1545429986.html`<br>
# 待吸收：
# 1.`https://www.youtube.com/watch?v=1ozHz7R1wRo`
