```
```
package fileprocess2;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class fileProcess2 {
	
	private ArrayList<String> customer_List 
							= new ArrayList<String>();	
	private ArrayList<String> customer_ID_List 
							= new ArrayList<String>();	
	private ArrayList<String> customer_Name_List 
							= new ArrayList<String>();
	private ArrayList<String> customer_Address_List 
							= new ArrayList<String>();
	private ArrayList<String> customer_Phone_List 
							= new ArrayList<String>();
	private ArrayList<String> customer_Email_List 
							= new ArrayList<String>();
	
	public void readTxtFile2(String Path) throws IOException {
		FileReader fr 
					= new FileReader(Path);
		
		BufferedReader br 
					= new BufferedReader(fr);
		
		String temp = null;
		String[ ] token ;
		while ((temp=br.readLine())!=null) {
			customer_List.add(temp);
			token=temp.split("\t");
			
			customer_ID_List.add(token[0]);
			customer_Name_List.add(token[1]);
			customer_Address_List.add(token[2]);
			customer_Phone_List.add(token[3]);
			customer_Email_List.add(token[4]);
		}
			
		for(int i = 0 ; i<customer_ID_List.size() ; i++) {
			System.out.println(customer_ID_List.get(i));
		}
		System.out.println("------------------------");
		
		for(int i = 0 ; i<customer_Phone_List.size() ; i++) {
			System.out.println(customer_Phone_List.get(i));
		}
		System.out.println("------------------------");
		
		for(int i = 0 ; i<customer_Email_List.size() ; i++) {
			System.out.println(customer_Email_List.get(i));
		}
		System.out.println("------------------------");
	}
}
```
```
package fileProcessTest2;

import java.io.IOException;

import fileprocess2.fileProcess2;

public class fileprocessTest {

	public static void main(String[] args) throws IOException {
		fileProcess2 obj =new fileProcess2();
		obj.readTxtFile2("./data/customer.txt");

	}

}

```
