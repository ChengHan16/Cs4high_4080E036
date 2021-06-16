# ● ksu_update1.php
### ksu_update1.html
```html
<!doctype html>
<html lang="zh_tw">
<head>
	<meta charset="utf-8">
	<title>Hello</title>
</head>
   Update Options <br><br>
<body>
 
  
	<form enctype="multipart/form-data"  method="post" action="ksu_update1.php">
	  學生的學號:<input type="text" name="number" size="10"/><br><br>
	  學生的新姓名:<input type="text" name="name" size="10"/><br>
	   <br><br>
	  
	  <input type="submit" name="sub" value="修改"/>

	</form>
 

</body>
</html>
```
### ksu_update1.php
```php
<?php
 // php code with sql update + no key  
 $number=str_replace("'","''",$_REQUEST['number']); 
 $name=str_replace("'","''",$_REQUEST['name']);
 
 $db_host = "localhost";
 $db_name = "ksu_database";
 $db_table = "ksu_std_table";
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
 }
 mysqli_set_charset($conn,'utf8');	
 
 $result = mysqli_query($conn,
           "UPDATE $db_table SET ksu_std_name='$name' where ksu_std_id='$number'");
 
 $updated_rows =mysqli_affected_rows($conn);
 
 if ($updated_rows != 0) {
	 echo "<br> <br>";
     echo "學號     新姓名  <br>";
     echo $number . "    ". $name . "<br>";
	 echo "1 record updated". "<br><br>";
 }
 else {
	 echo "<br> <br>";
	 echo "於 ksu_std_table中,找不到學生學號" . $number . "無法更新學生姓名<br><br>";
 }
 
 echo "<form enctype=\"multipart/form-data\"  method=\"post\" action=\"ksu_update1.html\">";
 echo "<input type=\"submit\" name=\"sub\" value=\"返回\"/>";
 echo "</form>";

?>
```
