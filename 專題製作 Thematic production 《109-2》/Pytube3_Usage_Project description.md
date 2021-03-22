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
## This example will download the highest quality progressive download stream available.<br>Next, let's explore how we would view what video streams are available:
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
> ## You may notice that some streams listed have both a video codec and audio codec, while others have just video or just audio, this is a result of YouTube supporting a streaming technique called Dynamic Adaptive Streaming over HTTP (DASH).

> ## In the context of pytube, the implications are for the highest quality streams; you now need to download both the audio and video tracks and then post-process them with software like FFmpeg to merge them.

> ## The legacy streams that contain the audio and video in a single file (referred to as "progressive download") are still available, but only for resolutions 720p and below.

## To only view these progressive download streams:
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
## Conversely, if you only want to see the DASH streams (also referred to as "adaptive") you can do:
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
## Using pytube to interact with playlists is very simple. Begin by importing the Playlist class:
## `from pytube import Playlist`
## Now let’s create a playlist object. You can do this by initializing the object with a playlist URL:
## `p = Playlist('https://www.youtube.com/playlist?list=PLvNp0Boas721Xb1rZMrxR_NHEKRpO5VNf')`
## Or you can create one from a video link in a playlist:
## `p = Playlist('https://www.youtube.com/watch?v=efyS2QK_4ic&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O&index=2')`
## Now, we have a Playlist object called p that we can do some work with.
```

```
# ● Playlists
##  You can also download a complete Youtube playlist:
```
```
## 
```python
from pytube import Playlist
p = Playlist('https://www.youtube.com/watch?v=XRPFWkMCFIY&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O')
for video in p.videos:
    video.streams.first().download()
```
## Or, if we’re only interested in the URLs for the videos, we can look at those as well:
```python
from pytube import Playlist
p = Playlist('https://www.youtube.com/watch?v=XRPFWkMCFIY&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O')
for url in p.video_urls[:3]:
    print(url)
```
# 參考資料
>  ## `https://pypi.org/project/pytube3/`
>  ## `https://python-pytube.readthedocs.io/en/latest/user/playlist.html`
