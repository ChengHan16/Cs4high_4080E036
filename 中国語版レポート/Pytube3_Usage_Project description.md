# pytube3
# ● Installation
> ## Download using pip via pypi.
```
$ pip install pytube3 --upgrade
```
> ### (Mac/homebrew users may need to use pip3)
# ● Quick start
```python
from pytube import YouTube
YouTube('https://www.youtube.com/watch?v=djXGRLm3UyU').streams.get_highest_resolution().download()
yt = YouTube('http://youtube.com/watch?v=9bZkp7q19f0')
yt.streams.filter(progressive=True, file_extension='mp4').order_by('resolution')[-1].download()
```
```python
from pytube import YouTube

YouTube('https://www.youtube.com/watch?v=djXGRLm3UyU').streams.filter(progressive=True, file_extension='mp4').order_by('resolution')[-1].download()
```
![pytubetest1.PNG](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/pytubetest1.PNG)
![pytubetest1.PNG](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/pytubetest2.PNG)
# ● Usage
```python
from pytube import YouTube
YouTube('https://www.youtube.com/watch?v=djXGRLm3UyU').streams[0].download()
```
## 此示例將下載可用的最高質量的漸進式下載流。<br>接下來，讓我們探索如何查看可用的視頻流：
# Results(執行結果)
```
[<Stream: itag="18" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.42001E" acodec="mp4a.40.2" progressive="True" type="video">,
<Stream: itag="22" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.64001F" acodec="mp4a.40.2" progressive="True" type="video">, 
<Stream: itag="137" mime_type="video/mp4" res="1080p" fps="30fps" vcodec="avc1.640028" progressive="False" type="video">, 
<Stream: itag="248" mime_type="video/webm" res="1080p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="136" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.4d400d" progressive="False" type="video">, 
<Stream: itag="247" mime_type="video/webm" res="720p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="135" mime_type="video/mp4" res="480p" fps="30fps" vcodec="avc1.4d4014" progressive="False" type="video">, 
<Stream: itag="244" mime_type="video/webm" res="480p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="134" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.4d401e" progressive="False" type="video">, 
<Stream: itag="243" mime_type="video/webm" res="360p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="133" mime_type="video/mp4" res="240p" fps="30fps" vcodec="avc1.4d400c" progressive="False" type="video">, 
<Stream: itag="242" mime_type="video/webm" res="240p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="160" mime_type="video/mp4" res="144p" fps="30fps" vcodec="avc1.4d400b" progressive="False" type="video">, 
<Stream: itag="278" mime_type="video/webm" res="144p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="140" mime_type="audio/mp4" abr="128kbps" acodec="mp4a.40.2" progressive="False" type="audio">, 
<Stream: itag="251" mime_type="audio/webm" abr="160kbps" acodec="opus" progressive="False" type="audio">]
```
# ● Selecting an itag
# [Dynamic Adaptive Streaming over HTTP と Progressive Download](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/%E6%BC%B8%E9%80%B2%E5%BC%8F%E4%B8%8B%E8%BC%89%E5%92%8C%E8%87%AA%E9%81%A9%E6%87%89%E4%B8%8B%E8%BC%89%E7%9A%84%E5%B7%AE%E5%88%A5.md)
> ## 您可能會注意到，列出的某些流同時具有視頻編解碼器和音頻編解碼器，而其他流僅具有視頻或音頻，這是YouTube支持稱為HTTP動態自適應流（DASH）的流技術的結果。

> ## 在pytube的背景下，其含義是針對最高質量的流； 您現在需要下載音頻和視頻軌道，然後使用FFmpeg之類的軟件對它們進行後處理以合併它們。

> ## 在單個文件中包含音頻和視頻的舊式流（稱為“漸進式下載”）仍然可用，但僅適用於720p及以下分辨率。

## 要僅查看這些漸進式下載流，請執行以下操作：
```python
from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=djXGRLm3UyU')
print(yt.streams.filter(progressive=True))
```
# Results(執行結果)
```
[<Stream: itag="18" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.42001E" acodec="mp4a.40.2" progressive="True" type="video">,
<Stream: itag="22" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.64001F" acodec="mp4a.40.2" progressive="True" type="video">]
```
## 相反，如果您只想查看DASH流（也稱為“自適應”），則可以執行以下操作：
```python
from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=Enbgpv8UhoE')
print(yt.streams.filter(adaptive=True))
```
# Results(執行結果)
```
[<Stream: itag="137" mime_type="video/mp4" res="1080p" fps="30fps" vcodec="avc1.640028" progressive="False" type="video">, 
<Stream: itag="248" mime_type="video/webm" res="1080p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="136" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.4d400d" progressive="False" type="video">, 
<Stream: itag="247" mime_type="video/webm" res="720p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="135" mime_type="video/mp4" res="480p" fps="30fps" vcodec="avc1.4d4014" progressive="False" type="video">, 
<Stream: itag="244" mime_type="video/webm" res="480p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="134" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.4d401e" progressive="False" type="video">, 
<Stream: itag="243" mime_type="video/webm" res="360p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="133" mime_type="video/mp4" res="240p" fps="30fps" vcodec="avc1.4d400c" progressive="False" type="video">, 
<Stream: itag="242" mime_type="video/webm" res="240p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="160" mime_type="video/mp4" res="144p" fps="30fps" vcodec="avc1.4d400b" progressive="False" type="video">, 
<Stream: itag="278" mime_type="video/webm" res="144p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="140" mime_type="audio/mp4" abr="128kbps" acodec="mp4a.40.2" progressive="False" type="audio">, 
<Stream: itag="251" mime_type="audio/webm" abr="160kbps" acodec="opus" progressive="False" type="audio">]
```
# ● Creating a Playlist
## 使用pytube與播放列表進行交互非常簡單。 首先導入播放列表類：
```
from pytube import Playlist
```
## 現在，我們創建一個播放列表對象。 您可以通過使用播放列表URL初始化對象來做到這一點：
```
p = Playlist('https://www.youtube.com/playlist?list=PLvNp0Boas721Xb1rZMrxR_NHEKRpO5VNf')
```
## 或者，您可以通過播放列表中的視頻鏈接創建一個：
```
p = Playlist('https://www.youtube.com/watch?v=efyS2QK_4ic&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O&index=2')
```
## Now, we have a `Playlist` object called `p` that we can do some work with.

# ● Interacting with a playlist
## 從根本上說，播放列表對像只是YouTube對象的容器。.
## 例如，如果我們要下載播放列表中的所有視頻，則可以執行以下操作：
```python
from pytube import Playlist
p = Playlist('https://www.youtube.com/watch?v=XRPFWkMCFIY&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O')
for video in p.videos:
    video.streams.first().download()
```
## 或者，如果我們僅對視頻的URL感興趣，那麼我們也可以查看這些URL：
```python
from pytube import Playlist
p = Playlist('https://www.youtube.com/watch?v=XRPFWkMCFIY&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O')
for url in p.video_urls[:3]:
    print(url)
```
___
# ● Playlists
##  您還可以下載完整的Youtube播放列表：
```python
from pytube import Playlist
p = Playlist('https://www.youtube.com/watch?v=XRPFWkMCFIY&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O')
for video in p.videos:
    video.streams.get_highest_resolution().download()
```
# Results(執行結果)
![pytubetest3](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/pytubetest3.PNG)
![pytubetest](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/pytubetest4.PNG)
# 這將從給定的播放列表中下載最高可用的漸進流（通常為720p）。
## 
```python

```
# [實作範例](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/Download%20Youtube%20videos.md)
# 參考資料
>  ## `https://pypi.org/project/pytube3/`
>  ## `https://python-pytube.readthedocs.io/en/latest/user/playlist.html`
