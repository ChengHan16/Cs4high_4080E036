# 12/9
```
public class School1 {
	private String name;         //校名
	private int numberOfStudent; //學生人數
	private String principal;    //校長
	private String location_city;//所在城市
	
	public School1() {}   //預設建構子
	
	public School1 (String n,int numberStudent,String p,String loc) { //自定義建構子
		this.name=n;
		this.numberOfStudent=numberStudent;
		this.principal=p;
		this.location_city = loc;
	}
	
	public  void pirntdSchoolfo() {
		System.out.println("學校校名："+name+"\t"+"學生人數："+numberOfStudent+"\t"+"
		校長："+principal+"\t"+"學校所在地城市："+location_city+"\t");
		//println自動換行
	}	
	
	public static void main(String[]args) {
		School1 obj_s1 = new School1("崑山科技大學",6666,"李天祥","台南市");
		//新增一個名稱obj_s1的Student資料
		obj_s1.pirntdSchoolfo();//呼叫副函式
		
		School1 obj_s2 = new School1("台灣科技大學",5555,"王錫福","台北市");
		obj_s2.pirntdSchoolfo();//呼叫副函式
		
	}	
}
```
```
輸出結果：學校校名：崑山科技大學   學生人數：6666   校長：李天祥   學校所在地城市：台南市	
         學校校名：台灣科技大學   學生人數：5555   校長：王錫福   學校所在地城市：台北市
```
# obj_s1 / KSU (自定義)
```

public class School1 {
	private String name;         //校名
	private int numberOfStudent; //學生人數
	private String principal;    //校長
	private String location_city;//所在城市
	
	public School1() {}   //預設建構子
	
	public School1 (String n,int numberStudent,String p,String loc) { //自定義建構子
		this.name=n;
		this.numberOfStudent=numberStudent;
		this.principal=p;
		this.location_city = loc;
	}
	
	public  void pirntdSchoolfo() {
		System.out.println("學校校名："+name+"\t"+"學生人數："+numberOfStudent+"\t"+"
		校長："+principal+"\t"+"學校所在地城市："+location_city+"\t");
		//println自動換行
	}	
	
	public static void main(String[]args) {
		School1 ksu = new School1("崑山科技大學",6666,"李天祥","台南市");
		//新增一個名稱obj_s1的Student資料
		ksu.pirntdSchoolfo();//呼叫副函式
		
		School1 NTUST = new School1("台灣科技大學",5555,"王錫福","台北市");
		NTUST.pirntdSchoolfo();//呼叫副函式
		
	}	
}
```
# KSU
```

public class KSU {
	
	private static School1 info;//學校基本資訊
	
	//private static int numberOfStudents;//學生人數(類別限定static,大家看到都是同一個)類別變數
	
	//private static School[]student_basic_info_array;//[]陣列
	//需要甚麼類別就建立甚麼類別，Student類別剛剛已建立

	public KSU() {}
	
	public KSU(School1 sch) {
		this.info = sch;
	}
	
	public void printlnfo() {
		info.pirntdSchoolnfo();
	}
	
	
	public static void main(String[]args) {
		School1 obj_ksu = new School1("崑山科技大學",6666,"李天祥","台南市");
		obj_ksu.pirntdSchoolnfo();
		

	}
	
	
}
```
```
輸出結果：學校校名：崑山科技大學   學生人數：6666   校長：李天祥   學校所在地城市：台南市
```





















