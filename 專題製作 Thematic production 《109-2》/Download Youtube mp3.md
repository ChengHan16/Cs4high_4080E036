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
# ノート
> `conda create --name mp3Dload python=3.8` <br>
> `pip install pytube3` <br>
> `pip install moviepy` <br>
> `conda activate mp3Dload` <br>
> `pip install pytube==10.0.0`
