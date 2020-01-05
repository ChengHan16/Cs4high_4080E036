# Java Constructor(建構子、全域變數、區域變數)
```

public class Constructor_review {
		private String Vocalists ;//主唱
		private String Drummer   ;//鼓手
		private String Groupies  ;//吉他
		private String Bass      ;//貝斯
		
		public Constructor_review() {}
		
		public Constructor_review(String V,String D,String G,String B) {
			this.Vocalists=V;
			this.Drummer=D;
			this.Groupies=G;
			this.Bass=B;
		}
		public void printfConstructor() {
			System.out.println("主唱："+Vocalists+" "+"鼓手："+Drummer+" "+"吉他手："+Groupies+" "+"貝斯手："+Bass);
		}
		
		public static void main(String[]args) {
			Constructor_review obj_c1 = new Constructor_review("01","02","03","04");
			obj_c1.printfConstructor();
			Constructor_review obj_c2 = new Constructor_review("Harry","Kenwick","Wangzunxian","Ailen");
			obj_c2.printfConstructor();
		}

	}
```
```
執行結果：
主唱：01 鼓手：02 吉他手：03 貝斯手：04
主唱：Harry 鼓手：Kenwick 吉他手：Wangzunxian 貝斯手：Ailen
```
# 使用get
```

public class Constructor_review {
		private String Vocalists ;//主唱
		private String Drummer   ;//鼓手
		private String Groupies  ;//吉他
		private String Bass      ;//貝斯
		
		public Constructor_review() {}
		
		public Constructor_review(String V,String D,String G,String B) {
			this.Vocalists=V;
			this.Drummer=D;
			this.Groupies=G;
			this.Bass=B;
		}
		
		public String getGroupies() {	//void 無回傳
			return Groupies;
		}
		
		public void printfConstructor() {
			System.out.println("主唱："+Vocalists+" "+"鼓手："+Drummer+" "+"吉他手："+Groupies+" "+"貝斯手："+Bass);
		}
		
		public static void main(String[]args) {
			Constructor_review obj_c1 = new Constructor_review("01","02","03","04");
			obj_c1.printfConstructor();
			Constructor_review obj_c2 = new Constructor_review("Harry","Kenwick","Wangzunxian","Ailen");
			obj_c2.printfConstructor();
			System.out.println(obj_c2.getGroupies());
		}

	}
```
```
執行結果：
主唱：01 鼓手：02 吉他手：03 貝斯手：04
主唱：Harry 鼓手：Kenwick 吉他手：Wangzunxian 貝斯手：Ailen
Wangzunxian
```
# Set "\t" 
```
import java.util.Set;

public class Constructor_review {
		private String Vocalists ;//主唱
		private String Drummer   ;//鼓手
		private String Groupies  ;//吉他
		private String Bass      ;//貝斯
		
		public Constructor_review() {}
		
		public Constructor_review(String V,String D,String G,String B) {
			this.Vocalists=V;
			this.Drummer=D;
			this.Groupies=G;
			this.Bass=B;
		}
		
		public void  SetVocalists(String V) {
			this.Vocalists=V;
		}

		public String getGroupies() {	//void 無回傳
			return Groupies;
		}
		
		public void printfConstructor() {
			System.out.println("主唱："+Vocalists+"\t"+"鼓手："+Drummer+"\t"+"吉他手："+Groupies+"\t"+"貝斯手："+Bass+"\t");
		}   //"\t"在程序里就是空格的意思。防止輸出的內容擠在一起。
		
		public static void main(String[]args) {
			Constructor_review obj_c1 = new Constructor_review("A","B","C","D");
			obj_c1.printfConstructor();
			
			Constructor_review obj_c2 = new Constructor_review("Harry","Kenwick","Wangzunxian","Ailen");
			obj_c2.printfConstructor();
			
			System.out.println(obj_c2.getGroupies());//get
			obj_c2.SetVocalists("Henry");
			obj_c2.printfConstructor();
		}

	}

```
```
執行結果：
主唱：A    鼓手：B    吉他手：C    貝斯手：D	
主唱：Harry    鼓手：Kenwick   吉他手：Wangzunxian    貝斯手：Ailen	
Wangzunxian
主唱：Henry    鼓手：Kenwick   吉他手：Wangzunxian    貝斯手：Ailen	
```
# Java For Loop
```
//小到大
public class Other {

	public static void main(String[] args) {
		int i ;
		for(i=1 ; i<=10 ;i++) {
			System.out.println(i);
		}
	}
}
```
```
執行結果：
1
2
3
4
5
6
7
8
9
10
```
```
//大到小
public class Other {

	public static void main(String[] args) {
		int i ;
		for(i=0 ; i>=1 ;i--) {
			System.out.println(i);
		}
	}
}
```
```
執行結果：
10
9
8
7
6
5
4
3
2
1
```
# Java While Loop
```
public class WhileLoop {

	public static void main(String[] args) {
	while (i<=10) {
			System.out.println(i+"--->Java");
			i++;
			}
		}
	}
```
```
執行結果：
1--->Java
2--->Java
3--->Java
4--->Java
5--->Java
6--->Java
7--->Java
8--->Java
9--->Java
10--->Java
```
# if else
```

public class WhileLoop {

	public static void main(String[] args) {
		int i = 10;
		while (true) {
			if ( i > 100) {
				System.out.println (i+100);
				break;
			}
			else if (i < -10 ) {
				System.out.println (i);
				break;
			}
			else {
				System.out.println (i);
				break;
			}				
		}
	}
}		
```
# Number 計算
```
public class Nnumber {

	public static void main(String[] args) {
		int i = f(0);
		System.out.printf("%d\n",f(1));
	}
	public static int f(int x) {
		int i =1*x*x+2*x+3;
		return i;
	}
}
```
```
執行結果：
6
```







