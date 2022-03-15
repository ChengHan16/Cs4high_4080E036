### Image 圖片大小

|名字	|介紹|  |
|--|--|--|
|0|	Normal|	影象被置於 System.Windows.Forms.PictureBox 的左上角。如果影象比包含它的 System.Windows.Forms.PictureBox 大，則該影象將被剪裁掉。|
|1|	StretchImage|	System.Windows.Forms.PictureBox 中的影象被拉伸或收縮，以適合 System.Windows.Forms.PictureBox的大小。|
|2|	AutoSize|	調整 System.Windows.Forms.PictureBox 大小，使其等於所包含的影象大小。|
|3|	CenterImage|	如果 System.Windows.Forms.PictureBox 比影象大，則影象將居中顯示。 <br> 如果影象比 System.Windows.Forms.PictureBox大，則圖片將居於 System.Windows.Forms.PictureBox 中心，而外邊緣將被剪裁掉。|
|4|	Zoom|	影象大小按其原有的大小比例被增加或減小。|

![image](https://user-images.githubusercontent.com/55220866/158300495-3864e258-f093-4a08-bab2-e06d43813f31.png)

```C#
public Form1()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resource2.Temp;   
        }
```
-----
### Chart
![image](https://user-images.githubusercontent.com/55220866/158300826-ff648b4d-6c09-4e76-9678-1a488d7c3090.png)
![image](https://user-images.githubusercontent.com/55220866/158301081-ca97b849-6055-4026-9bf2-04718ecdfa92.png)

## 參考資料
> https://www.itread01.com/content/1545288303.html
