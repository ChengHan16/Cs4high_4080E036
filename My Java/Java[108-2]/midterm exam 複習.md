# Midterm exam 複習
```
package myPackage;

public class MyMath2 {

public static void main(String[] args) {
int x = 10;
System.out.println(x*x*x);
}
}
```
```
package myPackage;

public class MyMath3 {

public static void main(String[] args) {
int x = 10;
int y = 20;
int z = 30;
System.out.println(x+y+z);
}
}
```
```
package myPackage;

public class MyMath4 {

public static void main(String[] args) {
 int i,sum = 0;
 for (i = 1 ; i <= 100 ; i++)
 {
 sum += i;
 }
 System.out.println(sum); //輸出結果
}
}
```
```
package myPackage;

public class MyMath5 {

public static void main(String[] args) {
sum1to100();
}
public static void sum1to100() {
int i,sum = 0;

 for (i = 1 ; i <= 100 ; i++)
 {
 sum += i;
 }
 System.out.println(sum); //輸出結果
}
}
```
```
package myPackage;

import java.util.Scanner;

public class MyMath1 {

public static void main(String[] args) {
int N ;
Scanner scanner = new Scanner(System.in);
System.out.println("請輸入一個數字：");
N = scanner.nextInt();
sum1toN(N);
}

public static void sum1toN(int N) {
System.out.println(1+2+3+4+5+6+ N );
}
}
```
# -----------------------------------------------------------------------
```
package myPackage;

public class MyClass {
	
	public static void main (String[]args) {
		System.out.println("資工一A/4080E036/吳承翰");
		
	}
	
}
```
```
package myPackage;

public class MyMath {

	public static void main(String[] args) {
		int x = 10;
		//int result = x*x*x;
		System.out.println(x*x*x);
		//System.out.println(result);
		
	}

}

//長整數 long x =10;
//		 long result = x*x*x*x*x*x*x*x*x*x;

```
```
package myPackage;

public class MyMath1 {

	public static void main(String[] args) {
		int x = 10;
		int y = 20;
		int z = 30;
		System.out.println(x+y+z);

	}

}
```
```
package myPackage;

public class MyMath2 {

	public static void main(String[] args) {
		int i ;
		for(i=0;i<101;i++) {
			System.out.println(i);
		}

	}

}
```
# 中階考題 1
```
package myPackage;

public class MyMath3 {

	public static void main(String[] args) {
		Math();
	}
	public static void Math() {
		int i ;
		for(i=0;i<101;i++) {
			System.out.println(i);
		}
	}

}
```
# 中階考題 2
```
package myPackage;
import java.util.Scanner;

public class MyMath中階2 {

	public static void main(String[] args) {
		int N;
		Scanner scanner = new Scanner(System.in);
		System.out.println("請輸入一個數字：");
		N = scanner.nextInt();
		System.out.println(1+2+3+4+5+N);
	}

}
```
