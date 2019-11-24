# 班級人數(建構子練習)
```
package Ksu;

public class A {
	static String a1;//存放班級名稱
	static int a2;//存放班級人數
	
	public A() {//預設建構子，沒有參數， () 是空的 
		a1 = "無班級";
		a2 = 0;
	}
	
	public A(String aa1,int aa2) {//自訂建構子(區域變數)自定義建構子1個以上的參數
		a1 = aa1;
		a2 = aa2;
	}
	
	public static void methodA() {
		System.out.printf("%s,%d\n",a1,a2);
	}
}
```
```
package Ksu;

public class B {

	public static void main(String[] args) {
		A obj1 = new A();//new 是 建立新類別 的關鍵字
		obj1.methodA();
		//建立一個A類別的物件使用預設建構子
		A obj2 = new A("資工一A",40);
		obj2.methodA();
		//建立一個A類別的物件obj2使用自定義建構子
	}//主函式結束
}//類別結束
```
```
輸出結果：
無班級,0
資工一A,40
```
