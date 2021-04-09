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
```python
from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=djXGRLm3UyU')
    print(yt.streams)
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
# [Dynamic Adaptive Streaming over HTTP と Progressive Download](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/%E6%BC%B8%E9%80%B2%E5%BC%8F%E4%B8%8B%E8%BC%89%E5%92%8C%E8%87%AA%E9%81%A9%E6%87%89%E4%B8%8B%E8%BC%89%E7%9A%84%E5%B7%AE%E5%88%A5.md)
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
```
from pytube import Playlist
```
## Now let’s create a playlist object. You can do this by initializing the object with a playlist URL:
```
p = Playlist('https://www.youtube.com/playlist?list=PLvNp0Boas721Xb1rZMrxR_NHEKRpO5VNf')
```
## Or you can create one from a video link in a playlist:
```
p = Playlist('https://www.youtube.com/watch?v=efyS2QK_4ic&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O&index=2')
```
## Now, we have a `Playlist` object called `p` that we can do some work with.

# ● Interacting with a playlist
## Fundamentally, a Playlist object is just a container for YouTube objects.
## If, for example, we wanted to download all of the videos in a playlist, we would do the following:
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
___
# ● Playlists
##  You can also download a complete Youtube playlist:
```python
from pytube import Playlist
p = Playlist('https://www.youtube.com/watch?v=XRPFWkMCFIY&list=PL0iQbgfCDqD64NhGHDC8N9r2NDRmb4K7O')
for video in p.videos:
    video.streams.get_highest_resolution().download()
```
# Results(執行結果)
![pytubetest3](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/pytubetest3.PNG)
![pytubetest](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/pytubetest4.PNG)
# This will download the highest progressive stream available (generally 720p) from the given playlist.
# 次回続けてところ `Filtering`
# ● Filtering
## Pytube allows you to filter on every property available (see the documentation for the complete list), let's take a look at some of the most useful ones.
## To list the audio only streams:
### >>> `yt.streams.filter(subtype='mp4')`
```python
from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=9ZmbNXsdSCU')
print(yt.streams.filter(only_audio=True))
```
# Results(執行結果)
```
<Stream: itag="140" mime_type="audio/mp4" abr="128kbps" acodec="mp4a.40.2" progressive="False" type="audio">,
<Stream: itag="251" mime_type="audio/webm" abr="160kbps" acodec="opus" progressive="False" type="audio">]
```
## To list only mp4 streams:
### >>> `yt.streams.filter(only_audio=True)`
```python
from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=9ZmbNXsdSCU')
print(yt.streams.filter(subtype='mp4'))
```
# Results(執行結果)
```
<Stream: itag="18" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.42001E" acodec="mp4a.40.2" progressive="True" type="video">, 
<Stream: itag="22" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.64001F" acodec="mp4a.40.2" progressive="True" type="video">, 
<Stream: itag="137" mime_type="video/mp4" res="1080p" fps="30fps" vcodec="avc1.640028" progressive="False" type="video">, 
<Stream: itag="136" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.4d400b" progressive="False" type="video">, 
<Stream: itag="135" mime_type="video/mp4" res="480p" fps="30fps" vcodec="avc1.4d4014" progressive="False" type="video">, 
<Stream: itag="134" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.4d401e" progressive="False" type="video">, 
<Stream: itag="133" mime_type="video/mp4" res="240p" fps="30fps" vcodec="avc1.4d400c" progressive="False" type="video">, 
<Stream: itag="160" mime_type="video/mp4" res="144p" fps="30fps" vcodec="avc1.4d400b" progressive="False" type="video">, 
<Stream: itag="140" mime_type="audio/mp4" abr="128kbps" acodec="mp4a.40.2" progressive="False" type="audio">
```
## Multiple filters can also be specified:
### >>> `yt.streams.filter(subtype='mp4', progressive=True)`
## this can also be expressed as:
### >>> `yt.streams.filter(subtype='mp4').filter(progressive=True)`
```python
from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=9ZmbNXsdSCU')
print(yt.streams.filter(subtype='mp4', progressive=True))
```
# Results(執行結果)
```
<Stream: itag="18" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.42001E" acodec="mp4a.40.2" progressive="True" type="video">, 
<Stream: itag="22" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.64001F" acodec="mp4a.40.2" progressive="True" type="video">
```
## You also have an interface to select streams by their itag, without needing to filter:
### >>> `yt.streams.get_by_itag(22)`
```python
from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=9ZmbNXsdSCU')
print(yt.streams.get_by_itag(22))
```
# Results(執行結果)
```
<Stream: itag="22" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.64001F" acodec="mp4a.40.2" progressive="True" type="video">
```
___
## If you need to optimize for a specific feature, such as the "highest resolution" or "lowest average bitrate":
### >>> `yt.streams.filter(progressive=True).order_by('resolution').desc()`
```python
from pytube import YouTube
yt = YouTube('https://www.youtube.com/watch?v=9ZmbNXsdSCU')
print(yt.streams.filter(progressive=True).order_by('resolution').desc())
```
# Results(執行結果)
### >>> `print(yt.streams.filter(progressive=True).order_by('resolution').desc())`
```
<Stream: itag="22" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.64001F" acodec="mp4a.40.2" progressive="True" type="video">, 
<Stream: itag="18" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.42001E" acodec="mp4a.40.2" progressive="True" type="video">
```
### >>> `print(yt.streams.filter(progressive=True))`
```
<Stream: itag="18" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.42001E" acodec="mp4a.40.2" progressive="True" type="video">, 
<Stream: itag="22" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.64001F" acodec="mp4a.40.2" progressive="True" type="video">
```
### >>> `print(yt.streams.filter(progressive=False).order_by('resolution').desc())`
```
<Stream: itag="248" mime_type="video/webm" res="1080p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="137" mime_type="video/mp4" res="1080p" fps="30fps" vcodec="avc1.640028" progressive="False" type="video">, 
<Stream: itag="247" mime_type="video/webm" res="720p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="136" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.4d400b" progressive="False" type="video">, 
<Stream: itag="22" mime_type="video/mp4" res="720p" fps="30fps" vcodec="avc1.64001F" acodec="mp4a.40.2" progressive="True" type="video">, 
<Stream: itag="244" mime_type="video/webm" res="480p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="135" mime_type="video/mp4" res="480p" fps="30fps" vcodec="avc1.4d4014" progressive="False" type="video">, 
<Stream: itag="243" mime_type="video/webm" res="360p" fps="30fps" 
vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="134" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.4d401e" progressive="False" type="video">, 
<Stream: itag="18" mime_type="video/mp4" res="360p" fps="30fps" vcodec="avc1.42001E" acodec="mp4a.40.2" progressive="True" type="video">, 
<Stream: itag="242" mime_type="video/webm" res="240p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="133" mime_type="video/mp4" res="240p" fps="30fps" vcodec="avc1.4d400c" progressive="False" type="video">, 
<Stream: itag="278" mime_type="video/webm" res="144p" fps="30fps" vcodec="vp9" progressive="False" type="video">, 
<Stream: itag="160" mime_type="video/mp4" res="144p" fps="30fps" vcodec="avc1.4d400b" progressive="False" type="video">]
```
___
# ● Callbacks
## If your application requires post-processing logic, pytube allows you to specify an "on download complete" callback function:
### >>> `def convert_to_aac(stream, file_handler):`
### >>> `return  # do work`

<br>

### >>> `yt.register_on_complete_callback(convert_to_aac)`
___
## Similarly, if your application requires on-download progress logic, pytube exposes a callback for this as well:
### >>> `def show_progress_bar(stream, chunk, file_handle, bytes_remaining):`
### >>> `# do work`

<br>

### >>> `yt.register_on_progress_callback(show_progress_bar)`
___
# ● Command-line interface (CLI)
## pytube3 ships with a simple CLI interface for downloading videos, playlists, and captions.<br>Let's start with downloading:
> ## To download the highest resolution progressive stream:
>> ### >>> `$ pytube https://www.youtube.com/watch?v=9ZmbNXsdSCU`
> ## To view available streams:
>> ### `$ pytube https://www.youtube.com/watch?v=9ZmbNXsdSCU --list`
> ## To download a specific stream, use the itag
>> ### `$ pytube https://www.youtube.com/watch?v=9ZmbNXsdSCU --itag=22`
> ## To get a list of all subtitles (caption codes)
>> ### `$ pytube https://www.youtube.com/watch?v=9ZmbNXsdSCU --list-captions`
> ## To download a specific subtitle (caption code) - in this case the English subtitles (in srt format) - use:
>> ### `$ pytube https://www.youtube.com/watch?v=9ZmbNXsdSCU -c en`
> ## It is also possible to just download the audio stream (default AAC/mp4):
>> ### `$ pytube https://www.youtube.com/watch?v=9ZmbNXsdSCU -a`
> ## To list all command line options, simply type
>> ### `$ pytube --help`
___
# [實作範例](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E5%B0%88%E9%A1%8C%E8%A3%BD%E4%BD%9C%20Thematic%20production%20%E3%80%8A109-2%E3%80%8B/Download%20Youtube%20videos.md)
# 參考資料
>  ## pytube3
>  ### `https://pypi.org/project/pytube3/`
>  ### `https://python-pytube.readthedocs.io/en/latest/user/playlist.html`
>  ## Command-line interface (CLI)
>  ### `https://python-pytube.readthedocs.io/en/latest/user/cli.html`
