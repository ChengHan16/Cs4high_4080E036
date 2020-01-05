# 註解板
```
public class Robot {
	int X; //機器人的 X 座標
	int Y; //機器人的 Y 座標
	int direction; //機器人 的 前進 方向 N,S,E,W
}
	public Robot() {} //預設建構子
	
	public Robot(int X,int Y,int direction) {  // 類別建構子
		this.X=X; //透過建構子，將參數 x 的值傳給 全域變數 x
		this.Y=Y; //透過建構子，將參數 y 的值傳給 全域變數 y
		this.direction=direction; //將參數 direction 的 值傳給 全域 變數 direction
	}
	
	public int getX() {
		return X; //透過 get 副函式，回傳全域變數 x 的值
	}
	
	public int getY() { 
		return Y; //透過 get 副函式，回傳全域變數 y 的值
	}
	
	public int getdirection() {
		return direction; //透過 get 副函式，回傳全域變數 direction 的值
	}
	
	public void setX(int X) {
		this.X=X; //透過 set 副函式，將參數 x 的值傳給全域變數 x
	}
	
	public void setY(int Y) {
		this.Y=Y; //透過 set 副函式，將參數 y 的值傳給全域變數 y
	}
	
	public void setdirection(int direction) {
		this.direction=direction; ////透過 set 副函式，將參數 direction 的值傳給全域變數 direction
	}
	
	public void printRobot() {
		System.out.println("機器人X座標："+X+"\n"+"機器人Y座標："+Y+"\n"+"機器人方向："+direction+"\n");
	}
	
	public static void main(String[] args) {
		Robot obj_r1 = new Robot(0,3,'S'); //建立物件 obj_r1
		obj_r1.printRobot(); //呼叫使用副函式
		
		Robot obj_r2 = new Robot(0,0,'N'); //建立物件 obj_r2
		obj_r2.printRobot(); //呼叫使用副函式
		
		Robot obj_r3 = new Robot(2,5,'W'); //建立物件 obj_r3
		obj_r3.printRobot(); //呼叫使用副函式
		
		obj_r3.setY(3);   //呼叫使用set
		obj_r3.printRobot();  //呼叫使用副函式
		System.out.println(obj_r3.direction);//呼叫使用get、副函式
		} //end of main method
} //end of class
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
