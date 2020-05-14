# [2020-05-14]
```
```
# Radius of Circle 方法一
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
# Radius of Circle 方法一
```
import java.util.Scanner;

public class Radius_of_Circle {
	
	static final private  double PI =3.1415;//Final 修飾 是不能更改
	static Scanner in =new Scanner(System.in);

	public static void main(String[] args) {
		System.out.print("請輸入一個數字");
		int a = in.nextInt();
		System.out.println("你輸入的數字是--->"+a);
		System.out.println("圓面積："+(a*a*PI));
	}

}
```
輸出結果：
```
請輸入一個數字2
你輸入的數字是--->2
圓面積：12.566
```
