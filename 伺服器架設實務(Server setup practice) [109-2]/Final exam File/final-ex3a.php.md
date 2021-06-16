# ● final-ex3a.php
### final-ex3a.php
```php
<?php
 $myfile1 = fopen("ksu_inputfile-a.txt", "a+") 
    or die("Unable to open file!"); 

 $myfile2 = fopen("ksu_outputfile.txt", "w") 
    or die("Unable to open file!");	
	
  // Output one line until end-of-file
  $count=0;
  
 while(!feof($myfile1)) {
   $count = $count+1; 
   $tmp1 = fgets($myfile1);
   echo $count . $tmp1 . "<br>"; //顯示於browser
   fwrite($myfile2, $tmp1);//拷貝進入ksu_outputfile.txt
 }
 //加一列進入 ksu_outputfile.txt
 fwrite($myfile1, "\n- The End --");
  
 fclose($myfile1);
 fclose($myfile2);
?>
```
