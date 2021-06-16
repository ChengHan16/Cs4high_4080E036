# ● ksu_select7.html + ksu_select7.php
### ksu_select7.html
```html

<!doctype html>
<html lang="zh_tw">
<head>
  <meta charset="utf-8">
  <title>Hello</title>
</head>
<body>
  <h3> ksu select+file operation </h3>
 
  <form enctype="multipart/form-data"  method="post" action="ksu_select+file1.php">
   按查詢鍵, 查詢 ksu_std_table 中, 各系的學生人數.  <br>
   並同時將網頁顯示結果寫入 .txt檔案內 <br>
   <br/>
   <input type="submit" name="sub" value="查詢"/>
  </form>

</body>
</html>
```
### ksu_select7.php
```php
<?php
 $db_host = "localhost";
 $db_name = "ksu_database";
 $db_table = "ksu_cstd_table";

 $db_user = "root";
 $db_password = "";
 $conn = mysqli_connect($db_host, $db_user, $db_password);
 if(empty($conn)){
	print  mysqli_error ($conn);
    die ("無法對資料庫連線！" );
	exit;
 }  
 if(!mysqli_select_db( $conn, $db_name)){
	die("資料庫不存在!");
	exit;
 }  mysqli_set_charset($conn,'utf8');
      
 // new added
 $myfile = fopen("ksu_inputfile01.txt", "w") 
    or die("Unable to open file!");

 echo "ksu_std_table  學生於各系人數顯示如下, 且同時寫入file:";   
 $result = mysqli_query($conn,"SELECT ksu_std_department, count(1) FROM ksu_std_table group by ksu_std_department");
 echo "<table border='1'>
 <tr>
   <th> 系別 </th>  <th>學生人數 </th> 
 </tr>";

 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   echo "</tr>";
   // new added
   $txt = $row['ksu_std_department'] ."-".$row['count(1)']."\n";
	fwrite($myfile, $txt) 
	   or die("Unable to write to file!");
   
 }
 echo "</table>";
 echo "records found!";
 // new added
 fclose($myfile); 
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_select+file1.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
