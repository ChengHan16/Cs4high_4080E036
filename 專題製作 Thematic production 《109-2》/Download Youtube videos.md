# ● Download Youtube videos
# [pytube3](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/Pytube3_Usage_Project%20description.md)
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
# ● 用 .filter(progressive=True) 把 Progressive 的選項印出來
```python
from pytube import YouTube

link = 'https://www.youtube.com/watch?v=efyS2QK_4ic'      #想下載的影片連結
print(YouTube(link).streams.filter(progressive=True)) 
```
# ● .filter(progressive=True) Results(執行結果)
![3.video Download.png](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/3.video%20Download.png)<br>
___
# [● 漸進式下載和自適應下載的差別](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/%E6%BC%B8%E9%80%B2%E5%BC%8F%E4%B8%8B%E8%BC%89%E5%92%8C%E8%87%AA%E9%81%A9%E6%87%89%E4%B8%8B%E8%BC%89%E7%9A%84%E5%B7%AE%E5%88%A5.md)
___
# ● tese01-2
```python
from pytube import YouTube
import os
import subprocess

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
# ● tese01-2 Results(執行結果)
![4.video Download.png](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/4.video%20Download.png)
# 修改
```python
from pytube import YouTube
import os
import subprocess

fileobj = {}
download_count = 1

# 檢查影片檔是否包含聲音
def check_media(filename):
    r = subprocess.Popen([".\ffprobe", filename],
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

    cmd = f'".\ffmpeg" -i "{temp_video}" -i "{temp_audio}" \
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
# 成功
```python
from pytube import YouTube
import os
import subprocess

fileobj = {}
download_count = 1

# 檢查影片檔是否包含聲音
def check_media(filename):
    r = subprocess.Popen([".\\ffprobe", filename],
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

    cmd = f'".\\ffmpeg" -i "{temp_video}" -i "{temp_audio}" \
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

yt = YouTube('https://www.youtube.com/watch?v=W4sb_oAGPZE', on_progress_callback=onProgress,
                     on_complete_callback=onComplete)
yt.streams.filter(subtype='mp4',resolution="1080p")[0].download()
```
# Results(執行結果)
![4.video Download.png](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/6.video%20Download.PNG)
![5.video Download.png](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/5.video%20Download.PNG)
![6.video Download.png](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/5.video%20Download.png)
![7.video Download.png](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/6.video%20Download.png)
___
# 使用清單下載1080p影片(尚未結合 FFmpeg)
```python
from pytube import Playlist
p = Playlist('https://www.youtube.com/watch?v=L_YwM7Zc5aU&list=PL0iQbgfCDqD5eUX5MaklD9JGxAM74skiv')
for video in p.videos:
    video.streams.filter(subtype='mp4',resolution="1080p")[0].download()
```
![7.video Download.png](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/7.video%20Download.png)
# 抓取清單影片標題及URL
```python
import requests
from bs4 import BeautifulSoup
html = requests.get("https://www.youtube.com/playlist?list=PL0iQbgfCDqD5eUX5MaklD9JGxAM74skiv")
#print(html.text)

soup = BeautifulSoup(html.text, "html.parser")
list1 = soup.find_all("a","yt-simple-endpoint style-scope ytd-playlist-video-renderer")
#print(list1)

for s in list1:
    print("標題" + s.text.strip())
    print("網址" + "https://www.youtube.com/" + s.get("href"))
```
# 以下開始使用清單下載 1080p 影片並結合 FFmpeg
# Results(執行結果)
```
標題：《神魔之塔》冨岡義勇 超極簡單 雙成就 隊長及戰友人類、全水 | 虛偽的羈絆 | 下弦之伍的心願 累 |《MH班長》
網址：https://www.youtube.com/watch?v=L_YwM7Zc5aU&list=PL0iQbgfCDqD5eUX5MaklD9JGxAM74skiv&index=1
標題：《神魔之塔》鬼滅之刃 合作抽卡加倍 就是要五隻 加倍真的有感嗎《MH班長》
網址：https://www.youtube.com/watch?v=9ZmbNXsdSCU&list=PL0iQbgfCDqD5eUX5MaklD9JGxAM74skiv&index=2
標題：【神魔之塔】GNN介紹！全新鬼來襲！下週兩個新鬼登場！
網址：https://www.youtube.com/watch?v=iVq9aj77f68&list=PL0iQbgfCDqD5eUX5MaklD9JGxAM74skiv&index=3
```
# 使用清單下載高畫質Vedio
```python
from pytube import Playlist
playlist = Playlist('https://www.youtube.com/watch?v=L_YwM7Zc5aU&list=PL0iQbgfCDqD5eUX5MaklD9JGxAM74skiv')
print('Number of videos in playlist: %s' % len(playlist.video_urls))

# Loop through all videos in the playlist and download them
for video in playlist.videos:
    video.streams.get_highest_resolution().download()
print("全部下載成功！！！")


#from pytube import Playlist
#Playlist("https://www.youtube.com/watch?v=L_YwM7Zc5aU&list=PL0iQbgfCDqD5eUX5MaklD9JGxAM74skiv").download_all()
#print("全部下載成功！！！")
```
# Results(執行結果)
![vodownload](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/vodownload1.PNG)
# 分辨有無音軌，選取特定畫質Download
```python
import argparse
import os
import platform
from pytube import YouTube
import subprocess

args = {}
fileobj = {}
download_count = 1

def pyTube_folder():
    sys = platform.system()
    home = os.path.expanduser('~')

    if sys == 'Windows':
        folder = os.path.join(home, 'Videos', 'PyTube')
    elif sys == 'Darwin':
        folder = os.path.join(home, 'Movies', 'PyTube')

    if not os.path.isdir(folder):  # 若'PyTube'資料夾不存在…
        os.mkdir(folder)        # 則新增資料夾
    return folder


def onProgress(stream, chunk, remains):
    total = stream.filesize
    percent = (total-remains) / total * 100
    print('下載中… {:05.2f}%'.format(percent), end='\r')

# 列舉可用的解析度


def video_res(yt):
    res_set = set()
    video_list = yt.streams.filter(type="video")
    for v in video_list:
        res_set.add(v.resolution)

    # 傳回解析度表列，例如：['720p', '480p', '360p', '240p', '144p']
    return sorted(res_set, reverse=True, key=lambda s: int(s[:-1]))


def download_media(args):
    try:
        yt = YouTube(args.url, on_progress_callback=onProgress,
                     on_complete_callback=onComplete)
    except:
        print('下載影片時發生錯誤，請確認網路連線和YouTube網址無誤。')
        return

    filter = yt.streams.filter

    if args.a:  # 只下載聲音
        target = filter(type="audio").first()
    elif args.fhd:
        target = filter(type="video", resolution="1080p").first()
    elif args.hd:
        target = filter(type="video", resolution="720p").first()
    elif args.sd:
        target = filter(type="video", resolution="480p").first()
    else:
        target = filter(type="video").first()

    if target is None:
        print('沒有您指定的解析度，可用的解析度如下：')
        res_list = video_res(yt)

        for i, res in enumerate(res_list):
            print('{}) {}'.format(i+1, res))

        val = input('請選擇（預設{}）：'.format(res_list[0]))

        try:
            res = res_list[int(val)-1]
        except:
            res = res_list[0]

        print('您選擇的是 {} 。'.format(res))
        target = filter(type="video", resolution=res).first()

    # 開始下載
    target.download(output_path=pyTube_folder())


def check_media(filename):
    # r = subprocess.Popen(["ffprobe", filename],
    #                      stdout=subprocess.PIPE, stderr=subprocess.STDOUT)
    # out, err = r.communicate()
    # 上面的敘述可改寫成：
    # out = subprocess.check_output(["ffprobe", filename])
    # 或者：
    out = subprocess.run(["ffprobe", filename],
                         stdout=subprocess.PIPE, stderr=subprocess.STDOUT)
    if (out.stdout.decode('utf-8').rfind('Audio') == -1):
        return -1  # 沒有聲音
    else:
        return 1


def merge_media():
    temp_video = os.path.join(fileobj['dir'], 'temp_video.mp4')
    temp_audio = os.path.join(fileobj['dir'], 'temp_audio.mp4')
    temp_output = os.path.join(fileobj['dir'], 'output.mp4')

    cmd = f'ffmpeg -i {temp_video} -i {temp_audio} \
        -map 0:v -map 1:a -c copy -y {temp_output}'
    try:
        subprocess.run(cmd, shell=True)
        # 視訊檔重新命名
        os.rename(temp_output, os.path.join(fileobj['dir'], fileobj['name']))
        os.remove(temp_audio)
        os.remove(temp_video)
        print('視訊和聲音合併完成')
    except:
        print('視訊和聲音合併失敗')


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
            vars(args)['a'] = True  # 設定成a參數
            download_media(args)    # 下載聲音
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

def main():
    global args
    parser = argparse.ArgumentParser()
    parser.add_argument("url", help="指定YouTube視訊網址")
    parser.add_argument("-sd", action="store_true", help="選擇普通（480P）畫質")
    parser.add_argument("-hd", action="store_true", help="選擇HD（720P）畫質")
    parser.add_argument("-fhd", action="store_true", help="選擇Full HD（1080P）畫質")
    parser.add_argument("-a", action="store_true", help="僅下載聲音")

    args = parser.parse_args()
    download_media(args)


if __name__ == '__main__':
    main()
```
# Results(執行結果)
![vodownload2](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/vodownload2.PNG)
![vodownload2-2](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/vodownload2-2.PNG)
___
# 筆記
> ## subprocess.py 更改資料路徑在：
>> ### `File "C:\***\***\AppData\Local\Programs\Python\Python39\lib\subprocess.py"`
>> ### 上 `***` 為個人電腦儲存路經<br>
>>> ## ● 在lib資料夾中找到subprocess.py
>>> ### 搜尋class Popen(object):
>>> ### 將__init__中的shell=False修改為shell=True <br>
> ### pip install pytube==10.4.1 `https://github.com/pytube/pytube/issues/614` 
___
# ● 問題解決/參考資料/安裝套件：
## FFmpeg Download
> #### `https://www.ffmpeg.org/`
## Error: get_ytplayer_config: could not find match for config_patterns
> #### `https://github.com/pytube/pytube/issues/614` 
## Error: get_ytplayer_config: could not find match for config_patterns
> ### `pip install pytube==10.4.1`
> #### `https://zh-tw.coderbridge.com/series/c471d97bb201460ab137c5e4955987df/posts/0baeb8bf25e543ed8462bd742cd1946f`
> #### `https://www.itread01.com/content/1545429986.html`<br>
> #### `https://github.com/BtbN/FFmpeg-Builds/releases`
## AttributeError: ‘str’ object has no attribute ‘decode’ solution
> #### `https://www.programmersought.com/article/17955781692/`
## Python pip/pip3 指令集
> `https://xken831.pixnet.net/blog/post/460728179-%5Bpython%5D-python-%E5%AE%89%E8%A3%9D%E5%A5%97%E4%BB%B6%E7%9A%84%E6%96%B9%E5%BC%8F`
## AttributeError: 'function' object has no attribute 'find_all'
> #### `https://blog.csdn.net/feng_jlin/article/details/82381822`
## bs4.FeatureNotFound: Couldn’t find a tree builder with the features you requested: html_parser. Do you need to install a parser library?
> #### `https://blog.csdn.net/qq_16546829/article/details/79405605`
## “AttributeError: no attribute 'download” With PyTube
> #### `https://stackoverflow.com/questions/64906882/attributeerror-no-attribute-download-with-pytube`
___
# ● Error 待解決：
### `UnicodeDecodeError: 'utf-8' codec can't decode byte 0xa8 in position 0: invalid start byte`<br>
### `s = s.encoded("utf-8").decode("utf-8")`
___
# ● 待吸收：
### `https://www.youtube.com/watch?v=1ozHz7R1wRo`
### `https://www.youtube.com/watch?v=Uc0zriNCtiE`
### `https://pypi.org/project/pytube3/`
### `https://ithelp.ithome.com.tw/questions/10195383`
___
# 待參考資料
> # 01 用Python下載YOUTUBE影片清單資料 吳老師教學部落格
>> ### `https://www.youtube.com/watch?v=ac3UPgpJvcU`
>> ### `https://www.youtube.com/watch?v=FeAIz_BxNjE`
>> ### `https://www.youtube.com/watch?v=sOMxTIh49gw`
> # Python 爬蟲細節整理
>> ### `https://ithelp.ithome.com.tw/articles/10246382`
