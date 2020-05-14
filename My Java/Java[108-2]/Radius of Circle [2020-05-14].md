# [2020-05-14]
```
import java.util.Scanner;

public class number {
	 public static void main(String[] args) {
	  double r;
	  final double pi = 3.141592654; 
	  Scanner in = new Scanner(System.in);
	  System.out.print("請輸入圓半徑長度：");
	  r = in.nextInt();
	  in.close();
	  System.out.println("圓面積："+(r*r*pi));
	 }
	}
```
輸出結果：
```
請輸入圓半徑長度：1
圓面積：3.141592654
```
