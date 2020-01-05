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











