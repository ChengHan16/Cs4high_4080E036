BMI_APP(1)
==========
Activity_main.xml
-----------------

![BMI(1)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/BMI(1).PNG)
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
            android:layout_height="90dp"
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
            android:layout_height="70dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView9"
                android:layout_width="180dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="姓名(user)"
                android:textColor="@color/black"
                android:textSize="24sp" />

            <EditText
                android:id="@+id/name"
                android:layout_width="wrap_content"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="Please enter name"
                android:inputType="textPersonName"
                android:textColor="@color/black"
                android:textSize="24sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="70dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView"
                android:layout_width="180dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="身高(height)"
                android:textColor="@color/black"
                android:textSize="24sp" />

            <EditText
                android:id="@+id/height"
                android:layout_width="wrap_content"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="Please enter height"
                android:inputType="textPersonName"
                android:textSize="24sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="70dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView2"
                android:layout_width="180dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="體重(weight)"
                android:textColor="@color/black"
                android:textSize="24sp" />

            <EditText
                android:id="@+id/weight"
                android:layout_width="wrap_content"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="Please enter weight"
                android:inputType="textPersonName"
                android:textSize="24sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="70dp"
            android:orientation="horizontal">

            <Button
                android:id="@+id/button"
                android:layout_width="wrap_content"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:onClick="BMI"
                android:text="確認(confirm)"
                android:textColor="@color/black"
                android:textSize="24sp"
                app:backgroundTint="@android:color/holo_blue_dark" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="70dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView3"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="使用者"
                android:textColor="@color/black"
                android:textSize="24sp" />

            <TextView
                android:id="@+id/display"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="________________"
                android:textColor="@color/black"
                android:textSize="24sp" />

        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="70dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView4"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="BMI"
                android:textColor="@color/black"
                android:textSize="24sp" />

            <TextView
                android:id="@+id/display1"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="________________"
                android:textColor="@color/black"
                android:textSize="24sp" />

        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="70dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView5"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="診斷"
                android:textColor="@color/black"
                android:textSize="24sp" />

            <TextView
                android:id="@+id/display2"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="________________"
                android:textColor="@color/black"
                android:textSize="24sp" />

        </LinearLayout>
    </LinearLayout>

</androidx.constraintlayout.widget.ConstraintLayout>
```

MainActivity.java
-----------------
```
package com.example.bmi_app_10_24;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import java.text.DecimalFormat;

public class MainActivity extends AppCompatActivity {

    DecimalFormat df = new DecimalFormat("##.00");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void BMI(View view){
        EditText name = findViewById(R.id.name);
        EditText height = findViewById(R.id.height);
        EditText weight = findViewById(R.id.weight);

        String name_s = name.getText().toString();
        String height_s = height.getText().toString();
        String weight_s = weight.getText().toString();

        Double height_d = Double.parseDouble(height_s);
        Double weight_d = Double.parseDouble(weight_s);
        Double bmi_result = weight_d/((height_d/100)*(height_d/100));

        TextView display = findViewById(R.id.display);
        TextView display1 = findViewById(R.id.display1);
        TextView display2 = findViewById(R.id.display2);

        display.setText(name_s);

        display1.setText(df.format(bmi_result));

        if (bmi_result<18.5)
            display2.setText("體重過輕");
        else if(18.5<=bmi_result && bmi_result<24)
            display2.setText("正常範圍");
        else if(24<=bmi_result && bmi_result<27)
            display2.setText("過重");
        else if(27<=bmi_result && bmi_result<30)
            display2.setText("輕度肥胖");
        else if(30<=bmi_result && bmi_result<35)
            display2.setText("中度肥胖");
        else if(bmi_result>=35)
            display2.setText("重度肥胖");
    }
}
```
