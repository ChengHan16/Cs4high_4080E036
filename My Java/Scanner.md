# Scanner
```
import java.util.Scanner;

public class Scanner_test {
    public static void main(String[] args) {
        int num1, num2, num3;
        Scanner scanner = new Scanner(System.in);
        
        System.out.println("請輸入三個數字(以空白鍵分開)：");
        num1 = scanner.nextInt();
        num2 = scanner.nextInt();
        num3 = scanner.nextInt();
        System.out.println("您輸入第一個數字為：" + num1 );
        System.out.println("您輸入第二個數字為：" + num2 );
        System.out.println("您輸入第三個數字為：" + num3 );

    }
}
```
```
參考網頁：https://dotblogs.com.tw/freedom42408/archive/2013/11/20/130586.aspx
```
