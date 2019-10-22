# Python小測驗2.md

### Built-in numeric functions內建數值函數
```
學習目標:熟悉常用的內建數值函數用法
abs, divmod, float, hex, int, max, min, oct,
pow, round
```
```
下列結果為何?

round(3.49)
round(3.51)
```
### divmod() 函數
```
divmod() 函數把除數和餘數運算結果結合起來，返回一個包含商和餘數的元組(a // b, a % b)。

在 python 2.3 版本之前不允許處理複數。

函數語法: divmod(a, b)
參數說明： a: 數字 b: 數字

下列結果為何?
divmod(3,5)
divmod(5,3)
divmod(-5,3)
```

### bin()/oct()/hex() 函數
```
hex()函數用於將10進制整數轉換成16進制，以字串形式表示。
oct()函數用於將10進制整數轉換成8進制，以字串形式表示。
bin() 返回一個整數 int 或者長整數 long int 的二進位表示。


函數語法: hex(x)
參數說明：x -- 10進制整數
返回值:返回16進制數，以字串形式表示。

下列結果為何?
hex(7)
hex(15)
hex(16)
hex(112)
hex(255)
hex(255.255)
hex(int(255.255))
type(hex(12))


oct(10)
oct(112)

bin(10)
bin(112)
```

### int()
```
int() 函數用於將一個字串或數位轉換為整型。

函數語法: int(x, base=10)
參數說明：x -- 字串或數位。     base -- 進制數，預設是十進位。
返回值:返回整數型資料。
 

下列結果為何?
int('12')
int('12',2)
int('12',8)
int('12',16)
int('12',7)
```
