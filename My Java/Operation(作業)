# 利用Student做一個School的資料
```

public class School {
	private String OfficeName;//辦公室
	private String Numbering;//辦公室編號
	private String Extension;//分機號碼
	
	public School() {}
	
	public School(String O,String N,String E) {
		this.OfficeName=O;
		this.Numbering=N;
		this.Extension=E;
	}
	
	public void printfSchool(){
		System.out.println("辦公室名稱："+OfficeName+"辦公室編號："+Numbering+"分機號碼："+Extension);
	}
	
	public static void main(String[]args) {
		School obj_s1 = new School("校長室","001","-001");
		obj_s1.printfSchool();
		School obj_s2 = new School("學務處","002","-002");
		obj_s2.printfSchool();	
	}
}
```
```
輸出結果：辦公室名稱：校長室辦公室編號：001分機號碼：-001
         辦公室名稱：學務處辦公室編號：002分機號碼：-002
```
```

public class School1 {
	
	private String OfficeName;//辦公室
	private String Numbering;//辦公室編號
	private String Extension;//分機號碼
	
	public School1() {}
	
	public School1(String O,String N,String E) {
		this.OfficeName=O;
		this.Numbering=N;
		this.Extension=E;
	}
	
	public void printfSchool(){
		System.out.println("辦公室名稱："+OfficeName+"\t"+"辦公室編號："+Numbering+"\t"+"分機號碼：
		"+Extension+"\t");
	}
	
	public static void main(String[]args) {
		School obj_s1 = new School("校長室","001","-001");
		obj_s1.printfSchool();
		School obj_s2 = new School("學務處","002","-002");
		obj_s2.printfSchool();
		School obj_s3 = new School("總務處","003","-003");
		obj_s3.printfSchool();	
	}
}
```
```
輸出結果：辦公室名稱：校長室辦公室編號：001分機號碼：-001
         辦公室名稱：學務處辦公室編號：002分機號碼：-002
         辦公室名稱：總務處辦公室編號：003分機號碼：-003
```
# 使用gte
```

public class School3 {

	private String OfficeName;//辦公室
	private String Numbering;//辦公室編號
	private String Extension;//分機號碼
	
	public School3() {}
	
	public School3(String O,String N,String E) {
		this.OfficeName=O;
		this.Numbering=N;
		this.Extension=E;
	}
	
	public String getExtension() {	//void 無回傳
		return Extension;		//retuen回傳 兩者衝突，產生錯誤
	}
	
	public void printfSchool(){
		System.out.println("辦公室名稱："+OfficeName+"\t"+"辦公室編號："+Numbering+"\t"+"分機號碼：
		"+Extension+"\t");
	}
	
	public static void main(String[]args) {
		School3 obj_s1 = new School3("校長室","001","-001");
		obj_s1.printfSchool();
		System.out.println(obj_s1.getExtension());
		
		School3 obj_s2 = new School3("學務處","002","-002");
		obj_s2.printfSchool();
		
		School3 obj_s3 = new School3("總務處","003","-003");
		obj_s3.printfSchool();
	}
}
```
```
輸出結果：辦公室名稱：校長室   辦公室編號：001   分機號碼：-001	
         -001
         辦公室名稱：學務處   辦公室編號：002   分機號碼：-002	
         辦公室名稱：總務處   辦公室編號：003   分機號碼：-003	
```
