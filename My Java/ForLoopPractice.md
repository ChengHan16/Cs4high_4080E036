# 12/16
### ForLoopPractice
### 無限迴圈
```

public class forLoopPractice {

	public static void main(String[] args) {
		
		int i;
		for( ; ; ){
			System.out.println(i+"--->What's up,java");
		}
	}
}
```
```
public class forLoopPractice {

	public static void main(String[] args) {
		
		int i;
		for(i=1;i<=10;i++) {	//i++ ---> i=i+1
			System.out.println(i+"--->What's up,java");
		}
	}
}
```
```
輸出結果：1--->What's up,java
          2--->What's up,java
          3--->What's up,java
          4--->What's up,java
          5--->What's up,java
          6--->What's up,java
          7--->What's up,java
          8--->What's up,java
          9--->What's up,java
         10--->What's up,java
```
### 顯示大到小
```

public class forLoopPractice {

	public static void main(String[] args) {
		
		int i;
		for(i=10;i>=1;i--){
			System.out.println(i+"--->What's up,java");
		}
	}
}
```
```
輸出結果：10--->What's up,java
          9--->What's up,java
          8--->What's up,java
          7--->What's up,java
          6--->What's up,java
          5--->What's up,java
          4--->What's up,java
          3--->What's up,java
          2--->What's up,java
          1--->What's up,java
```
