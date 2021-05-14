# ● 2021-03-12
> ### Ch62 - php 基本程式設計
> ### page 4  
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            echo "My first PHP script!";
        ?>
    </body>
</html>
```
> ### page 15
> ### What's new in PHP 7
> ### • PHP 7 is much faster than the previous popular stable release (PHP 5.6) <br> • PHP 7 has improved Error Handling <br> • PHP 7 supports stricter Type Declarations for function arguments<br>• PHP 7 supports new operators (like the spaceship operator: <=> )
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
           $color = "red";
           echo "My car is" . $color . "<br>";
           echo "My house is" . $color . "<br>";
           echo "My cboat is" . $color . "<br>";
        ?>
    </body>
</html>
```
# [●] PHP Syntax
> ### page 19
> ### PHP structure
> ### • A PHP file (.php) normally contains HTML tags, and some PHP scripting code. <br> • Below, we have an example of a simple PHP file, with a PHP script that uses a built-in PHP function "echo" to output the text "Hello World!" on a web page:

```php
<!DOCTYPE html>
<html>
    <body>
        <h1>My first PHP page</h1>
            <?php
                echo "Hello World";
            ?>
    </body>
</html>
```
> ### page 20
> ### PHP Case in-sensitivity
> ### • In PHP, keywords (e.g. if, else, while, echo, etc.), classes, functions, and built-in functions are case-insensitive.<br>• In the example below, all three echo statements below are equal and legal:
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            ECHO "Hello World!<br>";
            echo "Hello World!<br>";
            EcHo "Hello World!<br>";
        ?>
    </body>
</html>
```
> ### page 21
> ### Case-sensitive
> ### • However; all variable names are case-sensitive! <br> • Look at the example below; only the first statement will display the value of the $color variable! <br> This is because $color, $COLOR, and $coLOR are treated as three different variables:
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
           $color = "red";
           echo "My car is" . $color . "<br>";
           echo "My house is" . $COLOR . "<br>";
           echo "My cboat is" . $coLOR . "<br>";
        ?>
    </body>
</html>
```
> ### page 22
> ### Comments in PHP
> ### • A comment in PHP code is a line that is not executed as a part of the program. <br>  Its only purpose is to be read by someone who is looking at the code.
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
           //This is a single-line comment
           
           #This is  a also a single-line comment
        ?>
    </body>
</html>
```
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
           /*
           This is a multiple-lins comment bock
           that spans over multiple lines
           */
        ?>
    </body>
</html>
```
# [●] PHP Variables and Scopes
> ### page 24
> ### PHP Variables
> ### • Variables are "containers" for storing information. <br> • In PHP, a variable starts with the $ sign, followed by the name of the variable:
```php
<?php
    $txt = "Hello world";
    $x =  5;
    $y = 10.5;
?>
```
> ### • After the execution of the statements above, the variable $txt will hold the value ”Hello world!”, the variable $x will hold the value 5, and the variable $y will hold the value 10.5. <br> • When you assign a text value to a variable, put quotes around the value. <br> • Unlike other programming languages, PHP has no command for declaring a variable. It is created the moment you first assign a value to it.

> ### page 26
> ### Output Variables
> ### • The PHP echo statement is often used to output data to the screen. <br> • The following example will show how to output text and a variable:
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
		$txt = "W3cshools.com";
		echo "I love &txt!";
		?>

    </body>
</html>
```
> ### • The following example will produce the same output as the example above:
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
			$txt = "W3cshools.com";
			echo "I love ".$txt ."!";
		?>
    </body>
</html>
```
> ### page 27
> ### Output Variables
> ### • The following example will output the sum of two variables:
```php
<?php
    $x = 5;
    $y = 4;
    echo $x + $y;
?>
```
> ## [●] PHP Variables Scope
> ### • In PHP, variables can be assigned a value treated as a declaration anywhere in the script. <br> • The scope of a variable is the part of the script where the variable can be referenced/ used.  <br>  • PHP has three different variable scopes: <br>  &#xA0; >local <br>  &#xA0; >global <br>  &#xA0; >static


> ### page 29
> ### Global and Local Scope
> ### • A variable declared outside a function has a GLOBAL SCOPE and can only be accessed outside a function:
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            $x = 5; //global scope
            
            function myTest() {
              // using x inside this function will generate an error
                echo "<p>Variable x inside function is: $x</p>";
            }
            
            myTest();
            
            echo "<p>Variable x outside function : $x</p>";
        ?>
    </body>
</html>
```
> ### page 30
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            $x = 5; //global scope
            
            function myTest() {
              // using x inside this function will generate an error
                echo "<p>myTest()-Variable x inside function is: $x</p>";
            }
            
            myTest();
            echo "<p>Variable x outside function is: $x</p>";
        ?>
    </body>
</html>
```
> ### Global variable setting
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            function myTest() {
            $x = 5;
              // using x inside this function will generate an error
                echo "<p>myTest()-Variable x inside function is: $x</p>";
            }
            
            myTest();
            echo "<p>Variable x outside function is: $x</p>";
        ?>
    </body>
</html>
```
> ### Local variable setting

> ### page 33
> ### Way 1: PHP The global Keyword
> ### • The global keyword is used to access a global variable from within a function for global variable sharing. <br> • To do this, use the global keyword before the variables (inside the function):
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            $x = 5; 
            $y = 10;
	    
            function myTest() {
               global $x, $y;
	       $y = $x + $y;
            }
            
            myTest();  // run function
            echo $y;   // output the new value for variable $y
        ?>
    </body>
</html>
```
# ● 2021-03-19

> ### page 34
> ### Way 2: PHP The global Keyword: $GLOBALS[index]
> ### PHP also stores all global variables in an array called $GLOBALS[index]. <br> The index holds the name of the variable. <br> This array is also accessible from within functions and can be used to update global variables directly.
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            $x = 5; 
            $y = 10;
	    
            function myTest() {
		$GLOBALS['y'] = $GLOBALS['x'] + $GLOBALS['y'];
            }
            
            myTest();
            echo "variable \$y is ?". $y;
	    echo "<p>variable \GLOBALS['y'] is".  $GLOBALS['y'];
        ?>
    </body>
</html>
```
### 執行結果
```
variable $y is ?15
variable $GLOBALS['y']is15

另一方法,存取global scope 上的變數值
```
# ● ksu_select3-SELECT 
> ### page 28 
> ### ● In PHP, variables can be assigned a value treated as a declaration anywhere in the script. <br> ● The scope of a variable is the part of the script where the variable can be referenced/ used. <br> ● PHP has three different variable scopes: <br>
> ### &#xA0; local<br>&#xA0; global<br>&#xA0; static
___
> ### $x 泛用變數 1.2.3 都可使用 <br>echo:php內建指令(api) <br> $x -> 1+3 <br>執行程序 <br> 1 -> 3 -> 2 <br> 2 結束後回呼叫的地方
___
> ### page 29 
> ### ● A variable declared outside a function has a GLOBAL SCOPE and can only be accessed outside a function:Different
```php
<!DOCTYPE html>
<html>
    <body>
        <?php 								/*1*/
            $x = 5; //global scope					/*1*/
	    
            function myTest() {						/*2*/
		//using x inside this function will generate an error
		echo "<p>Variable x inside function is: $x</p>";
            }								/*2*/
            
            myTest();							/*3*/
            echo "<p>Variable x outside function IS: $x</p>";		/*3*/
        ?>								
    </body>
</html>
```
# ● 全域變數/區域變數區分
> ### 全域變數
> ### 區域變數
> ### 泛用變數
> ### page 30
> 
```php
#Code 1
<!DOCTYPE html>
<html>
    <body>
        <?php 								
            $x = 5; //global scope					
	    
            function myTest() {						
		//using x inside this function will generate an error
		echo "<p>myTest()-Variable x inside function is: $x</p>";
            }								
            
            myTest();							
            echo "<p>Variable x outside function IS: $x</p>";		
        ?>								
    </body>
</html>
```
### 區域變數出現在那些地方
```

```
```php
#Code 2
<!DOCTYPE html>
<html>
    <body>
        <?php 												
            function myTest() {		
	    	$x = 5;
		//using x inside this function will generate an error
		echo "<p>myTest()-Variable x inside function is: $x</p>";
            }								
            
            myTest();							
            echo "<p>Variable x outside function IS: $x</p>";		
        ?>								
    </body>
</html>
```
___
# ● Way 1: PHP The global Keyword
> ### page 33
> ### 泛用/區域變數
> ### • The global keyword is used to access a global variable from within a function for global variable sharing. <br> • To do this, use the global keyword before the variables (inside the function):
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            $x = 5; 
            $y = 10;
	    
            function myTest() {
		global $x, $y;
		$y = $x + $y;
            }
            
            myTest(); // run function
	    echo $y; // output the new value for variable $y
        ?>
    </body>
</html>
```
> # ● 沒有區域變數，全泛用變數 因為加了global，區域變泛用
___
# ● Way 2: PHP The global Keyword: $GLOBALS[index]
> ### page 34
> ### • PHP also stores all global variables in an array called $GLOBALS[index].<br> • The index holds the name of the variable. <br> • This array is also accessible from within functions and can be used to update global variables directly.
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            $x = 5; 
            $y = 10;
	    
            function myTest() {
		$GLOBALS['y'] = $GLOBALS['x'] + $GLOBALS['y'];
            }
            
            myTest();
            echo "variable \$y is ?". $y;
	    echo "<p>variable \GLOBALS['y'] is".  $GLOBALS['y'];
        ?>
    </body>
</html>
```
### 執行結果
```
variable $y is ?15
variable \GLOBALS['y'] is15
```
> ### 另一方法,存取global scope上的變數值<br>
> ### page 35
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            $GLOBALS['x'] = 5; 
            $GLOBALS['y'] = 10;
	    
            function myTest() {
		$GLOBALS['y'] = $GLOBALS['x'] + $GLOBALS['y'];
            }
            
            myTest();
 	    echo $y;
        ?>
    </body>
</html>
```
## こたえ
```
15
```
> ### page 35
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            $GLOBALS['x'] = 5; 
            $GLOBALS['y'] = 10;
	    
            function myTest() {
		$x = $x + $y;
            }
            
            myTest();
 	    echo $y;
        ?>
    </body>
</html>
```
## こたえ
```
10
```
![1資料庫伺服器0319](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/1%E8%B3%87%E6%96%99%E5%BA%AB%E4%BC%BA%E6%9C%8D%E5%99%A80319.PNG)<br>
# ● PHP The static Keyword
> ### page 36
> ### • Normally, when a function is completed/ executed, all of its variables are deleted. However, sometimes we want a local variable NOT to be deleted. We need it for a further job. <br> • To do this, use the static keyword when you first declare the variable:
```php
<!DOCTYPE html>
<html>
    <body>
        <?php
            function myTest(){
	    	static $x = 0;
		echo $x;
		$x++;
	    }

            myTest();
 	    echo "<br>"; myTest();
	    echo "<br>"; myTest();
        ?>
    </body>
</html>
```
## こたえ
```
0
1
2
```
> ### • Then, each time the function is called,that variable will still have the informationit contained from the last time the function was called.<br> • Note: The variable is still local to the function.<br>

# ● static
|	|無static|有static|
|---|---|---
|$x = 0|1.$x = 0 2."空白"|1.$x = 0|
|myTest();|1.$x = 0 2."空白"|1.$x = 0|
|myTest();|1.$x = 0 |1.$x = 1|
___
# 03-26
# Exercise 1.
## http://127.0.0.1/ksu_select3.html
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
## `ksu_select3.php`
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
# Results(執行結果)
![伺服器資料庫](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E4%BC%BA%E6%9C%8D%E5%99%A8%E8%B3%87%E6%96%99%E5%BA%AB1.JPG)
# Exercise 2.
## http://127.0.0.1/ksu_select3.html
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
## `ksu_select3.php`
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
# Results(執行結果)
![伺服器資料庫2](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E4%BC%BA%E6%9C%8D%E5%99%A8%E8%B3%87%E6%96%99%E5%BA%AB2.JPG)
# Exercise 3.
![伺服器資料庫_練習3](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E4%BC%BA%E6%9C%8D%E5%99%A8%E8%B3%87%E6%96%99%E5%BA%AB_%E7%B7%B4%E7%BF%923.JPG)
## http://127.0.0.1/ksu_select3.html
## `ksu_select3.html`
![伺服器資料庫_練習3](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E4%BC%BA%E6%9C%8D%E5%99%A8%E8%B3%87%E6%96%99%E5%BA%AB_%E7%B7%B4%E7%BF%923.JPG)
## http://127.0.0.1/ksu_select3.html
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
    按查詢鍵, 進階查詢 ksu_std_table
	<br>
	<br>
	學生系別：<input type="text" name="Department" size="3"/>
	<br>
	<br>
    <input type="submit" value="查詢"/>
  </form>
</body>
</html>
```
![SQL作業1碼](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/SQL%E4%BD%9C%E6%A5%AD1%E7%A2%BC.JPG)
```sql
SELECT ksu_std_name AS 學生姓名,ksu_std_grade AS 學生成績,(CASE when ksu_std_grade>=60 then ' ' else '補考' end) AS 備住
FROM ksu_std_table WHERE ksu_std_department LIKE '%CS%' ORDER BY ksu_std_grade ASC
```
## `ksu_select3.php`
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
                        "SELECT ksu_std_name,ksu_std_grade
							FROM ksu_std_table WHERE ksu_std_department LIKE '%" . $_POST["Department"] . "%' ORDER BY ksu_std_grade ASC");
 echo "<table border='1'>
 <tr>
   <th> 學生姓名 </th>  <th> 學生成績 </th>  <th> 備註 </th> 
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_name'] . "</td>";
   echo "<td>" . $row['ksu_std_grade'] . "</td>";
   if ($row['ksu_std_grade'] < 60) {
      echo '<td style="background-color:yellow">補考</td>';
   } else {
	  echo '<td></td>';
   }
   echo "</tr>";
 }
 echo "</table>";
 echo "records found!"."<br/><br/>";
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# Results(執行結果)
![1資料庫伺服器04-15](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/1%E8%B3%87%E6%96%99%E5%BA%AB%E4%BC%BA%E6%9C%8D%E5%99%A804-15.PNG)
___
# ● 2021-04-16
## 顯示搜尋結果比數
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
# Results(執行結果)
![1.04_16伺服資料庫](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/1.04_16%E4%BC%BA%E6%9C%8D%E8%B3%87%E6%96%99%E5%BA%AB.PNG)
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
   <th> 系別 </th>  <th> 學生人數 </th>  <th>年齡</th> 
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
  $row_num=0;
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['ksu_std_name'] .   "</td>";
   echo "<td>" . $row['ksu_std_age'] . "</td>";
   echo "</tr>";
   $row_num = $row_num+1;
 }
 echo "</table>";
 echo $row_num . " records found!"."<br/><br/>";
?> 

<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# Results(執行結果)
![2.04_16伺服資料庫](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/2.04_16%E4%BC%BA%E6%9C%8D%E8%B3%87%E6%96%99%E5%BA%AB.PNG)
# 編寫段落
#### //使用 mysqli_fetch_array() 取回資料庫資料
#### `$row_num=0;`
#### while($row = mysqli_fetch_array($result))<br>{<br>echo "<tr>";<br>echo "<td>" . $row['ksu_std_department'] . "</td>";<br>echo "<td>" . $row['ksu_std_name'] .   "</td>";<br>echo "<td>" . $row['ksu_std_age'] . "</td>";<br>echo "</tr>";<br>
#### `$row_num = $row_num+1;`
#### }<br>echo "</table>";
#### `echo $row_num . " records found!"."<br/><br/>";`
#### ?> 

# Results(執行結果)
## `$row_num搜尋的筆數` records found!<br>EX. 5 records found!
___
# 顯示 ksu_std_department 內空值的筆數
## 顯示結果須為　1 records found!
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
  $row_record=0;
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   if($row['ksu_std_department'] == ""){
		$row_record = $row_record+1;
		}
 }
 echo "</table>";
 echo $row_record . " records found!"."<br/><br/>";
?> 

<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# 編寫段落
## 31 row
#### //使用 mysqli_fetch_array() 取回資料庫資料
#### `$row_record=0;`
#### while($row = mysqli_fetch_array($result))<br>{<br>echo "<tr>";<br>echo "<td>" . $row['ksu_std_department'] . "</td>";<br>echo "<td>" . $row['count(1)'] .   "</td>";<br>`
#### `if($row['ksu_std_department'] == ""){`
#### `$row_record = $row_record+1;`
#### }
#### }
#### echo "</table>";<br>`echo $row_record . " records found!"."<br/><br/>";`
#### ?> 
# 找出有筆資料，為空值得則有幾筆
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
 echo "找到". $row_num . "筆資料"."<br/><br/>";
 echo "為空的有". $row_record . "筆資料"."<br/><br/>";
?> 

<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# Results(執行結果)
![3.04_16伺服資料庫](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/3.04_16%E4%BC%BA%E6%9C%8D%E8%B3%87%E6%96%99%E5%BA%AB.PNG)
# 編寫段落
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
 echo "找到". $row_num . "筆資料"."<br/><br/>";
 echo "為空的有". $row_record . "筆資料"."<br/><br/>";
```
# php 一個等號是指定，2個等號是判斷
# [俊齊老師指導 Code]()
```php
//使用 mysqli_fetch_array() 取回資料庫資料
  $row_num=0;
  $row_empty=0;

 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   echo "</tr>";
   $row_num = $row_num+1;
   if($row['ksu_std_department'] == ""){
   # if($row['ksu_std_department'] == null){
	$row_empty = $row_empty+1;
	}
 }
 
 echo "</table>";
 echo "找到 ". $row_num . " 筆資料"."<br/>";
 echo $row_empty . " 筆資料為空"."<br/><br/>";
```
# Results(執行結果)
![4.04_16伺服資料庫(俊齊)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/4.04_16%E4%BC%BA%E6%9C%8D%E8%B3%87%E6%96%99%E5%BA%AB(%E4%BF%8A%E9%BD%8A).PNG)
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
  $row_empty=0;
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_department'] . "</td>";
   echo "<td>" . $row['count(1)'] .   "</td>";
   echo "</tr>";
   $row_num = $row_num+1;
   if($row['ksu_std_department'] == isset){
	$row_empty = $row_empty+1;
	}
   if($row['ksu_std_department'] == ""){
	$row_record = $row_record+1;
	}
 }
 
 echo "</table>";
 echo "找到 ". $row_num . " 筆資料"."<br/>";
 echo $row_record . " 筆資料為空"."<br/>";
 echo $row_empty . " 筆有資料"."<br/><br/>";
?> 

<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# 進階題
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
    按查詢鍵, 進階查詢 ksu_std_table
	<br>
	<br>
	學生系別：<input type="text" value="CS" name="dept" size="2"/>
	<br>
	<br>
    <input type="submit" name="sub "value="查詢"/>
  </form>
</body>
</html>
```
```php
<?php
 $dept=str_replace("'","''",$REQUEST['dept']);

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
                        "SELECT ksu_std_name,ksu_std_grade
							FROM ksu_std_table WHERE ksu_std_department LIKE '%" . $_POST["dept"] . "%' ORDER BY ksu_std_grade ASC");
 echo "<table border='1'>
 <tr>
   <th> 學生姓名 </th>  <th> 學生成績 </th>  <th> 備註 </th> 
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_name'] . "</td>";
   echo "<td>" . $row['ksu_std_grade'] . "</td>";
   if ($row['ksu_std_grade'] < 60) {
      echo '<td style="background-color:yellow">補考</td>';
   } else {
	  echo '<td></td>';
   }
   echo "</tr>";
 }
 echo "</table>";
 echo "records found!"."<br/><br/>";
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# 編寫段落 
```html
<form enctype="multipart/form-data" method="post"     
        action="ksu_select3.php">
    按查詢鍵, 進階查詢 ksu_std_table
	<br>
	<br>
	學生系別：<input type="text" value="CS" name="dept" size="2"/>
	<br>
	<br>
    <input type="submit" name="sub "value="查詢"/>
  </form>
```
```php
<?php
 $dept=str_replace("'","''",$REQUEST['dept']);

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
                        "SELECT ksu_std_name,ksu_std_grade
							FROM ksu_std_table WHERE ksu_std_department LIKE '%" . $_POST["dept"] . "%' ORDER BY ksu_std_grade ASC");
 echo "<table border='1'>
 <tr>
   <th> 學生姓名 </th>  <th> 學生成績 </th>  <th> 備註 </th> 
 </tr>";

 //使用 mysqli_fetch_array() 取回資料庫資料
 while($row = mysqli_fetch_array($result))
 {
   echo "<tr>";
   echo "<td>" . $row['ksu_std_name'] . "</td>";
   echo "<td>" . $row['ksu_std_grade'] . "</td>";
   if ($row['ksu_std_grade'] < 60) {
      echo '<td style="background-color:yellow">補考</td>';
   } else {
	  echo '<td></td>';
   }
   echo "</tr>";
 }
 echo "</table>";
 echo "records found!"."<br/><br/>";
?> 
<form enctype="multipart/form-data"  method="post" action="ksu_select3.html">
<input type="submit" name="sub" value="返回"/>
</form>
```
# ● 2021-05-07
---
# ● 2021-05-14

---
