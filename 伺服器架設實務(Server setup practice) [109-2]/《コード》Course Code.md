
## 2021-03-12
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
<?php
    $txt = "W3cshools.com";
    echo "I love " . &txt . "!";
?>
```
> ### • The following example will produce the same output as the example above:
```php
<?php
    $txt = "W3cshools.com";
    echo "I love "  &txt . "!";
?>
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
            
            echo "<p>Variable x outside function IS: $x</p>";
        ?>
    </body>
</html>
```
