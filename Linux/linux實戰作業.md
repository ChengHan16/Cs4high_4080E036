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

ls :列出目錄檔案
不加任何參數
直接執行 ls 帶任何參數的話，會列出目前目錄中的檔案與目錄列表。
檔案詳細資訊
-l 參數可以顯示檔案與目錄的詳細資訊。
顯示隱藏檔案
-a 參數可以顯示隱藏的檔案與目錄。
使用易讀的格式輸出
-h 參數可以讓輸出的資訊以比較容易閱讀的格式呈現。
顯示檔案類型
-F 參數可以讓檔案名稱的後面加上檔案類型的標示字元。
反向排序檔案
-r 參數可以讓檔案的列表以反向的排序列出。
遞迴列出所有子目錄的檔案
-R 參數可以靠遞迴的方式列出所有子目錄的檔案。
依照時間排序檔案
若要讓檔案依照時間排序，讓最新的檔案排在最後，可以使用 -ltr：
依照檔案大小排序
-S 可以讓檔案依照檔案的大小來排序：
每個檔案都有一個 inode 屬性，若要列出每個檔案的 inode，可以使用 -i 參數：-i
版本資訊
--version 參數可以輸出 ls 版本資訊。
列出目錄
-d 參數可以讓 ls 只列出目錄：

root@kali:~/Desktop# ls -l
total 20
-rw-r--r-- 1 root root    4 Oct  3 10:29 111
drwxr-xr-x 2 root root 4096 Oct  3 10:25 123
-rw-r--r-- 1 root root   11 Oct  3 10:29 222
-rw-r--r-- 1 root root   33 Oct  3 10:30 333
-rw-r--r-- 1 root root   16 Oct  3 10:24 abc.bk
root@kali:~/Desktop# ls -ld
drwxr-xr-x 3 root root 4096 Oct  3 10:29 .
root@kali:~/Desktop# 


顯示 UID 與 GID
-n 參數可以讓 ls 顯示使用者的 UID 與群組的 GID 值：

root@kali:~/Desktop# ls -l
total 20
-rw-r--r-- 1 root root    4 Oct  3 10:29 111
drwxr-xr-x 2 root root 4096 Oct  3 10:25 123
-rw-r--r-- 1 root root   11 Oct  3 10:29 222
-rw-r--r-- 1 root root   33 Oct  3 10:30 333
-rw-r--r-- 1 root root   16 Oct  3 10:24 abc.bk
root@kali:~/Desktop# ls -ld
drwxr-xr-x 3 root root 4096 Oct  3 10:29 .
root@kali:~/Desktop# 

 -a 包含隱藏檔 -l 包含屬性與權限

top :top命令是Linux下常用的性能分析工具
1．命令格式：
top [參數]
2．命令功能：
顯示當前系統正在執行的進程的相關資訊，包括進程ID、記憶體佔用率、CPU佔用率等
3．命令參數：
-b 批次處理
-c 顯示完整的治命令
-I 忽略失效過程
-s 保密模式
-S 累積模式
-i<時間> 設置間隔時間
-u<用戶名> 指定用戶名
-p<進程號> 指定進程
-n<次數> 迴圈顯示的次數
4．使用實例：
實例1：顯示進程資訊
命令：
top

ps :ps指令(Process status)來觀察行程(Process)的資訊
root@kali:~/Desktop# ps
  PID TTY          TIME CMD
 4771 pts/0    00:00:00 bash
 5272 pts/0    00:00:00 ps
root@kali:~/Desktop# 

ping :Linux系統的ping命令是常用的網路命令
1.命令格式：
ping [參數] [主機名稱或IP地址]
2.命令功能：
ping命令用於：確定網路和各外部主機的狀態；跟蹤和隔離硬體和軟體問題；測試、評估和管理網路。如果主機正在運行並連在網上，它就對回送信號進行回應。每個回送信號請求包含一個網際協議（IP）和 ICMP 頭，後面緊跟一個 tim 結構，以及來填寫這個資訊包的足夠的位元組。缺省情況是連續發送回送信號請求直到接收到中斷信號（Ctrl-C）。
ping 命令每秒發送一個資料包並且為每個接收到的響應列印一行輸出。ping 命令計算信號往返時間和(資訊)包丟失情況的統計資訊，並且在完成之後顯示一個簡要總結。ping 命令在程式超時或當接收到 SIGINT 信號時結束。Host 參數或者是一個有效的主機名稱或者是網際網路位址。
3.命令參數：
-d 使用Socket的SO_DEBUG功能。
-f  極限檢測。大量且快速地送網路封包給一台機器，看它的回應。
-n 只輸出數值。
-q 不顯示任何傳送封包的資訊，只顯示最後的結果。
-r 忽略普通的Routing Table，直接將資料包送到遠端主機上。通常是查看本機的網路介面是否有問題。
-R 記錄路由過程。
-v 詳細顯示指令的執行過程。
<p>-c 數目：在發送指定數目的包後停止。
-i 秒數：設定間隔幾秒送一個網路封包給一台機器，預設值是一秒送一次。
-I 網路介面：使用指定的網路介面送出資料包。
-l 前置載入：設置在送出要求資訊之前，先行發出的資料包。
-p 範本樣式：設置填滿資料包的範本樣式。
-s 位元組數：指定發送的資料位元組數，預設值是56，加上8位元組的ICMP頭，一共是64ICMP資料位元組。
-t 存活數值：設置存活數值TTL的大小。
4.使用實例：
實例1：ping的通的情況
命令：
ping 192.168.120.205
輸出：

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
