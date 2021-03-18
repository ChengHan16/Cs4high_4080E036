# ● Download Youtube videos
> # 需安裝的套件
>> ### 1.`pip install pytube3 --upgrade`<br>
>> ### 2. 然後輸入 `python`，再輸入 `from pytube import YouTube` 
>> ### 來測試套件是否正常，如果沒報錯就沒問題。<br>

# ● tese01
```python
from pytube import YouTube

link = 'https://www.youtube.com/watch?v=efyS2QK_4ic'      #想下載的影片連結
YouTube(link).streams.get_highest_resolution().download() #下載影片
```

# ● 問題解決 參考資料：
## `https://github.com/pytube/pytube/issues/614`
```

```
