
# review
##### 模擬考題
##### • 問題 1: 寫出一個Java類別，名稱Robot機器人
  ##### public class Robot

##### • 問題 2: 為 Robot 機器人 ) 定義三個全域變數。分別表示機器人的X座標、Y座標、前進方向。
##### public class Robot
 ##### private int x 機器人的 X 座標
 ##### private int y 機器人的 X 座標
 ##### private char direction 機器人 的 前進 方向 N,S,E,W
##### }
##### • 問題3 為 Robot 機器人) 針對全域變數，完成建構子的定義。
##### public class Robot
##### private int x 機器人的 X 座標
##### private int y 機器人的 X 座標
##### private char direction 機器人的前進 方向
##### public Robot(int x, int y, int direction){ // 類別建構子
##### this.x = x; 透過建構子，將參數 x 的值傳給 全域變數 x
##### this.y = y; 透過建構子，將 參數 y 的 值傳給 全域 變數 y
##### this.direction = direction; 將參數 direction 的 值傳給 全域 變數 direction
 #####  }
##### }
##### • 問題 4 為 Robot 機器人 ) 的三個全域變數，分別寫出get副函 式 : 取得 全域 變數的值及
##### set 副函式設定全域變數的值 。
##### 問題 5 定義一個副函式，可以print類別Robot三個全域變數的值
##### 問題 6: 在主函式中，建立 三個 Robot 類別的物件，並呼叫使用set副函式、get副函式及printAll
##### 副函式等副函式共10次以上 。
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
