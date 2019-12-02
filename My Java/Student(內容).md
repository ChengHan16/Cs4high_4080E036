# 12/2
```

public class Student {
	private String name;  //姓名
	private String id;    //學號
	private String major; //科系
	
	public Student() {}   //預設建構子
	
	public Student (String n,String i,String m) { //自定義建構子
		this.name=n;
		this.id=i;
		this.major=m;
	}
	
	public void Setname(String n) {
		this.name=n;
	}
	
	public void Setid(String i) {
		this.id=i;
	}
	
	public void Setmajor(String m) {
		this.major=m;
	}
	
	public String getName() {	//void 無回傳
		return name;		//retuen回傳 兩者衝突，產生錯誤
	}
	
	public String getid() {		//void 無回傳
		return id;		//retuen回傳 兩者衝突，產生錯誤
	}
	
	public String getmajor() {	//void 無回傳
		return major;		//retuen回傳 兩者衝突，產生錯誤
	}
	
	public  void pirntStudentinfo() {
		System.out.println("學生:"+name+"\n"+"學號:"+id+"\n"+"科系:"+major+"\n");//println自動換行
	}	
	
	public static void main(String[]args) {
		Student obj_s1 = new Student("吳承翰","4080E036","資訊工程");
		obj_s1.pirntStudentinfo();	
	}	
}
```
```

public class Student {
	private String name;  //姓名
	private String id;    //學號
	private String major; //科系
	
	public Student() {}   //預設建構子
	
	public Student (String n,String i,String m) { //自定義建構子
		this.name=n;
		this.id=i;
		this.major=m;
	}

	public  void pirntStudentinfo() {
		System.out.println("學生:"+name+"\n"+"學號:"+id+"\n"+"科系:"+major+"\n");//println自動換行
	}	
	
	public static void main(String[]args) {
		Student obj_s1 = new Student("吳承翰","4080E036","資訊工程");//新增一個名稱obj_s1的Student資料
		obj_s1.pirntStudentinfo();//呼叫副函式	
	}	
}
```
```
執行結果:學生:吳承翰
	學號:4080E036
	科系:資訊工程
```
# \t
```
	public  void pirntStudentinfo() {
		System.out.println("學生姓名:"+name+"\t"+"學號:"+id+"\t"+"科系:"+major+"\t");//println自動換行
	}	
	
	public static void main(String[]args) {
		Student obj_s1 = new Student("吳承翰","4080E036","資訊工程");	
		//新增一個名稱obj_s1的Student資料
		obj_s1.pirntStudentinfo();				      
		//呼叫副函式
		Student obj_s2 = new Student("李正德","4080I017","資訊工程");	
		//新增一個名稱obj_s1的Student資料
		obj_s2.pirntStudentinfo();				      
		//呼叫副函式
	}
```
```
執行結果： 學生姓名:吳承翰   學號:4080E036    科系:資訊工程
	  學生姓名:李正德   學號:4080I017    科系:資訊工程	
```
# getname 回傳用意
```
	System.out.println(obj_s1.getName());//快速尋找的函式
```
# get、set的應用
```

public class Student {
	private String name;  //姓名
	private String id;    //學號
	private String major; //科系
	
	public Student() {}   //預設建構子
	
	public Student (String n,String i,String m) { //自定義建構子
		this.name=n;
		this.id=i;
		this.major=m;
	}
	
	public void Setname(String n) {//更改名稱
		this.name=n;
	}
	
	public void Setid(String i) {
		this.id=i;
	}
	
	public void Setmajor(String m) {
		this.major=m;
	}
	
	public String getName() {	//void 無回傳，取得姓名
		return name;		//retuen回傳 兩者衝突，產生錯誤
	}
	
	public String getid() {	//void 無回傳
		return id;		//retuen回傳 兩者衝突，產生錯誤
	}
	
	public String getmajor() {	//void 無回傳
		return major;		//retuen回傳 兩者衝突，產生錯誤
	}
	
	public  void pirntStudentinfo() {
		System.out.println("學生姓名:"+name+"\t"+"學號:"+id+"\t"+"科系:"+major+"\t");//println自動換行
	}	
	
	public static void main(String[]args) {
		Student obj_s1 = new Student("吳承翰","4080E036","資訊工程");//新增一個名稱obj_s1的Student資料
		obj_s1.pirntStudentinfo();//呼叫副函式
		System.out.println(obj_s1.getName());//快速尋找的函式
		
		Student obj_s2 = new Student("李正德","4080I000","資訊工程");
		obj_s2.Setid("4080I017");//用obj_s2去set id 變更為4080I017
		obj_s2.pirntStudentinfo();//呼叫副函式
		
	}	
}

(以最後修改的結果來確認)
```
```
執行結果:學生姓名: 吳承翰           學號:4080E036   科系:資訊工程	
                  吳承翰
                  學生姓名:李正德   學號:4080I017   科系:資訊工程	

```
