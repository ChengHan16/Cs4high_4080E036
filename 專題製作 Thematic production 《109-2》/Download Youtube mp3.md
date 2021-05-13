# Test1 `mp4 to mp3 `
```python
from moviepy.editor import *

mp4_file = "video.mp4" # " " <--內放影片檔名
mp3_file = "audio.mp3"

videoClip = VideoFileClip(mp4_file)
audioclip = videoClip.audio
audioclip.write_audiofile(mp3_file)

audioclip.close()
videoClip.close()
```
# Test2 `moviepy.editor`
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
# Test3 
```python
import os
import subprocess

from pytube import Playlist, YouTube

def run(pl):
    filepath = input("C:\\Users\\harry\\OneDrive\\桌面\\-#Program-\\Python\\Mp3 Download")
    # get linked list of links in the playlist
    links = pl.parse_links()
    # download each item in the list
    for l in links:
        # converts the link to a YouTube object
        yt = YouTube(l)
        # takes first stream; since ffmpeg will convert to mp3 anyway
        music = yt.streams.first()
        # gets the filename of the first audio stream
        default_filename = music.default_filename
        print("Downloading " + default_filename + "...")
        # downloads first audio stream
        music.download()
        # creates mp3 filename for downloaded file
        new_filename = default_filename[0:-3] + "mp3"
        print("Converting to mp3....")
        # converts mp4 audio to mp3 audio
        subprocess.run(['ffmpeg', '-i', 
            os.path.join(filepath, default_filename),
            os.path.join(filepath, new_filename)
        ])
    
    print("Download finished.")

if __name__ == "__main__":
    url = input("https://www.youtube.com/watch?v=L_YwM7Zc5aU&list=PL0iQbgfCDqD5eUX5MaklD9JGxAM74skiv")
    pl = url
    run(pl)
````
# 使用資料夾內檔案將 MP4 to MP3
```python
from moviepy.editor import *
import fnmatch
from os import listdir
from os.path import isfile
import os, sys

path = "/4080E000/MyFlask2021/mp3Dload"
dirs = os.listdir( path )

for fullpath in dirs :
    if isfile(fullpath) and fnmatch.fnmatch(fullpath,"*.mp4"):
        #print(fullpath)
        
        mp4_file = fullpath
        mp3_file = fullpath.split(".")[0] + '.mp3'

        print(mp3_file)

        videoClip = VideoFileClip(mp4_file)
        audioclip = videoClip.audio
        audioclip.write_audiofile(mp3_file)

        audioclip.close()
        videoClip.close()
```
# 整合 
```python
from moviepy.editor import *
import fnmatch
from os import listdir
from os.path import isfile
import os, sys

from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=-CCEvgr-69s')
yt.streams.first().download()

path = "/4080E000/MyFlask2021/mp3Dload"
dirs = os.listdir( path )

for fullpath in dirs :
    if isfile(fullpath) and fnmatch.fnmatch(fullpath,"*.mp4"):
        #print(fullpath)
        
        mp4_file = fullpath
        mp3_file = fullpath.split(".")[0] + '.mp3'

        print(mp3_file)

        videoClip = VideoFileClip(mp4_file)
        audioclip = videoClip.audio
        audioclip.write_audiofile(mp3_file)

        audioclip.close()
        videoClip.close()
```
___
# 參考資料
## Python Convert Mp4 to Mp3 File Using MoviePy Library Full Project For Beginners
> `https://www.youtube.com/watch?v=u5x5RZNtOqE`
## yt-playlist-download
> `https://github.com/modkhi/yt-playlist/blob/master/yt-playlist-download.py`
## youtube-mp3-downloader 1.4
> `https://pypi.org/project/youtube-mp3-downloader/`
## 使用 moviepy 轉換 MP4 成 MP3
> `https://clay-atlas.com/blog/2019/11/08/python-chinese-packages-pytube-moviepy-download-youtube-convert/`
## Python(1)--下載Youtube影片成MP3
> `https://arbu00.blogspot.com/2017/11/python1-youtubemp3.html`<br>`https://github.com/Ashing00/ytpmp3/blob/master/ytbmp3.py`
## Python爬蟲全網搜尋並下載音樂
> `https://iter01.com/586013.html`
## 抓YT音樂影片且轉成mp3 （Python）
> `https://hackmd.io/@brad84622/Hk_71R7-v`
___
# Error
## RegexMatchError: get_ytplayer_config: could not find match for config_patterns
> `http://www.e-happy.com.tw/indexforum.asp?bid=18822`
## errors. Mostly "TypeError: show_progress_bar() missing 1 required positional argument: 'bytes_remaining'".
> `https://stackoverflow.com/questions/62360943/pytube-how-to-add-a-progress-bar`
## AttributeError: 'NoneType' object has no attribute 'download'
> `http://www.e-happy.com.tw/indexforum.asp?bid=17370`
## SyntaxError: (unicode error) 'unicodeescape' codec can't decode bytes in position 2-3: truncated \UXXXXXXXX escape
> `http://jasonyychiu.blogspot.com/2019/10/python-syntaxerror-unicode-error.html`
# Error: get_ytplayer_config: could not find match for config_patterns #614
> `https://github.com/pytube/pytube/issues/614` <br>
> code：`pip install git+https://github.com/nficano/pytube`
___
# ノート
> `conda create --name mp3Dload python=3.8` <br>
> `pip install pytube3` <br>
> `pip install moviepy` <br>
> `conda activate mp3Dload` <br>
> `pip install pytube==10.0.0`
___
> `https://stackoverflow.com/questions/54710982/using-pytube-to-download-playlist-from-youtube`
> `https://www.reddit.com/r/Python/comments/gdzqwf/i_made_a_youtube_videoplaylist_to_mp3_converter/`
> `https://github.com/irahorecka/YouTube2Audio` <br>
> `https://medium.com/@chihsuan/pipenv-%E6%9B%B4%E7%B0%A1%E5%96%AE-%E6%9B%B4%E5%BF%AB%E9%80%9F%E7%9A%84-python-%E5%A5%97%E4%BB%B6%E7%AE%A1%E7%90%86%E5%B7%A5%E5%85%B7-135a47e504f4`
___
# キーワード
> `python get folder files`
> `fnmatch`
> `拆 coocick`
---
# 其他待整理
## Python 列出目錄中所有檔案教學：os.listdir 與 os.walk
> `https://blog.gtwang.org/programming/python-list-all-files-in-directory/`
## python批量讀取資料夾檔案、修改檔案
> `https://ithelp.ithome.com.tw/articles/10229795`
## 【python內建模組- os/shutil】用python大量處理電腦上的檔案
> `https://ithelp.ithome.com.tw/articles/10229950`
## I made a YouTube video/playlist to MP3 converter with the ability to suggest and edit MP3 annotations
> `https://www.reddit.com/r/Python/comments/gdzqwf/i_made_a_youtube_videoplaylist_to_mp3_converter/`
> `https://github.com/irahorecka/YouTube2Audio`
## Download a whole YouTube Playlist at one go
> `https://dev.to/spectrumcetb/download-a-whole-youtube-playlist-at-one-go-3331`

# ノート
```python
from moviepy.editor import *
import fnmatch
from os import listdir
from os.path import isfile
import os, sys

path = "/4080E000/MyFlask2021/mp3Dload"
dirs = os.listdir( path )

for fullpath in dirs:
    if isfile(fullpath) and fnmatch.filter(fullpath,"?.mp4"):
        print(fullpath)
        
        mp4_file = fullpath
        mp3_file = "audio.mp3"

        videoClip = VideoFileClip(mp4_file)
        audioclip = videoClip.audio
        audioclip.write_audiofile(mp3_file)

        audioclip.close()
        videoClip.close()


'''  
mp4_file = "新冠病毒全球疫情｜更新時間 20210503 1700.mp4" # " " <--內放影片檔名
mp3_file = "audio.mp3"

videoClip = VideoFileClip(mp4_file)
audioclip = videoClip.audio
audioclip.write_audiofile(mp3_file)

audioclip.close()
videoClip.close()
```
