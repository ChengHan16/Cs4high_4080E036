# 12/30

# Robot
```
public class Robot {
    private int x;
    private int y;
    private char direction; //方向: 'N' ,'S', 'E', 'W'
    private Map map;
    
    public Robot(char direction, Map map) {
        this.x = map.getX_start();
        this.y = map.getY_start();
        this.direction = direction;
        this.map = map;
    }
    
    public void findGoal() {
        
        while( !((x == map.getX_end())  &&  (y==map.getY_end())) ) {
            
            if((y+1 > map.getY_end()) || map.blocksOrNot(x, y+1) ==1 ) {
                direction = 'E' ;
            }
            else if(x+1 > map.getX_end() || map.blocksOrNot(x+1, y) ==1) {
                direction = 'N' ;
            }
            
            if(direction == 'N' && (y+1 <= map.getY_end()) && map.blocksOrNot(x, y+1) == 0) {
                goNorth();
                direction = 'E' ;
            }
            else if(direction == 'E' && (x+1 <= map.getX_end())  && map.blocksOrNot(x+1, y) == 0) {
                goEast();
            }
            else if(direction == 'W' && (x-1 >= 0) && map.blocksOrNot(x-1, y) == 0) {
                goWest();        
            }
            else if(direction == 'S' && (y-1 >= 0) && map.blocksOrNot(x, y-1) == 0) {
                goSouth();
            }
        }
        
        System.out.println("Finish!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!抵達終點");
        
        
    }
    
    
    public void goNorth() {
        y = y+1;
        direction = 'N';
        System.out.println("("+x+","+(y-1)+")"+"向北走一格到("+x+","+y+")");
    }
    
    public void goSouth() {
        y = y-1;
        direction = 'E';
        System.out.println("("+x+","+(y+1)+")"+"向南走一格到("+x+","+y+")");
    }
    
    public void goEast() {
        x = x+1;
        direction = 'N';
        System.out.println("("+(x-1)+","+y+")"+"向東走一格到("+x+","+y+")");
    }

    public void goWest() {
        x = x-1;
        direction = 'E';
        System.out.println("("+(x+1)+","+y+")"+"向西走一格到("+x+","+y+")");
    }
    
    
}
```
# Map
```
public class Map {

    public int[] getBX() {
        return BX;
    }

    public void setBX(int[] bX) {
        BX = bX;
    }

    public int[] getBY() {
        return BY;
    }

    public void setBY(int[] bY) {
        BY = bY;
    }

    public int getX_start() {
        return x_start;
    }

    public void setX_start(int x_start) {
        this.x_start = x_start;
    }

    public int getX_end() {
        return x_end;
    }

    public void setX_end(int x_end) {
        this.x_end = x_end;
    }

    public int getY_end() {
        return y_end;
    }

    public void setY_end(int y_end) {
        this.y_end = y_end;
    }

    private int x_size;
    public int getY_start() {
        return y_start;
    }

    public void setY_start(int y_start) {
        this.y_start = y_start;
    }

    private int y_size;
    private int num_of_blocks;
    private int[ ] BX;
    private int[ ] BY;
    private int x_start;
    private int y_start;
    private int x_end;
    private int y_end;
    
    public Map(int x_size, int y_size, int num_of_blocks) {
        this.x_size = x_size;
        this.y_size= y_size;
        this.num_of_blocks = num_of_blocks;
        BX = new int[num_of_blocks];
        BY = new int[num_of_blocks];
        generateBlocksXY();
        x_start = 1;
        y_start = 1;
        x_end = x_size;
        y_end = y_size;
    }
    
    public void generateBlocksXY() {
        for(int i = 0; i < num_of_blocks; i++) {
            BX[i] = (int)(Math.random()*(x_size-1))+1;
            BY[i] = (int)(Math.random()*(y_size-1))+1;
            
            if(BX[i] == x_end && BY[i] == y_end) {
                i--;
            }
            else if(BX[i] == x_start && BY[i] == y_start) {
                i--;
            }
        }
    }
    
    public int blocksOrNot(int x, int y) {
        
        for(int i = 0; i < num_of_blocks; i++) {
            if(BX[i] == x && BY[i] == y) {
                return 1;
            }
        }
        return 0;
    }
    
    public void showMap() {
        System.out.println("x_size = " + x_size);
        System.out.println("y_size = " + y_size);
        System.out.println("x_start = " + x_start);
        System.out.println("y_start = " + y_start);
        System.out.println("x_end = " + x_end);
        System.out.println("y_end = " + y_end);
        System.out.println("num_of_blocks = " + num_of_blocks);
        for(int i = 0; i < num_of_blocks; i++) {
            System.out.println("("+BX[i]+","+BY[i]+")");
        }//end of for
    }//end of public void showMap()
}
```
# Game
```

public class Game {

    public static void main(String[] args) {
        // TODO Auto-generated method stub

        Map obj_map1 = new Map(5, 7, 10);
        obj_map1.showMap();
        
        Robot myRobot1 = new Robot('N', obj_map1);
        myRobot1.findGoal();
    }

}

```
```
執行結果：
x_size = 5
y_size = 7
x_start = 1
y_start = 1
x_end = 5
y_end = 7
num_of_blocks = 10
(3,1)
(4,5)
(3,2)
(1,6)
(2,1)
(4,3)
(4,4)
(3,3)
(4,3)
(4,2)
(1,1)向北走一格到(1,2)
(1,2)向東走一格到(2,2)
(2,2)向北走一格到(2,3)
(2,3)向北走一格到(2,4)
(2,4)向東走一格到(3,4)
(3,4)向北走一格到(3,5)
(3,5)向北走一格到(3,6)
(3,6)向東走一格到(4,6)
(4,6)向北走一格到(4,7)
(4,7)向東走一格到(5,7)
Finish!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!抵達終點

```
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
# Robot
```

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
