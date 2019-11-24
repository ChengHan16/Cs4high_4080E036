# (建構子練習)
```
public class Car {
	String brand;//表示汽車品牌 ,String為Java字串型態
	int year;//表示汽車年份,int為Java整數型態
	String color;//表示汽車顏色,String為Java字串型態
	
	public Car( ) {}//預設建構子，沒有參數，()是空的 
	
	public Car(String brand,int year,String color) {
		this.brand = brand ; //將建構子參數 brand 的 值 傳給全域變數 brand
		this.year = year; // this.的意思是指這個類別的
		this.color= color;
		System.out.printf("%s,%d,%s\n",brand,year,color);
	}//自定義建構子
}

```
```
public class Tainan {

	public static void main(String[] args) {
		Car obj_car = new Car ();
		//new是 建立新類別 的關鍵字
		Car obj_car1 = new Car ("Toyota",2019,"white");
		
		//建立一個 Car 類別 的 物件 obj_car1 使用自定義建 構子
		Car obj_car2 = new Car("Honda", 2015,"red");
		
		//建立一個 Car 類別 的 物件 obj_car2 使用自定義建構子
	}//主函式結束
}//類別結束
```
```
輸出結果：
Toyota,2019,white
Honda,2015,red
```
