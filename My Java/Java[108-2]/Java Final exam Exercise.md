# [中階]
```
package myHtml;

public class MyHtmlProcess {
	private String url;

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}
}

--------------------------------------------------------------------

package myHtml;

public class MyHtmlProcessTest {

	public static void main(String[] args) {
		MyHtmlProcess obj = new MyHtmlProcess();
		
		String url = "https://elearning2.ksu.edu.tw/learn/index.php";
		obj.setUrl(url);
		/*obj.setUrl("https://elearning2.ksu.edu.tw/learn/index.php");*/
		
		String url1 = obj.getUrl();
		System.out.println(url1);
		
		System.out.println(obj.getUrl());
	}

}

```
# 顯示結果：
```
https://elearning2.ksu.edu.tw/learn/index.php
https://elearning2.ksu.edu.tw/learn/index.php
```
