# ページ換える
Activity_main.xml
==================
![Change_Page_APP](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E3%83%9A%E3%83%BC%E3%82%B8%E6%8F%9B%E3%81%88%E3%82%8B.PNG)
![Change_Page_APP1](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/%E3%83%9A%E3%83%BC%E3%82%B8%E6%8F%9B%E3%81%88%E3%82%8B(1).PNG)
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
