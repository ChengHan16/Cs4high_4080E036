# Java Arrays
# access_the_Elements_of_an_Array
```

public class access_the_Elements_of_an_Array {
	
  public static void main(String[] args) {
	  
    String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
    
    System.out.println(cars[0]+"\n");
    //System.out.println(cars[0])
    System.out.println(cars[1]+"\n");
    
    System.out.println(cars[3]+"\n");
  
  }
  
}
```
# 輸出結果：
```
Volvo

BMW

Mazda
```
# array_Length
```

public class array_Length {
	
	  public static void main(String[] args) {
		  
		    String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
		    
		    System.out.println(cars.length);
	 }
}

```
# 輸出結果：
```
4
```
# change_an_Array_Element
```
public class change_an_Array_Element {
	
	  public static void main(String[] args) {
		  
		    String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
		    
		    cars[0] = "Opel";
		    
		    System.out.println(cars[0]+"\n");
		    
		    System.out.println(cars[2]+"\n");
		    
		    System.out.println(cars[3]+"\n");
	}
}
```
# 輸出結果：
```
Opel

Ford

Mazda
```
# loop_Through_an_Array_with_For_Each
```

public class loop_Through_an_Array_with_For_Each {
	
	  public static void main(String[] args) {
		  
		   String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
		   
		   for (String i : cars) {
			   
		   System.out.println(i);
		   }    
	}
}

```
# 輸出結果：
```
Volvo
BMW
Ford
Mazda
```
# loop_Through_an_Array
```

public class loop_Through_an_Array {
	
	  public static void main(String[] args) {
		  
		    String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
		    
		    for (int i = 0; i < cars.length; i++) {
		    	
		    System.out.println(cars[i]);
		   }
	  }
}

```
# 輸出結果：
```
Volvo
BMW
Ford
Mazda

```
# Multidimensional_Arrays_for_loop
```

public class Multidimensional_Arrays_for_loop {
	
	   public static void main(String[] args) {
		   
		     int[][] myNumbers = { {1, 2, 3, 4}, {5, 6, 7} };
		     
		     for (int i = 0; i < myNumbers.length; ++i) {
		    	 
		        for(int j = 0; j < myNumbers[i].length; ++j) {
		        	
		           System.out.println(myNumbers[i][j]);
		       }
		  }
	 }
}

```
# 輸出結果：
```
1
2
3
4
5
6
7
```
# Multidimensional_Arrays
```

public class Multidimensional_Arrays {
	
	  public static void main(String[] args) {
		  
		    int[][] myNumbers = { {1, 2, 3, 4}, {5, 6, 7} };
		    
		    int x = myNumbers[1][2];
		    
		    System.out.println(x);  
	 }
}
```
# 輸出結果：
```
7
```
[Back to Top](#readme)
