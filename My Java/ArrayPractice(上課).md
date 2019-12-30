# 12/23
# test_string
```

public class ArrayPractice {

	public static void main(String[] args) {
		
		String test_string = "Gibson has always been a name that ranks among the elite in the
		music world.";
		String [] token = test_string.split(" ");
    
		for(int i = 0 ; i<token.length ; i++ ) {
			System.out.println(token[i]);
		}
	}
}
```
```
輸出結果：Gibson
         has
         always
         been
         a
         name
         that
         ranks
         among
         the
         elite
         in
         the
         music
         world.
```
# chinsese_string
```

public class ArrayPractice {

	public static void main(String[] args) {
		
		String test_string = "Gibson has always been a name that ranks among the elite in the
		music world.";
		
		String chinsese_string = "崑山科技大學是台灣南部地區歷史最悠久的科技大學，學風興盛人文薈萃，
		為台灣專業技術教育與應用的領航者。";	
		
		String [] token = test_string.split(" ");		
		String []token_chi = chinsese_string.split("，");
		
		for(int i = 0 ; i<token.length ; i++ ) {
			System.out.println(token[i]);
		}
		
		for(int j = 0 ; j<token_chi.length; j++ ) {
			System.out.println(token_chi[j]);
		}
	}
}
```
```
輸出結果：Gibson
         has
         always
         been
         a
         name
         that
         ranks
         among
         the
         elite
         in
         the
         music
         world.
         崑山科技大學是台灣南部地區歷史最悠久的科技大學
         學風興盛人文薈萃
         為台灣專業技術教育與應用的領航者。

```
# 改
```

public class ArrayPractice {

	public static void main(String[] args) {
		
		String test_string = "Gibson has music world.";
		String chinsese_string = "崑山科技大學是台灣南部地區歷史最悠久的科技大學，學風興盛人文薈萃，
		為台灣專業技術教育與應用的領航者。";		
		//String [] token = test_string.split(" ");
		String []token_M = {"Gibson","has","music","world"};
		String []token_chi = chinsese_string.split("，");//中文的切割用逗號
		
		for(int i = 0 ; i < token_M.length ; i++ ) {
			System.out.println("tokenM["+i+"]="+ tokenM[i]);
		}//end od for loop
		
		for(int j = 0 ; j<token_chi.length; j++ ) {
			System.out.println(token_chi[j]);
		}//end od for loop
	}//end od for main method
}
```
