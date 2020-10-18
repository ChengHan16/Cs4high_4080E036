First Lesson
============
Hello Python.py
---------------
```
print("Hello Python")
```
Second lesson
==============
datatype.py
-----------
```
# 資料：程式基本單位
# Number
1234
3.3

# 字串
"測試中文"
"Hello Python"

# 布林值
True
False

# 有順序、可動的列表 List
[3,4,5]
["Hello","Python"]
# 有順序、不可動的列表 Tuple
(3,4,5)
("Hello","Python")

# 集合 Set (無順序概念)
{3,4,5}
{"Hello","Python"}

# 字典 Dictionary
{"apple":"蘋果","data":"資料"}

# 變數：用來儲存資料的自訂名稱(開頭不可數字)
# 變數名稱=資料
x = 3
print(x)

x = True # 取代舊的資料
print(x)

x = "Hello" 
print(x)

x = {7,8,9}
print(x)
```
Lesson Three
============
Number_String.py
----------------
```
# 數字運算
#x = 3 + 6
#print(x)

#x = 3 * 6
#print(x)

#x = 3 / 6 # 小數除法
#print(x)

#x = 3 // 6 # 整數除法
#print(x)

#x = 2**0.5 
#print(x)

#x = 7%3 # 取餘數
#print(x)

#x = 2 + 3
#print(x)
#x=x+1   # 將變數中的數字 +1

# x+=1
# x-=1
# x*=1
#print(x)


# 字串運算

#s = "Hello"
#print(s)

#s = "Hello\"O" # \(斜線)跳脫與""，並可列印出來
#print(s)

#s = "Hello"+"Python"
#print(s)

#s = "Hello" "Python"
#print(s)

#s = "Hello\nWord" # \n 換行
#print(s)

# 3個多引號或單引可以換行
#s = """Hello

#World"""
#print(s)

#s = "Hello"*3 + "Pyhton"
#print(s)

# 字串內有對應字元編號，從0開始算起
#s = "Hello"
#print(s[0] ,s[4])

#print(s[1:4]) # 取1~4之間

#s = "Hello"
#print(s[1:])
#print(s[:4])
```
Fourth lesson
=============
list_Tuple.py
-------------
```
# 有序可變動列表 List 
#grades = [12,60,15,70,90]
#print(grades)
#print(grades[0])
#print(grades[4])
#----------------------------
#grades = [12,60,15,70,90]
#grades[0]=55 # 把 55 放到列表中的第一個位置 
#print(grades)
#----------------------------
#grades = [12,60,15,70,90]
#print(grades[1:4])
#----------------------------
#grades = [12,60,15,70,90]
#grades[1:4]=[] # 連續刪除列表中 編號1到編號4(不包含)的資料
#print(grades)
#----------------------------
#grades = [12,60,15,70,90]
#grades = grades + [12,23]
#print(grades)
#----------------------------
#列出列表長度 len(列表資料)
#grades = [12,60,15,70,90] 
#length = len(grades) #可省略
#print(len(grades))
#----------------------------
#data = [[3,4,5],[6,7,8]]
#print(data[0])
#print(data[1])
#----------------------------
#data = [[3,4,5],[6,7,8]]
#print(data[0][1])
#----------------------------
#data = [[3,4,5],[6,7,8]]
#data[0][0:2] = [5,5,5]
#print(data[0])
#----------------------------
#data = [[3,4,5],[6,7,8]]
#data[0][0:2] = [5,5,5]
#print(data)


# 有序不可動列表 Tuple
#data = (3,4,5)
#print(data)
#----------------------------
#data = (3,4,5)
#print(data[0:2])
#----------------------------
#data = (3,4,5)
## ---data[0] = 5 # 錯誤: Tuple 的資料不可變動 ---
#print(data[0:2])
```
fifth lesson
============
set-dictionary
------------
```
# 集合的運算
#s1 = {3,4,5}
#print(3 in s1) # in 3有沒有在 s1 當中
#----------------------------------------
#s1 = {3,4,5}
#print(10 in s1) # in 10有沒有在 s1 當中
#----------------------------------------
#s1 = {3,4,5}
#print(10 not in s1) # in 10有沒有在 s1 當中
#----------------------------------------
#s1 = {3,4,5}
#s2 = {4,5,6,7}
#s3 = s1&s2 # 交集:取兩個集合中，相同的資料
#print(s3)
#----------------------------------------
#s1 = {3,4,5}
#s2 = {4,5,6,7}
#s3 = s1|s2 # 聯集:取兩個集合中的所有資料，但不重複取
#print(s3)
#----------------------------------------
#s1 = {3,4,5}
#s2 = {4,5,6,7}
#s3 = s1-s2 # 差集:從 s1 中，減去和 s2 重疊的部分
#print(s3)
#----------------------------------------
#s1 = {3,4,5}
#s2 = {4,5,6,7}
#s3 = s1^s2 # 反交集:取兩個集合中，不重疊的部分
#print(s3)
#----------------------------------------
#s1 = {3,4,5}
#s2 = {4,5,6,7}
#s3 = s1^s2 # 反交集:取兩個集合中，不重疊的部分
#print(s3)
#----------------------------------------
# 把字串拆解成集合
#s = set("Hello") # set(字串)，拆解字串
#print(s)
#----------------------------------------
#s = set("Hello") # set(字串)，拆解字串
#print("H" in s) # 判斷 H 有沒有包含在裡面



# 字典的運算: key-value 配對
#dic = {"apple":"りんご","Bug":"蟲"}
#print(dic["apple"])
#----------------------------------------
#dic = {"apple":"りんご","Bug":"蟲"}
#dic["apple"] = "小りんご"
#print(dic["apple"])
#----------------------------------------
#dic = {"apple":"りんご","Bug":"蟲"}
#print("apple" in dic) # 判斷 key 是否存在
#print("text" not in dic) # 判斷 key 是否存在
#----------------------------------------
# del 
#dic = {"apple":"りんご","Bug":"蟲"}
#print(dic)
#del dic["apple"] # 刪除字典中的键值對 (key-value pair)
#print(dic)
#----------------------------------------
#dic = { x:x*2 for x in 列表 }
#dic = {x:x*2 for x in [3,4,5]} # 從列表的資料產生字典，以列表資料當基礎
#print(dic)
```
