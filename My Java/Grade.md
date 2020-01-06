# 期末考
```

public class Grade {
	
	private static int Programming ;//程式設計成績
	private static int Mandarin    ;//國文成績
	private static int English     ;//英文成績
	private static int Studentgrade;//學生年級
	
	public Grade() {}
	
	public Grade (int P,int M,int E,int S) {
		this.Programming = P;
		this.Mandarin = M;
		this.English = E;
		this.Studentgrade = S;
	}

	public int getP() {
		return Programming;
	}

	public int getM() {
    	return Mandarin;
	}
	public int getE() {
		return English;
	}
	public int getS() {
		return Studentgrade;
	}
	
	
	public void setP(int P) {
		this.Programming=P;
	}
	
	public void setM(int M) {
		this.Mandarin=M;
	}
	
	public void setE(int E) {
		this.English=E;
	}
	
	public void setStudent(int S) {
		this.Studentgrade=S;
	}
	
	public void printAll() {
		System.out.println("程式設計成績："+ Programming +"\n"+"國文成績："+ Mandarin +"\n"+"英文成績："+ English +"\n"+"學生年級："+ Studentgrade+"\n");
	}
	
	public static void showGradeLevel() {
	    int i = Programming;
		while (true) {
			if ( i >= 90 )  {
				System.out.println (i+"等級A");
				break;
			}
			else if (i >= 80 && i <89) {
				System.out.println (i+"等級B");
				break;
			}			
			else if (i > 70 && i <79)  {
				System.out.println (i+"等級C");
				break;
			}
			else if (i > 60 && i<69) {
				System.out.println (i+"等級D");
				break;
			}
			else {
				System.out.println (i+"等級F");
				break;
			}				
		}		
	}
	public static void showGradeLevel1() {
	    int J = Mandarin;
		while (true) {
			if ( J >= 90 )  {
				System.out.println (J+"等級A");
				break;
			}
			else if (J >= 80 && J <89) {
				System.out.println (J+"等級B");
				break;
			}			
			else if (J > 70 && J <79)  {
				System.out.println (J+"等級C");
				break;
			}
			else if (J > 60 && J<69) {
				System.out.println (J+"等級D");
				break;
			}
			else {
				System.out.println (J+"等級F");
				break;
			}				
		}		
	}
	public static void main (String[]args) {
		Grade obj_g1=new Grade(100,99,98,1);
		obj_g1.printAll();
		
		Grade obj_g2=new Grade(80,70,60,1);
		obj_g2.printAll();
		System.out.println("使用get回傳"+obj_g2.getP());

	
		Grade obj_g3=new Grade(60,50,40,1);
		obj_g3.printAll();	
		obj_g3.setStudent(2);
		System.out.println();
		
		Grade obj_g4=new Grade(50,40,30,3);
		obj_g4.printAll();	

				
		Grade obj_g5=new Grade(60,50,40,1);
		obj_g5.printAll();

		
		Grade obj_g6=new Grade(50,30,10,4);
		obj_g6.printAll();	
		
		Grade obj_g7=new Grade(20,40,40,4);
		obj_g7.printAll();	
		
		Grade obj_g8=new Grade(88,77,66,1);
		obj_g8.printAll();	
		
		Grade obj_g9=new Grade(66,55,40,3);
		obj_g9.printAll();	
		obj_g9.setP(77);
		obj_g9.setM(66);
		obj_g9.setE(50);
		obj_g9.setStudent(4);
		obj_g9.printAll();
		
		Grade obj_g10=new Grade(100,100,100,4);
		obj_g10.printAll();
		System.out.println("程式："+obj_g10.getP());
		System.out.println("國文："+obj_g10.getM());
		System.out.println("英文："+obj_g10.getE());
		System.out.println("年級："+obj_g10.getS());
		
		obj_g1.showGradeLevel();
		obj_g1.showGradeLevel1();
	}
}
```
# forloop
```
import java.util.Scanner;

public class forloop {

    private Scanner in = new Scanner (System.in);
    private int[] grade_Array = new int[101];
    
    public static void main(String[] args) {
    	forloop obj = new forloop();
        obj.insertNumbers();
    }
    
    public void insertNumbers() {
        for(int i = 0; i < 100; i++) {
            System.out.print("Enter a number:");
            grade_Array[i] = in.nextInt();
        }
        
        for(int j = 0; j < 100; j++) {
            System.out.println("grade_Array["+(j)+"] = " + grade_Array[j]);
        }
    }

}



