# RAID
```
容錯式磁碟陣列（RAID, Redundant Array of Independent Disks）簡稱磁碟陣列。
利用虛擬化儲存技術把多個硬碟組合起來，成為一個或多個硬碟陣列組，目的為提升效能或資料冗餘，或是兩者同時提升。
```
# RAID 0
![Alt text](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/130px-RAID_0.svg.png)
```
RAID 0亦稱為帶區集。
它將兩個以上的磁碟並聯起來，成為一個大容量的磁碟。

在存放資料時，分段後分散儲存在這些磁碟中，因為讀寫時都可以並列處理，所以在所有的級別中，RAID 0的速度是最快的。

但是RAID 0既沒有冗餘功能，也不具備容錯能力，如果一個磁碟（物理）損壞，所有資料都會遺失，危險程度與#JBOD相當。
```
# RAID 0
![Alt text](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/130px-RAID_1.svg.png)
```
兩組以上的N個磁碟相互作鏡像，在一些多執行緒作業系統中能有很好的讀取速度，理論上讀取速度等於硬碟數量的倍數，與RAID 0相同。
另外寫入速度有微小的降低。只要一個磁碟正常即可維持運作，可靠性最高。
其原理為在主硬碟上存放資料的同時也在鏡像硬碟上寫一樣的資料。當主硬碟（物理）損壞時，鏡像硬碟則代替主硬碟的工作。
因為有鏡像硬碟做資料備份，所以RAID 1的資料安全性在所有的RAID級別上來說是最好的。
但無論用多少磁碟做RAID 1，僅算一個磁碟的容量，是所有RAID中磁碟利用率最低的一個級別。

如果用兩個不同大小的磁碟建RAID 1，可用空間為較小的那個磁碟，較大的磁碟多出來的空間也可以分割成一個區來使用，不會造成浪費。
```
# RAID 10/01
![Alt text](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/220px-RAID_10.svg.png)
![Alt text](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/RAID_01.svg.png)
```
RAID 10是先分割資料再鏡像，再將所有硬碟分為兩組，視為以RAID 1作為最低組合，然後將每組RAID 1視為一個「硬碟」組合為RAID 0運作。

RAID 01則是跟RAID 10的程式相反，是先鏡像再將資料到分割兩組硬碟。
它將所有的硬碟分為兩組，每組各自構成為RAID 0作為最低組合，而將兩組硬碟組合為RAID 1運作。

當RAID 10有一個硬碟受損，其餘硬碟會繼續運作。
RAID 01只要有一個硬碟受損，同組RAID 0的所有硬碟都會停止運作，只剩下其他組的硬碟運作，可靠性較低。
如果以六個硬碟建RAID 01，鏡像再用三個建RAID 0，那麼壞一個硬碟便會有三個硬碟離線。
因此，RAID 10遠較RAID 01常用，零售主機板絕大部份支援RAID 0/1/5/10，但不支援RAID 01。
```
