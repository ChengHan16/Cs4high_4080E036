# ● 2021-05-07
## ● 1 
### `ksu_midterm1.html`
```html
<!doctype html>
<html>
<head>
  <meta charset="utf-8">
  <title>Select exercise</title>
</head>
<body>
  <h3> ksu select operation </h3>
  <!--不對字符編碼 -->    
  <form enctype="multipart/form-data" method="post"     
        action="ksu_midterm1.php">
    按查詢鍵, 查詢 ksu_std_table 中,所有學生姓名, 學號,  成績. <br/>
    <br/>
    <input type="submit" name="sub" value="查詢"/>
  </form>
</body>
</html>
```
### `ksu_midterm1.php`
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
                        "SELECT ksu_std_name, ksu_std_id, ksu_std_grade
 						 FROM   ksu_std_table");
 echo "<table border='1'>
 <tr>
   <th>學生姓名 </th> <th>學號</th> <th>分數</th>
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_name'] . "</td>";
   echo "<td>" . $row['ksu_std_id'] .   "</td>";
   echo "<td>" . $row['ksu_std_grade'] .   "</td>";
   echo "</tr>";
 }
 echo "</table>";
 echo "records found!"."<br/><br/>";
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_midterm1.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
## ● 2 
### `ksu_midterm2.html`
```html
<!doctype html>
<html>
<head>
  <meta charset="utf-8">
  <title>Select exercise</title>
</head>
<body>
  <h3> ksu select operation </h3>
  <!--不對字符編碼 -->    
  <form enctype="multipart/form-data" method="post"     
        action="ksu_midterm2.php">
    按查詢鍵, 查詢 ksu_std_table 中,所有學生姓名, 學號,  成績. <br/>
	並顯示其中成績為100分的人數與總人數.     
    <br/>
    <input type="submit" name="sub" value="查詢"/>
  </form>
</body>
</html>
```
### `ksu_midterm2.php`
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
                        "SELECT ksu_std_name, ksu_std_id, ksu_std_grade
 						 FROM   ksu_std_table");
 echo "<table border='1'>
 <tr>
   <th>學生姓名 </th> <th>學號</th> <th>分數</th>
 </tr>";

 $num=0;
 $num_100=0;
 //使用 mysqli_fetch_array() 取回資料庫資料
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_name'] . "</td>";
   echo "<td>" . $row['ksu_std_id'] .   "</td>";
   echo "<td>" . $row['ksu_std_grade'] .   "</td>";
   echo "</tr>";
   $num=$num+1;
   if ($row['ksu_std_grade']  == 100)
	   $num_100=$num_100+1;
 }
 echo "</table>";
 echo "共". $num . "名學生, 其中 ". $num_100 . "名學生, 成績是 100分" .  "<br/><br/>";
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_midterm2.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
## ● 3 
### `ksu_midterm3.html`
```html
<!doctype html>
<html>
<head>
  <meta charset="utf-8">
  <title>Select exercise</title>
</head>
<body>
  <h3> ksu select operation </h3>
  <!--不對字符編碼 -->    
  <form enctype="multipart/form-data" method="post"     
        action="ksu_midterm3.php">
    按查詢鍵, 查詢 ksu_std_table 中,所有學生姓名, 學號,  成績. <br/>
	並顯示其中成績為100分的人數與總人數. 
    100分者須標記為藍色
    <br/> <br/>
    <input type="submit" name="sub" value="查詢"/>
  </form>
</body>
</html>
```
### `ksu_midterm3.php`
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
                        "SELECT ksu_std_name, ksu_std_id, ksu_std_grade
 						 FROM   ksu_std_table");
 echo "<table border='1'>
 <tr>
  <th> 備註 </th> <th>學生姓名 </th> <th>學號</th> <th>分數</th>
 </tr>";

 $num=0;
 $num_100=0;
 //使用 mysqli_fetch_array() 取回資料庫資料
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   $num=$num+1;
   if ($row['ksu_std_grade']  == 100){
	   $num_100=$num_100+1;
        echo "<td style=\"background-color:blue;\">" . "" . "</td>";
   }
   else{
	   echo "<td>" . "" . "</td>";
   }
	   
   echo "<td>" . $row['ksu_std_name'] . "</td>";
   echo "<td>" . $row['ksu_std_id'] .   "</td>";
   echo "<td>" . $row['ksu_std_grade'] .   "</td>";
   echo "</tr>";
 }  
 echo "</table>";
 echo "共". $num . "名學生, 其中 ". $num_100 . "名學生, 成績是 100分" .  "<br/><br/>";
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_midterm3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```





