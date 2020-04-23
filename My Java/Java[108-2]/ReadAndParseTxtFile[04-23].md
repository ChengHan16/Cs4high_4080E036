# 考前複習(階段一)
```
package fileProcess;//套件名稱

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class ReadAndParseTxtFile {
   
    public void readTextFile(String filePath) throws IOException {
        FileReader fr 
        	= new FileReader(filePath);//讀取檔案來源路徑
        BufferedReader br
        	= new BufferedReader(fr); //建立BufferedReader的物件br
        
        String temp = null; //
        while( (temp=br.readLine()) != null) {//從檔案中，一次讀取一行，每一行就是一筆顧客資料
        System.out.println(temp);
    }
        //close reader
        if(br != null) {
        br.close();
    }
    }
    
    public static void readTextFile_static(String filePath) throws IOException {
        FileReader fr 
        	= new FileReader(filePath);//讀取檔案來源路徑
        BufferedReader br
          	= new BufferedReader(fr); //建立BufferedReader的物件br
        
        String temp = null; //
        while( (temp=br.readLine()) != null) {//從檔案中，一次讀取一行，每一行就是一筆顧客資料
        System.out.println(temp);
    }
        //close reader
        if(br != null) {
        br.close();
    }
    }
}
```
#
```
package fileProcessTest;

import java.io.IOException;

import fileProcess.ReadAndParseTxtFile;

public class FileTest {

	public static void main(String[] args) throws IOException {
		ReadAndParseTxtFile obj = new ReadAndParseTxtFile();
		//obj.readTextFile("./data/customer.text");
		
		ReadAndParseTxtFile.readTextFile_static("./data/customer.text");
	}
}
```
```
package fileProcessTest;

import java.io.IOException;

import fileProcess.ReadAndParseTxtFile;

public class FileTest {

    public static void main(String[] args) throws IOException {
        
        ReadAndParseTxtFile obj = new ReadAndParseTxtFile();
        obj.readTxtFile("./data/customer.txt");
        
        ReadAndParseTxtFile.readTxtFile_static("./data/customer.txt");

    }

}
```
