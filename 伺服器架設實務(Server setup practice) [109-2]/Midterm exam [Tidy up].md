# Midterm exam [Tidy up]
> ### 使用 ksu_database-r109.2-1.sql
> ### ex52-1.php <br> ksu_select3.html +ksu_select3.php <br> ksu_select3a.html +ksu_select3a.php <br> ksu_select4.html +ksu_select4.php <br> ksu_select4a.html +ksu_select4a.php <br> ksu_select6.html +ksu_select6.php
___

# ● ksu_select3.html + ksu_select3.php
## `ksu_select3.html`
```html
<!doctype html>
<html lang="zh_tw">
<head>
  <meta charset="utf-8">
  <title>Hello</title>
</head>
<body>
  <h3> ksu select operation </h3>
  <!--不對字符編碼 -->    
  <form enctype="multipart/form-data" method="post"     
        action="ksu_select3.php">
    按查詢鍵, 查詢 ksu_std_table 中, 各系的學生人數. <br/>
    <br/>
    <input type="submit" name="sub" value="查詢"/>
  </form>
</body>
</html>
```
## ksu_select3.php
```php
<?php
 $db_host = "localhost";
 $db_name = "ksu_database";
 $db_table = "ksu_std_table";
 $db_user = "root";
 $db_password = "";
 
 // 連結檢測
 $conn = mysqli_connect($db_host, $db_user, $db_password);
 if(empty($conn)){
	print  mysqli_error ($conn);
    die ("無法對資料庫連線！" );
	exit;
 }  
 if(!mysqli_select_db( $conn, $db_name)){
	die("資料庫不存在!");
	exit;
 }  

 //自型設定  
 mysqli_set_charset($conn,'utf8');
      
 echo "ksu_std_table  學生於各系人數顯示如下:". "<br/><br/>";  
 $result = mysqli_query($conn,
                        "SELECT ksu_std_department, count(1) FROM ksu_std_table group by ksu_std_department");
 echo "<table border='1'>
 <tr>
   <th> 系別 </th>  <th>學生人數 </th> 
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   echo "</tr>";
 }
 echo "</table>";
 echo "records found!"."<br/><br/>";
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# http://127.0.0.1/ksu_select3.html
# Results(執行結果)
![Midterm exam Tidy up html](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Midterm%20exam%20Tidy%20up%20html.JPG)
![Midterm exam Tidy up 1](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Midterm%20exam%20Tidy%20up%201.JPG)
___
# ● ksu_select3a.html + ksu_select3a.php
## `ksu_select3a.html`
```html
<!doctype html>
<html lang="zh_tw">
<head>
  <meta charset="utf-8">
  <title>Hello</title>
</head>
<body>
  <h3> ksu select operation </h3>
  <!--不對字符編碼 -->    
  <form enctype="multipart/form-data" method="post"     
        action="ksu_select3.php">
    按查詢鍵, 查詢 ksu_std_table 中, 各系的學生人數. <br/>
    <br/>
    <input type="submit" name="sub" value="查詢"/>
  </form>
</body>
</html>
```
## `ksu_select3a.php`
```php
<?php
 $db_host = "localhost";
 $db_name = "ksu_database";
 $db_table = "ksu_std_table";
 $db_user = "root";
 $db_password = "";
 
 // 連結檢測
 $conn = mysqli_connect($db_host, $db_user, $db_password);
 if(empty($conn)){
	print  mysqli_error ($conn);
    die ("無法對資料庫連線！" );
	exit;
 }  
 if(!mysqli_select_db( $conn, $db_name)){
	die("資料庫不存在!");
	exit;
 }  

 //自型設定  
 mysqli_set_charset($conn,'utf8');
      
 echo "ksu_std_table  學生於各系人數顯示如下:". "<br/><br/>";  
 $result = mysqli_query($conn,
                        "SELECT ksu_std_department,ksu_std_name,ksu_std_age FROM ksu_std_table");
 echo "<table border='1'>
 <tr>
   <th> 系別 </th>  <th>學生人數 </th>  <th>年齡</th> 
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['ksu_std_name'] .   "</td>";
   echo "<td>" . $row['ksu_std_age'] . "</td>";
   echo "</tr>";
 }
 echo "</table>";
 echo "records found!"."<br/><br/>";
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# http://127.0.0.1/ksu_select3.html
# Results(執行結果)
![Midterm exam Tidy up html](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Midterm%20exam%20Tidy%20up%20html.JPG)
![Midterm exam Tidy up 2](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Midterm%20exam%20Tidy%20up%202.JPG)
___
# ● ksu_select4.html + ksu_select4.php
# 顯示搜尋結果比數
## `ksu_select4.html`
```html
<!doctype html>
<html lang="zh_tw">
<head>
  <meta charset="utf-8">
  <title>Hello</title>
</head>
<body>
  <h3> ksu select operation </h3>
  <!--不對字符編碼 -->    
  <form enctype="multipart/form-data" method="post"     
        action="ksu_select3.php">
    按查詢鍵, 查詢 ksu_std_table 中, 各系的學生人數. <br/>
    <br/>
    <input type="submit" name="sub" value="查詢"/>
  </form>
</body>
</html>
```
## `ksu_select4.php`
```php
<?php
 $db_host = "localhost";
 $db_name = "ksu_database";
 $db_table = "ksu_std_table";
 $db_user = "root";
 $db_password = "";
 
 // 連結檢測
 $conn = mysqli_connect($db_host, $db_user, $db_password);
 if(empty($conn)){
	print  mysqli_error ($conn);
    die ("無法對資料庫連線！" );
	exit;
 }  
 if(!mysqli_select_db( $conn, $db_name)){
	die("資料庫不存在!");
	exit;
 }  

 //自型設定  
 mysqli_set_charset($conn,'utf8');
      
 echo "ksu_std_table  學生於各系人數顯示如下:". "<br/><br/>";  
 $result = mysqli_query($conn,
                        "SELECT ksu_std_department, count(1) FROM ksu_std_table group by ksu_std_department");
 echo "<table border='1'>
 <tr>
   <th> 系別 </th>  <th>學生人數 </th>
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
  $row_num=0;
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   $row_num = $row_num+1;
 }
 echo "</table>";
 echo $row_num . " records found!"."<br/><br/>";
?> 

<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# 修改段落
```php
 //使用 mysqli_fetch_array() 取回資料庫資料
  $row_num=0;
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   $row_num = $row_num+1;
 }
 echo "</table>";
 echo $row_num . " records found!"."<br/><br/>";
?> 
```
# http://127.0.0.1/ksu_select3.html
# Results(執行結果)
![Midterm exam Tidy up html](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Midterm%20exam%20Tidy%20up%20html.JPG)
![Midterm exam Tidy up 3](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Midterm%20exam%20Tidy%20up%203.JPG)
___
# ● ksu_select4a.html + ksu_select4a.php
# 找出有筆資料，為空值得則有幾筆
## `ksu_select4a.html`
```html
<!doctype html>
<html lang="zh_tw">
<head>
  <meta charset="utf-8">
  <title>Hello</title>
</head>
<body>
  <h3> ksu select operation </h3>
  <!--不對字符編碼 -->    
  <form enctype="multipart/form-data" method="post"     
        action="ksu_select3.php">
    按查詢鍵, 查詢 ksu_std_table 中, 各系的學生人數. <br/>
    <br/>
    <input type="submit" name="sub" value="查詢"/>
  </form>
</body>
</html>
```
## `ksu_select4a.php`
```php
<?php
 $db_host = "localhost";
 $db_name = "ksu_database";
 $db_table = "ksu_std_table";
 $db_user = "root";
 $db_password = "";
 
 // 連結檢測
 $conn = mysqli_connect($db_host, $db_user, $db_password);
 if(empty($conn)){
	print  mysqli_error ($conn);
    die ("無法對資料庫連線！" );
	exit;
 }  
 if(!mysqli_select_db( $conn, $db_name)){
	die("資料庫不存在!");
	exit;
 }  

 //自型設定  
 mysqli_set_charset($conn,'utf8');
      
 echo "ksu_std_table  學生於各系人數顯示如下:". "<br/><br/>";  
 $result = mysqli_query($conn,
                        "SELECT ksu_std_department, count(1) FROM ksu_std_table group by ksu_std_department");
 echo "<table border='1'>
 <tr>
   <th> 系別 </th>  <th>學生人數 </th>
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
  $row_num=0;
  $row_record=0;
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   echo "</tr>";
   $row_num = $row_num+1;
   if($row['ksu_std_department'] == ""){
	$row_record = $row_record+1;
	}
 }
 
 echo "</table>";
 echo "找到 ". $row_num . " 筆資料"."<br/>";
 echo $row_record . " 筆資料為空"."<br/><br/>";
?> 

<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# 修改段落
```php
 //使用 mysqli_fetch_array() 取回資料庫資料
  $row_num=0;
  $row_record=0;
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   echo "</tr>";
   $row_num = $row_num+1;
   if($row['ksu_std_department'] == ""){
	$row_record = $row_record+1;
	}
 }
 
 echo "</table>";
 echo "找到 ". $row_num . " 筆資料"."<br/>";
 echo $row_record . " 筆資料為空"."<br/><br/>";
?> 
```
# http://127.0.0.1/ksu_select3.html
# Results(執行結果)
![Midterm exam Tidy up html](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Midterm%20exam%20Tidy%20up%20html.JPG)
![Midterm exam Tidy up 4](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Midterm%20exam%20Tidy%20up%204.JPG)
