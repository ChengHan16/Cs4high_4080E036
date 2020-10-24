BMI_APP_(1)
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
BMI_APP_(2)
==========
Activity_main.xml
----------------
![BMI(1)](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/BMI(2).PNG)
![換えてページ.PNG](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E6%8F%9B%E3%81%88%E3%81%A6%E3%83%9A%E3%83%BC%E3%82%B8.PNG)
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
            android:layout_height="60dp"
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
                android:id="@+id/inputname"
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
            android:layout_height="60dp"
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
            android:layout_height="60dp"
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
            android:layout_height="60dp"
            android:orientation="horizontal">

            <Button
                android:id="@+id/button"
                android:layout_width="wrap_content"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:onClick="BMI1"
                android:text="確認(confirm)"
                android:textColor="@color/design_default_color_on_primary"
                android:textSize="24sp"
                app:backgroundTint="@android:color/holo_blue_dark" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="60dp"
            android:orientation="horizontal">

            <Button
                android:id="@+id/button3"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:onClick="BMI1"
                android:text="次のページ結果見る"
                android:textColor="@color/white"
                android:textSize="24sp"
                app:backgroundTint="@android:color/holo_blue_dark" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="60dp"
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
            android:layout_height="60dp"
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
            android:layout_height="60dp"
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
Activity_main2.xml
----------------
```
<?xml version="1.0" encoding="utf-8"?>
<androidx.constraintlayout.widget.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context=".MainActivity2">

    <LinearLayout
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:orientation="vertical"
        app:layout_constraintBottom_toBottomOf="parent"
        app:layout_constraintEnd_toEndOf="parent"
        app:layout_constraintStart_toStartOf="parent"
        app:layout_constraintTop_toTopOf="parent">

        <TextView
            android:id="@+id/display3"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:gravity="center"
            android:text="Name"
            android:textColor="@color/black"
            android:textSize="24sp" />

        <TextView
            android:id="@+id/display4"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:gravity="center"
            android:text="BMI "
            android:textColor="@color/black"
            android:textSize="24sp" />

        <TextView
            android:id="@+id/display5"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:gravity="center"
            android:text="診斷"
            android:textColor="@color/black"
            android:textSize="24sp" />

        <Button
            android:id="@+id/button2"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:text="戻る"
            android:textColor="@color/cardview_light_background"
            android:textSize="24sp"
            app:backgroundTint="@android:color/holo_blue_dark" />
    </LinearLayout>
</androidx.constraintlayout.widget.ConstraintLayout>
```
MainActivity.java
----------------
```
package com.example.bmi_app_10_24;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.text.DecimalFormat;

public class MainActivity extends AppCompatActivity {

    DecimalFormat df = new DecimalFormat("##.00");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        setTitle("BMI Page 1");

        Button btn_to_page2 = (Button) findViewById(R.id.button3);

        btn_to_page2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setClass(MainActivity.this, MainActivity2.class);

                // crating a bundle object
                Bundle bundle = new Bundle();

                EditText name = findViewById(R.id.inputname);
                String name_s1 = name.getText().toString();

                EditText height = findViewById(R.id.height);
                EditText weight = findViewById(R.id.weight);
                String height_s = height.getText().toString();
                String weight_s = weight.getText().toString();
                Double height_d = Double.parseDouble(height_s);
                Double weight_d = Double.parseDouble(weight_s);
                Double bmi_result = weight_d/((height_d/100)*(height_d/100));

                TextView displaygo = findViewById(R.id.display2);
                String result = displaygo.getText().toString();
                    if (bmi_result<18.5)
                        displaygo.setText("體重過輕");
                    else if(18.5<=bmi_result && bmi_result<24)
                        displaygo.setText("正常範圍");
                    else if(24<=bmi_result && bmi_result<27)
                        displaygo.setText("過重");
                    else if(27<=bmi_result && bmi_result<30)
                        displaygo.setText("輕度肥胖");
                    else if(30<=bmi_result && bmi_result<35)
                        displaygo.setText("中度肥胖");
                    else if(bmi_result>=35)
                        displaygo.setText("重度肥胖");

                // storing the string value in the bundle which is mapped to key
                bundle.putString("key1", "使用者："+ name_s1);
                bundle.putString("key2", "BMI："+ df.format(bmi_result));
                bundle.putString("key3", "診斷："+ result);
                // passing the bundle into the intent
                intent.putExtras(bundle);

                startActivity(intent);
            }
        });
    }//end of conCreate

    public void BMI1(View view){
        EditText name = findViewById(R.id.inputname);
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
MainActivity2.java
----------------
```
package com.example.bmi_app_10_24;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity2 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

        setTitle("BMI Page 2");

        // getting the bundle back from the android
        Bundle bundle = getIntent().getExtras();

        // getting the string back
        String BMI = bundle.getString("key1", "Default");
        String BMI1 = bundle.getString("key2", "Default");
        String BMI2 = bundle.getString("key3", "Default");

        TextView display3 = findViewById(R.id.display3);
        display3.setText(BMI);

        TextView display4 = findViewById(R.id.display4);
        display4.setText(BMI1);

        TextView display5 = findViewById(R.id.display5);
        display5.setText(BMI2);

        Button btn_to_page1 = (Button) findViewById(R.id.button2);

        btn_to_page1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setClass(MainActivity2.this, MainActivity.class);
                startActivity(intent);
            }
        });
    }
}
```
# ページ換える
Activity_main.xml
==================
![ページ換える.PNG](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E3%83%9A%E3%83%BC%E3%82%B8%E6%8F%9B%E3%81%88%E3%82%8B.PNG)
![ページ換える1](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E3%83%9A%E3%83%BC%E3%82%B8%E6%8F%9B%E3%81%88%E3%82%8B(1).PNG)
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

        <TextView
            android:id="@+id/textView"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:gravity="center"
            android:text="使用者"
            android:textColor="@color/black"
            android:textSize="30sp" />

        <EditText
            android:id="@+id/inputName"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:ems="10"
            android:hint="Please Enter Name"
            android:inputType="textPersonName"
            android:textSize="30sp" />

        <Button
            android:id="@+id/button"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:text="確認"
            android:textColor="@color/black"
            android:textSize="30sp"
            app:backgroundTint="@android:color/darker_gray" />

    </LinearLayout>
</androidx.constraintlayout.widget.ConstraintLayout>
```
Activity_main2.xml
==================
```
<?xml version="1.0" encoding="utf-8"?>
<androidx.constraintlayout.widget.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context=".MainActivity2">

    <LinearLayout
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:orientation="vertical"
        app:layout_constraintBottom_toBottomOf="parent"
        app:layout_constraintEnd_toEndOf="parent"
        app:layout_constraintStart_toStartOf="parent"
        app:layout_constraintTop_toTopOf="parent">

        <TextView
            android:id="@+id/display2"
            android:layout_width="match_parent"
            android:layout_height="90dp"
            android:gravity="center"
            android:hint="__________________"
            android:textColor="@color/black"
            android:textSize="30sp" />

        <Button
            android:id="@+id/button2"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:text="戻る"
            android:textColor="@color/black"
            android:textSize="30sp"
            app:backgroundTint="@android:color/darker_gray" />
    </LinearLayout>
</androidx.constraintlayout.widget.ConstraintLayout>
```
MainActivity.java
==================
```
package com.example.page_change;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        setTitle("Page 1");

        Button btn_to_page2 = (Button) findViewById(R.id.button);

        btn_to_page2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setClass(MainActivity.this, MainActivity2.class);

                // crating a bundle object
                Bundle bundle = new Bundle();

                EditText name = findViewById(R.id.inputName);
                String name_s = name.getText().toString();

                // storing the string value in the bundle which is mapped to key
                bundle.putString("key1", name_s);

                // passing the bundle into the intent
                intent.putExtras(bundle);

                startActivity(intent);
            }
        });
    }//end of conCreate
}
```
MainActivity2.java
==================
```
package com.example.page_change;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity2 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

        setTitle("Page 2");

            // getting the bundle back from the android
            Bundle bundle = getIntent().getExtras();

            // getting the string back
            String TextView = bundle.getString("key1", "Default");

            TextView display = findViewById(R.id.display2);
            display.setText(TextView);


            Button btn_to_page1 = (Button) findViewById(R.id.button2);

            btn_to_page1.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent intent = new Intent();
                    intent.setClass(MainActivity2.this, MainActivity.class);
                    startActivity(intent);
                }
            });
        }
    }
```

