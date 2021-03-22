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
# ● Usage
```python
from pytube import YouTube
YouTube('https://www.youtube.com/watch?v=djXGRLm3UyU').streams[0].download()
```
## This example will download the highest quality progressive download stream available.<br>Next, let's explore how we would view what video streams are available:
# 參考資料
>  ## `https://pypi.org/project/pytube3/`
