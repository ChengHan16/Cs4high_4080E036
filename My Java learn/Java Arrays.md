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
