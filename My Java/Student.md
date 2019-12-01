# 
```
public class Student {
	String name; //儲存學生名字 
	String id; //儲存學生學號 
	String major; //表示學生所讀科系
  
	public Student (  ){} //學生類別預設建構子 
	
	public Student (String n, String i, String m){ 
	this. name = n;  
	this. id = i;                 //(類別變數)
	this. major = m; 
	} //學生類別自定義建構子 
	
	public void setName(String n){ 
	this. name = n; 
	} 

	public String getName( ){ 
	return name; 
	} 

	public void printString( ){ 
		System.out.printf("學生: %s  學號:%s 班級: %s",name,id,major); 
	} 

	public static void main(String [] args){ //(主函式)
		Student obj_s1 = new Student("曾厲害","4080E001","資訊工程系");//呼叫類別建構子，建立物件
		 
		obj_s1.printString();//呼叫副函式printString( )
	}
}//學生類別結束
```
