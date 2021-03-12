
## 2021-03-12
>### Ch62 - php 基本程式設計
> ### page 4  
```
<!DOCTYPE html>
<html>
    <body>
        <?php
            echo "My first PHP script!";
        ?>
    </body>
</html>
```
> ### page 19
> ### PHP structure
>> ### • A PHP file (.php) normally contains HTML tags, and some PHP scripting code. <br> • Below, we have an example of a simple PHP file, with a PHP script that uses a built-in PHP function "echo" to output the text "Hello World!" on a web page:

```
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
>>• In PHP, keywords (e.g. if, else, while, echo, etc.), classes, functions, and built-in functions are case-insensitive.<br>• In the example below, all three echo statements below are equal and legal:
```
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
>> • However; all variable names are case-sensitive! <br> • Look at the example below; only the first statement will display the value of the $color variable! <br> This is because $color, $COLOR, and $coLOR are treated as three different variables:
```
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
