```python
from pytube import YouTube


def progress(chunk, file_handle, bytes_remaining):
    contentSize = video.filesize
    size = contentSize - bytes_remaining

    print('\r' + '[Download progress]:[%s%s]%.2f%%;' % (
    '█' * int(size*20/contentSize), ' '*(20-int(size*20/contentSize)), float(size/contentSize*100)), end='')


url = 'https://www.youtube.com/watch?v=JwBXgJeqeOs'
yt = YouTube(url, on_progress_callback=progress)
video = yt.streams.first()
video.download()
```
___
# 參考資料
## yt-playlist-download
> `https://github.com/modkhi/yt-playlist/blob/master/yt-playlist-download.py`
## youtube-mp3-downloader 1.4
> `https://pypi.org/project/youtube-mp3-downloader/`
# Error
## RegexMatchError: get_ytplayer_config: could not find match for config_patterns
> `http://www.e-happy.com.tw/indexforum.asp?bid=18822`
## errors. Mostly "TypeError: show_progress_bar() missing 1 required positional argument: 'bytes_remaining'".
> `https://stackoverflow.com/questions/62360943/pytube-how-to-add-a-progress-bar`
## AttributeError: 'NoneType' object has no attribute 'download'
> `http://www.e-happy.com.tw/indexforum.asp?bid=17370`
## SyntaxError: (unicode error) 'unicodeescape' codec can't decode bytes in position 2-3: truncated \UXXXXXXXX escape
> `http://jasonyychiu.blogspot.com/2019/10/python-syntaxerror-unicode-error.html`
# ノート
> `conda create --name mp3Dload python=3.8` <br>
> `pip install pytube3` <br>
> `pip install moviepy` <br>
> `conda activate mp3Dload` <br>
> `pip install pytube==10.0.0`
# 其他待整理
## python批量讀取資料夾檔案、修改檔案
> `https://ithelp.ithome.com.tw/articles/10229795`
##【python內建模組- os/shutil】用python大量處理電腦上的檔案
> `https://ithelp.ithome.com.tw/articles/10229950`

