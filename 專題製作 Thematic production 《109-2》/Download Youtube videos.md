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
```python
from pytube import YouTube
import os
import subprocess
import pandas as pd

fileobj = {}
download_count = 1


# 檢查影片檔是否包含聲音
def check_media(filename):
    r = subprocess.Popen([".\\bin\\ffprobe", filename],
                         stdout=subprocess.PIPE, stderr=subprocess.STDOUT)
    out, err = r.communicate()

    if (out.decode('utf-8').find('Audio') == -1):
        return -1  # 沒有聲音
    else:
        return 1

# 合併影片檔
def merge_media():
    temp_video = os.path.join(fileobj['dir'], 'temp_video.mp4')
    temp_audio = os.path.join(fileobj['dir'], 'temp_audio.mp4')
    temp_output = os.path.join(fileobj['dir'], 'output.mp4')

    cmd = f'".\\bin\\ffmpeg" -i "{temp_video}" -i "{temp_audio}" \
        -map 0:v -map 1:a -c copy -y "{temp_output}"'
    try:
        subprocess.call(cmd, shell=True)
        # 視訊檔重新命名
        os.rename(temp_output, os.path.join(fileobj['dir'], fileobj['name']))
        os.remove(temp_audio)
        os.remove(temp_video)
        print('視訊和聲音合併完成')
    except:
        print('視訊和聲音合併失敗')

def onProgress(stream, chunk, remains):
    total = stream.filesize
    percent = (total-remains) / total * 100
    print('下載中… {:05.2f}%'.format(percent), end='\r')

def download_sound():
    try:
        yt.streams.filter(type="audio").first().download()
    except:
        print('下載影片時發生錯誤，請確認網路連線和YouTube網址無誤。')
        return

# 檔案下載的回呼函式
def onComplete(stream, file_path):
    global download_count, fileobj
    fileobj['name'] = os.path.basename(file_path)
    fileobj['dir'] = os.path.dirname(file_path)
    print('\r')

    if download_count == 1:
        if check_media(file_path) == -1:
            print('此影片沒有聲音')
            download_count += 1
            try:
                # 視訊檔重新命名
                os.rename(file_path, os.path.join(
                    fileobj['dir'], 'temp_video.mp4'))
            except:
                print('視訊檔重新命名失敗')
                return

            print('準備下載聲音檔')
            download_sound()          # 下載聲音
        else:
            print('此影片有聲音，下載完畢！')
    else:
        try:
            # 聲音檔重新命名
            os.rename(file_path, os.path.join(
                fileobj['dir'], 'temp_audio.mp4'))
        except:
            print("聲音檔重新命名失敗")
        # 合併聲音檔
        merge_media()

yt = YouTube('https://www.youtube.com/watch?v=efyS2QK_4ic', on_progress_callback=onProgress,
                     on_complete_callback=onComplete)
yt.streams.filter(subtype='mp4',resolution="1080p")[0].download()
```
# 筆記
> ## subprocess.py 更改資料路徑在：
>> ### `File "C:\***\***\AppData\Local\Programs\Python\Python39\lib\subprocess.py"`
>> ### 上 `***` 為個人電腦儲存路經<br>
>>> ## ● 在lib資料夾中找到subprocess.py
>>> ### 搜尋class Popen(object):
>>> ### 將__init__中的shell=False修改為shell=True

# ● 問題解決/參考資料/安裝套件：
### `https://www.ffmpeg.org/`
### `https://github.com/pytube/pytube/issues/614`
### `pip install pytube==10.4.1`
### `https://zh-tw.coderbridge.com/series/c471d97bb201460ab137c5e4955987df/posts/0baeb8bf25e543ed8462bd742cd1946f`
### `https://www.itread01.com/content/1545429986.html`<br>
### `https://github.com/BtbN/FFmpeg-Builds/releases`
### ``
### ``
# ● Error 待解決：
### `UnicodeDecodeError: 'utf-8' codec can't decode byte 0xa8 in position 0: invalid start byte`<br>
# ● 待吸收：
### `https://www.youtube.com/watch?v=1ozHz7R1wRo`
