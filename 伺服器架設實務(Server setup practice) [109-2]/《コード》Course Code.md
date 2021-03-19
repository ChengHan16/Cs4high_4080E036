## ● 2021-03-12
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
## ● 2021-03-19

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
            echo "variable" \$y is ?". $y;
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
## ● ksu_select3-SELECT 
> ### page 28 
> ### ● In PHP, variables can be assigned a value treated as a declaration anywhere in the script. <br> ● The scope of a variable is the part of the script where the variable can be referenced/ used. <br> ● PHP has three different variable scopes: <br>
> ### &#xA0; local
> ### &#xA0; global
> ### &#xA0; static

> ### page 29 
> ### ● A variable declared outside a function has a GLOBAL SCOPE and can only be accessed outside a function:
Different
```

```
