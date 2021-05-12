# How to clear the interpreter console? (python
### As you mentioned, you can do a system call:<br>For Windows:
```
>>> import os
>>> clear = lambda: os.system('cls')
>>> clear()
```
### For Linux it would be:
```
>>> import os
>>> clear = lambda: os.system('clear')
>>> clear()
```
# 參考資料 
### How to clear the interpreter console?
> `https://stackoverflow.com/questions/517970/how-to-clear-the-interpreter-console`
