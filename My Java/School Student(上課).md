# 12-09
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




