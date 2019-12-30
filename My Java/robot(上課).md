# 12/30
# map
```

public class Map {
	private int x_size;
	private int y_size;
	private int num_of_blocks;
	private int []BX;
	private int []BY;
	private int x_star;
	private int y_star;
	private int x_end;
	private int y_end;

	public Map(int x_size,int y_size,int num_of_blocks) {//讓Use決定大小
		this.x_size = x_size;
		this.y_size = y_size;
		this.num_of_blocks = num_of_blocks;
		BX = new int [num_of_blocks];
		BY = new int [num_of_blocks];
		generateBlocksXY();
		x_star = 0;
		y_star = 0;
		x_end = x_size;
		y_end = y_size;
	}

	public void generateBlocksXY() {
		for(int i=0 ; i<num_of_blocks ; i++) {
			BX[i]=(int)(Math.random()*(x_size-1))+1;//Math.random自動產生隨機亂數
		    BY[i]=(int)(Math.random()*(y_size-1))+1;
		    
		    if(BX[i]==x_end && BY[i] ==y_end) {
		    	i--;
		    }
		    else if(BX[i]==x_star && BY[i] ==y_star) {
		    	i--;
		    }

	    }
    }

	public void showMap() {
		System.out.println("x_size ="+ x_size);
		System.out.println("y_size ="+ y_size);
		System.out.println("x_star ="+ x_star);
		System.out.println("y_star ="+ y_star);
		System.out.println("x_end ="+ x_end);
		System.out.println("y_end ="+ y_end);
		System.out.println("num_of_blocks"+ num_of_blocks);
		  for(int i = 0; i < num_of_blocks; i++) {
	            System.out.println("("+BX[i]+","+BY[i]+")");
	        }
		
	}
}


//int a_x=1;  //分開儲存座標整數
//int a_y=2;
//int b_x=3;
//int b_y=4;
//int c_x=2;
//int c_y=6;

// int[]B =new int[5]; //陣列
///int[]B =new int[100];
```
```
	public void generateBlocksXY() {
		for(int i=0 ; i<num_of_blocks ; i++ ) {
			BX[i]=(i+1);
		    BY[i]=(i+1);
		}
	}

```
# Game
```

public class Game {

	public static void main(String[] args) {
		Map obj_map1 = new Map(5,7,3);
		obj_map1.showMap();
	}
}

```
```

public class map {
	int x_size;
	int y_size;
	
	int a_x=1;  //分開儲存座標整數
	int a_y=2;
	int b_x=3;
	int b_y=4;
	int c_x=2;
	int c_y=6;
	
	int[]B =new int[5]; //陣列
	///int[]B =new int[100];
	
	int num_of_blocks=3;
	int[]Bx= new int [num_of_blocks];
	int[]By= new int [num_of_blocks];
	
	int x_star;
	int y_star;
	int x_end;
	int y_end;
	
```
