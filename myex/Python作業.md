

# range的技術
#### range的技術(1)
```
list1=range(6)
list1
```
```
答案是:[0, 1, 2, 3, 4, 5]
```
#### range的技術(2)
```
list2=range(1,6)
list2
```
```
答案是:[1, 2, 3, 4, 5]
```
#### range的技術(3)
```
list3=range(1,6,2)
list3
```
```
答案是:[1, 3, 5]
```
#### range的技術(4)
```
for dd in range(6):
   print(dd)
```
```
答案是:
0,1,2,3,4,5
```
##### 程式閱讀題:下列程式執行後會印出什麼？
```
list1=range(10)
list2=range(1,10)
list3=range(1,10,2)
list4=range(10,1,-2)

print(list(list1))
print(list(list2))
print(list(list3)) 
print(list(list4))  

```
```
答案是:
[0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
[1, 2, 3, 4, 5, 6, 7, 8, 9]
[1, 3, 5, 7, 9]
[10, 8, 6, 4, 2]
```
# for 迴圈技術

```
for n in range(3):
  print(n,end=",")
```
答案:0,1,2,
```
程式閱讀題:下列程式執行後會印出什麼？
```
numbers = [21, 4, 35, 1, 8, 7, 3, 6, 9]
my_numbers = []

for number in numbers:
    if (number % 2 != 0): 
　　my_numbers.append(number)

print(my_numbers)
```
答案是:[21, 35, 1, 7, 3, 9]
```
##### 程式設計題:完成等差數列的總和計算:1+5+9+13+ ...+81
```

```
##### 程式設計題:完成等差數列的積和計算:1乘5乘9乘13乘 ...乘33
```

```

