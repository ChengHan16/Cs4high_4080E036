# [2020-05-14]
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
# Radius of Circle 方法二(教學)
```
import java.util.Scanner;

public class Radius_of_Circle {
	
	static final private  double PI =3.1415;//Final 修飾 是不能更改
	static Scanner in =new Scanner(System.in);

	public static void main(String[] args) {
		System.out.print("請輸入一個數字");
		int a = in.nextInt();
		System.out.println("你輸入的數字是--->"+a);
		計算圓面積(a);
		計算圓周長(a);
	}
		public static void 計算圓面積(int r) {
		System.out.println(" 圓面積= "+r*r*PI);
		}
		
		public static void 計算圓周長(int r) {
			System.out.println(" 圓周長= "+r*2*PI);
		}
	}
```
輸出結果：
```
你輸入的數字是--->3
 圓面積= 28.273500000000002
 圓周長= 18.849
```
# Radius_of_Circle_nextDouble [Double浮點數應用]
```
import java.util.Scanner;

public class Radius_of_Circle_nextDouble {

	static final private  double PI =3.1415;//Final 修飾 是不能更改
	static Scanner in =new Scanner(System.in);

	public static void main(String[] args) {
		System.out.print("請輸入一個數字");
		Double a = in.nextDouble();
		System.out.println("你輸入的數字是--->"+a);
		計算圓面積(a);
		計算圓周長(a);
	}
		public static void 計算圓面積(Double r) {
		System.out.println(" 圓面積= "+r*r*PI);
		}
		
		public static void 計算圓周長(Double r) {
			System.out.println(" 圓周長= "+r*2*PI);
		}
	}
```
輸出結果：
```
請輸入一個數字3
你輸入的數字是--->3.0
 圓面積= 28.273500000000002
 圓周長= 18.849
```
# 浮點數 DecimalFormat 應用 [限制浮點數顯示位數]
```
import java.text.DecimalFormat;
import java.util.Scanner;

public class Radius_of_Circle_DecimalFormat {

	static final private  double PI =3.1415;//Final 修飾 是不能更改
	static Scanner in =new Scanner(System.in);
	private static DecimalFormat df = new DecimalFormat("#.##");
	
	public static void main(String[] args) {
		System.out.print("請輸入一個數字");
		Double a = in.nextDouble();
		System.out.println("你輸入的數字是--->"+a);
		計算圓面積(a);
		計算圓周長(a);
	}
		public static void 計算圓面積(Double r) {
		System.out.println(" 圓面積= "+df.format(r*r*PI));
		}
		
		public static void 計算圓周長(Double r) {
			System.out.println(" 圓周長= "+df.format(r*2*PI));
		}
	}
```
# 輸出結果：
```
請輸入一個數字5
你輸入的數字是--->5.0
 圓面積= 78.54
 圓周長= 31.42
```
