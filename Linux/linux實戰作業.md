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

cat :命令用於連接文件並打印到標準輸出設備上。
-n 或 --number：由 1 开始对所有输出的行数编号。
-b 或 --number-nonblank：和 -n 相似，只不过对于空白行不编号。
-s 或 --squeeze-blank：当遇到有连续两行以上的空白行，就代换为一行的空白行。
-v 或 --show-nonprinting：使用 ^ 和 M- 符号，除了 LFD 和 TAB 之外。
-E 或 --show-ends : 在每行结束处显示 $。
-T 或 --show-tabs: 将 TAB 字符显示为 ^I。
-A, --show-all：等价于 -vET。
-e：等价于"-vE"选项；
-t：等价于"-vT"选项；
把 textfile1 的文档内容加上行号后输入 textfile2 这个文档里：
cat -n textfile1 > textfile2
把 textfile1 和 textfile2 的文档内容加上行号（空白行不加）之后将内容附加到 textfile3 文档里：
cat -b textfile1 textfile2 >> textfile3
清空 /etc/test.txt 文档内容：
cat /dev/null > /etc/test.txt
cat 也可以用来制作镜像文件。例如要制作软盘的镜像文件，将软盘放好后输入：
cat /dev/fd0 > OUTFILE
相反的，如果想把 image file 写到软盘，输入：
cat IMG_FILE > /dev/fd0

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
