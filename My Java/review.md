
# review
##### 模擬考題
##### •問題 1: 寫出一個 Java 類別，名稱 Robot 機器人
  ##### public class Robot

##### •問題 2: 為 Robot 機器人 ) 定義三個全域變數。
##### 分別表示機器人的 X 座標、 Y 座標、前進方向。
##### public class Robot
 ##### private int x 機器人的 X 座標
 ##### private int y 機器人的 X 座標
 ##### private char direction 機器人 的 前進 方向 N,S,E,W
#####}
19
15
分
```
public class Robot {
	int X;
	int Y;
	int direction; 
	
	public Robot() {}
	
	public Robot(int X,int Y,int direction) {
		this.X=X;
		this.Y=Y;
		this.direction=direction;
	}
	
	public int getX() {
		return X;
	}
	
	public int getY() {
		return Y;
	}
	
	public int getdirection() {
		return direction;
	}
	
	public void setX(int X) {
		this.X=X;
	}
	
	public void setY(int Y) {
		this.Y=Y;
	}
	
	public void setdirection(int direction) {
		this.direction=direction;
	}
	
	public void printRobot() {
		System.out.println("機器人X座標："+X+"\n"+"機器人Y座標："+Y+"\n"+"機器人方向："+direction+"\n");
	}
	
	public static void main(String[] args) {
		Robot obj_r1 = new Robot(0,3,'S');
		obj_r1.printRobot();
		
		Robot obj_r2 = new Robot(0,0,'N');
		obj_r2.printRobot();
		
		Robot obj_r3 = new Robot(2,5,'W');
		obj_r3.printRobot();
		
		obj_r3.setY(3);
		obj_r3.printRobot();
		System.out.println(obj_r3.direction);
		}
}
```
```
執行結果：
機器人X座標：0
機器人Y座標：3
機器人方向：83

機器人X座標：0
機器人Y座標：0
機器人方向：78

機器人X座標：2
機器人Y座標：5
機器人方向：87

機器人X座標：2
機器人Y座標：3
機器人方向：87

87
```
