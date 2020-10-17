Axtivity_main.xml
=============
```
<?xml version="1.0" encoding="utf-8"?>
<androidx.constraintlayout.widget.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context=".MainActivity">

    <LinearLayout
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:orientation="vertical"
        app:layout_constraintBottom_toBottomOf="parent"
        app:layout_constraintEnd_toEndOf="parent"
        app:layout_constraintStart_toStartOf="parent"
        app:layout_constraintTop_toTopOf="parent">

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="150dp"
            android:orientation="horizontal">

            <ImageView
                android:id="@+id/imageView"
                android:layout_width="wrap_content"
                android:layout_height="wrap_content"
                android:layout_weight="1"
                app:srcCompat="@drawable/bmi" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="身高(Height)："
                android:textColor="@color/black"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/height"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="Enter height in cm"
                android:inputType="number" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView2"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="體重(Weight)："
                android:textColor="@color/black"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/weight"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="Enter weight in kg"
                android:inputType="number" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:orientation="horizontal">

            <Button
                android:id="@+id/button"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:onClick="BMI"
                android:text="轉換(Conversion)"
                android:textColor="@color/black"
                android:textSize="24sp"
                app:backgroundTint="@android:color/tertiary_text_light"
                app:iconTint="@color/material_on_background_emphasis_medium" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/display"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="BMI = __________"
                android:textColor="@android:color/tertiary_text_dark"
                android:textSize="30sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView5"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="判斷(Judgment:)："
                android:textColor="@color/black"
                android:textSize="18sp" />

            <TextView
                android:id="@+id/tv4"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="Critical result"
                android:textSize="24sp" />

        </LinearLayout>
    </LinearLayout>
</androidx.constraintlayout.widget.ConstraintLayout>
```
MainActivity.java
=================
```
package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import java.text.DecimalFormat;
import java.text.NumberFormat;

public class MainActivity extends AppCompatActivity {
    DecimalFormat df = new DecimalFormat("##.00");
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void BMI(View view){
        EditText height = findViewById(R.id.height);
        EditText weight = findViewById(R.id.weight);

        String height_s = height.getText().toString();
        String weight_s = weight.getText().toString();

        double height_d = Double.parseDouble(height_s);
        double weight_d = Double.parseDouble(weight_s);

        double bmi_result = weight_d/((height_d/100)*(height_d/100));

        TextView display = findViewById(R.id.display);
        display.setText("BMI = " + df.format(bmi_result));


        float fh = Float.parseFloat(height.getEditableText().toString());      // 取得 身高輸入值
        float fw = Float.parseFloat(weight.getEditableText().toString());     // 取得 體重輸入值
        float fresult;                                     // BMI值 計算結果
        TextView result = (TextView)findViewById(R.id.display);// 取得 顯示結果 物件
        fh = fh/100; // 計算BMI
        fh = fh*fh;  // 計算BMI

        NumberFormat nf = NumberFormat.getInstance();   // 數字格式
        nf.setMaximumFractionDigits(2);                 // 限制小數第二位
        fresult = fw/fh;                                // 計算BMI
        result.setText(nf.format(fw/fh) +"");           // 顯示BMI計算結果
        TextView dia = (TextView)findViewById(R.id.tv4);// 取得 顯示診斷 物件

        // 診斷結果 顯示
        if (fresult<18.5)
            dia.setText("體重過輕");
        else if (18.5 <= fresult && fresult< 24)
            dia.setText("正常範圍");
        else if (24 <=fresult && fresult < 27)
            dia.setText("過    重");
        else if (27 <=fresult && fresult < 30)
            dia.setText("輕度肥胖");
        else if (30 <= fresult && fresult < 35)
            dia.setText("中度肥胖");
        else if (fresult >= 35)
            dia.setText("重度肥胖        ");
    }

}
```
![Alt text](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/BMI%E9%80%B2%E9%9A%8E.PNG)
