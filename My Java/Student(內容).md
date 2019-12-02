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
	
	public String getid() {	//void 無回傳
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
		Student obj_s1 = new Student("吳承翰","4080E036","資訊工程");
		obj_s1.pirntStudentinfo();	
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
		obj_s1.pirntStudentinfo();
		Student obj_s2 = new Student("李正德","4080I017","資訊工程");
		obj_s2.pirntStudentinfo();
```
```
執行結果： 學生姓名:吳承翰	 學號:4080E036	 科系:資訊工程

	  學生姓名:李正德   學號:4080I017     科系:資訊工程	
```
