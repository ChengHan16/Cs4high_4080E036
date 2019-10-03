# 完成底下linux指令的測試報告
```
cd : Change Directory 變更目錄 變換工作目錄的指令 
目錄的表示方式可以使用絕對路徑與相對路徑。
語法：cd [options] [dir]
例如:cd Desktop

pwd :print name of current/working directory 
pwd用於顯示目前所在目錄的指令
想要知道目前所在的目錄，可以輸入pwd：
1. 列出目前的工作目錄:
#pwd 
例如:root@kali:~/Desktop# pwd

cat：命令用於連接文件並打印到標準輸出設備上。
-n或--number：由1開始對所有輸出的行數編號。
-b或--number-nonblank：和-n相似，只不過對於空白行不編號。
-s或--squeeze-blank：當遇到有連續兩行以上的空白行，就代換為一行的空白行。
-v或--show-nonprinting：使用^和M-符號，除了LFD和TAB之外。
-E或--show-ends：在每行結束處顯示$。
-T或--show-tabs：將TAB字符顯示為^ I。
-A，--show-all：等價於-vET。
-e：等價於“ -vE”選項；
-t：等價於“ -vT”選項；
把textfile1的文檔內容加上行號後輸入textfile2這個文檔裡：
cat -n textfile1> textfile2
把textfile1和textfile2的文檔內容加上行號（空白行不加）之後將內容附加到textfile3文檔裡：
cat -b textfile1 textfile2 >> textfile3
清空/etc/test.txt文檔內容：
cat / dev / null> /etc/test.txt
cat也可以使用製作特定文件。例如要製作軟盤的額外文件，將軟盤放好後輸入：
cat / dev / fd0>輸出文件
相反的，如果想把圖像文件寫到軟盤，輸入：
貓的IMG_FILE> / dev / fd0

ls
top
ps
ping

```

### 目錄與路徑
```
相對路徑與絕對路徑
目錄的相關操作： cd, pwd, mkdir, rmdir
```

### 檔案與目錄管理
```
檔案與目錄的檢視： ls
複製、刪除與移動： cp, rm, mv
取得路徑的檔案名稱與目錄名稱
```
### 檔案內容查閱
```
直接檢視檔案內容： cat, tac, nl
可翻頁檢視： more, less
資料擷取： head, tail
非純文字檔： od
修改檔案時間與建置新檔： touch
```

檔案與目錄的預設權限與隱藏權限
```
檔案預設權限：umask
檔案隱藏屬性： chattr, lsattr
檔案特殊權限：SUID, SGID, SBIT, 權限設定
觀察檔案類型：file
```
### 指令與檔案的搜尋
```
指令檔名的搜尋：which
檔案檔名的搜尋：whereis, locate / updatedb, find
```
