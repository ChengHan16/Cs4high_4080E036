APP_Programming_Midterm_exam
============================
(------------------1------------------)
=======================================
Activity_main.xml
------------------
```
<?xml version="1.0" encoding="utf-8"?>
<android.support.constraint.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context="com.example.ksuie.mybmi_final.MainActivity">

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
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="109.1 APP期中考"
                android:textColor="@android:color/holo_blue_dark"
                android:textSize="24sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView2"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="班級："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input1"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入班級"
                android:inputType="textPersonName" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView3"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="學號："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input2"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入學號"
                android:inputType="textPersonName" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView5"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="姓名："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input3"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入姓名"
                android:inputType="textPersonName" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView6"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="E-mail："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input4"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入E-mail(メール)"
                android:inputType="textEmailAddress" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView7"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="手機："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input5"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入手機"
                android:inputType="phone" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="100dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView8"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="課程學習心得："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input6"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入學習心得"
                android:inputType="textPersonName" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <Button
                android:id="@+id/button"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:backgroundTint="@android:color/holo_blue_dark"
                android:text="確認"
                android:textColor="@android:color/background_light"
                android:textSize="18sp" />
        </LinearLayout>

    </LinearLayout>
</android.support.constraint.ConstraintLayout>

```

Activity_main2.xml
------------------
```
<?xml version="1.0" encoding="utf-8"?>
<android.support.constraint.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context="com.example.ksuie.mybmi_final.Main2Activity">

    <LinearLayout
        android:layout_width="368dp"
        android:layout_height="495dp"
        android:orientation="vertical"
        app:layout_constraintBottom_toBottomOf="parent"
        app:layout_constraintEnd_toEndOf="parent"
        app:layout_constraintStart_toStartOf="parent"
        app:layout_constraintTop_toTopOf="parent">

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="40dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView4"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="學生基本資料"
                android:textColor="@android:color/holo_blue_dark"
                android:textSize="24sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="170dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/display1"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="10dp"
            android:orientation="horizontal"></LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="40dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView13"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="課程學習心得"
                android:textColor="@android:color/holo_blue_dark"
                android:textSize="24sp" />

        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="170dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/display2"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="top|center"
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <Button
                android:id="@+id/button2"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:backgroundTint="@android:color/holo_blue_dark"
                android:text="返回上一頁"
                android:textColor="@android:color/background_light"
                android:textSize="18sp" />
        </LinearLayout>
    </LinearLayout>
</android.support.constraint.ConstraintLayout>

```

MainActivity.java
------------------
```
package com.example.ksuie.mybmi_final;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("Midterm exam_Page1");
        final Bundle bundle = new Bundle();

        Button btn_to_page2 = findViewById(R.id.button);
        btn_to_page2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                intent.setClass(MainActivity.this, Main2Activity.class);
                bundle.putString("key1", Stdimformation());
                bundle.putString("key2", Experience());
                intent.putExtras(bundle);
                startActivity(intent);
            }
        });
    }

    public String Stdimformation() {
        EditText classid = findViewById(R.id.input1);
        String classid_s = classid.getText().toString();
        EditText ID = findViewById(R.id.input2);
        String ID_s = ID.getText().toString();
        EditText name = findViewById(R.id.input3);
        String name_s = name.getText().toString();
        EditText email = findViewById(R.id.input4);
        String email_s = email.getText().toString();
        EditText phone = findViewById(R.id.input5);
        String phone_s = phone.getText().toString();


        return "班級：" + classid_s + "\n" + "學號：" +  ID_s + "\n" + "姓名：" + name_s +"\n" + "E-mail：" + email_s +"\n" + "手機：" +  phone_s ;
    }

    public  String Experience(){
        EditText Experience = findViewById(R.id.input6);
        String Experience_s = Experience.getText().toString();
        return Experience_s;
    }
}

```
MainActivity2.java
------------------
```
package com.example.ksuie.mybmi_final;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class Main2Activity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);
        setTitle("Midterm exam_Page2");

        Bundle bundle = getIntent().getExtras();

        String Stdimformation = bundle.getString("key1","Default");
        String Experience = bundle.getString("key2","Default");

        TextView display1 = findViewById(R.id.display1);
        TextView display2 = findViewById(R.id.display2);

        display1.setText(Stdimformation);
        display2.setText(Experience);

        Button btn_to_page1 = findViewById(R.id.button2);
        btn_to_page1.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                intent.setClass(Main2Activity.this,MainActivity.class);
                finish();
            }
        });
    }
}

```
(------------------2------------------)
=======================================
Activity_main.xml
------------------
```
<?xml version="1.0" encoding="utf-8"?>
<android.support.constraint.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context="com.example.ksuie.mybmi_final.MainActivity">

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
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="109.1 APP期中考"
                android:textColor="@android:color/holo_blue_dark"
                android:textSize="24sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView2"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="班級："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input1"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入班級"
                android:inputType="textPersonName" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView3"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="學號："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input2"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入學號"
                android:inputType="textPersonName" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView5"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="姓名："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input3"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入姓名"
                android:inputType="textPersonName" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView6"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="E-mail："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input4"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入E-mail(メール)"
                android:inputType="textEmailAddress" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView7"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="手機："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input5"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入手機"
                android:inputType="phone" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="100dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView8"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="課程學習心得："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <EditText
                android:id="@+id/input6"
                android:layout_width="500dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:ems="10"
                android:hint="請輸入學習心得"
                android:inputType="textPersonName" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <Button
                android:id="@+id/button"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:backgroundTint="@android:color/holo_blue_dark"
                android:text="確認"
                android:textColor="@android:color/background_light"
                android:textSize="18sp" />
        </LinearLayout>

    </LinearLayout>
</android.support.constraint.ConstraintLayout>

```
Activity_main2.xml
------------------
```
<?xml version="1.0" encoding="utf-8"?>
<android.support.constraint.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context="com.example.ksuie.mybmi_final.Main2Activity">

    <LinearLayout
        android:layout_width="368dp"
        android:layout_height="495dp"
        android:orientation="vertical"
        app:layout_constraintBottom_toBottomOf="parent"
        app:layout_constraintEnd_toEndOf="parent"
        app:layout_constraintStart_toStartOf="parent"
        app:layout_constraintTop_toTopOf="parent">

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView14"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="109.1 APP期中考"
                android:textColor="@android:color/holo_blue_dark"
                android:textSize="24sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">


            <TextView
                android:id="@+id/textView4"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="班級："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <TextView
                android:id="@+id/display1"
                android:layout_width="450dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="_____________"
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView9"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="學號："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <TextView
                android:id="@+id/display2"
                android:layout_width="450dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="_____________"
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView10"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="姓名："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <TextView
                android:id="@+id/display3"
                android:layout_width="450dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="_____________"
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView11"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="E-mail："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <TextView
                android:id="@+id/display4"
                android:layout_width="450dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="_____________"
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView12"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="手機："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <TextView
                android:id="@+id/display5"
                android:layout_width="450dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="_____________"
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="150dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView13"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="課程學習心得："
                android:textColor="@android:color/background_dark"
                android:textSize="18sp" />

            <TextView
                android:id="@+id/display6"
                android:layout_width="450dp"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="_____________"
                android:textColor="@android:color/background_dark"
                android:textSize="14sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="50dp"
            android:orientation="horizontal">

            <Button
                android:id="@+id/button2"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:backgroundTint="@android:color/holo_blue_dark"
                android:text="返回上一頁"
                android:textColor="@android:color/background_light"
                android:textSize="18sp" />
        </LinearLayout>
    </LinearLayout>
</android.support.constraint.ConstraintLayout>

```
MainActivity.java
------------------
```
package com.example.ksuie.mybmi_final;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("Midterm exam_Page1");
        final Bundle bundle = new Bundle();

        Button btn_to_page2 = findViewById(R.id.button);
        btn_to_page2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                intent.setClass(MainActivity.this,Main2Activity.class);
                bundle.putString("key1",Classid());
                bundle.putString("key2",ID());
                bundle.putString("key3",name());
                bundle.putString("key4",email());
                bundle.putString("key5",phone());
                bundle.putString("key6",Experience());
                intent.putExtras(bundle);
                startActivity(intent);
            }
        });
    }

    public String Classid(){
        EditText classid = findViewById(R.id.input1);
        String classid_s = classid.getText().toString();
        return  classid_s;
    }

    public String ID (){
        EditText ID = findViewById(R.id.input2);
        String ID_s = ID.getText().toString();
        return ID_s ;
    }

    public String name (){
        EditText name = findViewById(R.id.input3);
        String name_s = name.getText().toString();
        return name_s;
    }

    public String email(){
        EditText email = findViewById(R.id.input4);
        String email_s = email.getText().toString();
        return email_s;
    }

    public String phone(){
        EditText phone = findViewById(R.id.input5);
        String phone_s = phone.getText().toString();
        return phone_s;
    }

    public String Experience(){
        EditText Experience = findViewById(R.id.input6);
        String Experience_s = Experience.getText().toString();
        return Experience_s;
    }
}

```
MainActivity2.java
------------------
```
package com.example.ksuie.mybmi_final;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class Main2Activity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);
        setTitle("Midterm exam_Page2");

        Bundle bundle = getIntent().getExtras();

        String Classid = bundle.getString("key1","Default");
        String ID = bundle.getString("key2","Default");
        String name = bundle.getString("key3","Default");
        String email = bundle.getString("key4","Default");
        String phone = bundle.getString("key5","Default");
        String Experience = bundle.getString("key6","Default");

        TextView display1 = findViewById(R.id.display1);
        TextView display2 = findViewById(R.id.display2);
        TextView display3 = findViewById(R.id.display3);
        TextView display4 = findViewById(R.id.display4);
        TextView display5 = findViewById(R.id.display5);
        TextView display6 = findViewById(R.id.display6);

        display1.setText(Classid);
        display2.setText(ID);
        display3.setText(name);
        display4.setText(email);
        display5.setText(phone);
        display6.setText(Experience);

        Button btn_to_page1 = findViewById(R.id.button2);
        btn_to_page1.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                intent.setClass(Main2Activity.this,MainActivity.class);
                finish();
            }
        });
    }
}

```



