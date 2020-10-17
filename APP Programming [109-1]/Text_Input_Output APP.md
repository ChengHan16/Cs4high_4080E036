Activity_main.xml
-----------------
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
            android:text="使用者名稱"
            android:textSize="30sp" />

        <EditText
            android:id="@+id/inputName"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:ems="10"
            android:gravity="center"
            android:hint="Name："
            android:inputType="textPersonName"
            android:textSize="30sp" />

        <Button
            android:id="@+id/button"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:onClick="displayName"
            android:text="確定(Determine)"
            android:textColor="@color/black"
            android:textSize="30sp"
            app:backgroundTint="@android:color/darker_gray" />

        <TextView
            android:id="@+id/display"
            android:layout_width="match_parent"
            android:layout_height="80dp"
            android:gravity="center"
            android:text="_________________"
            android:textColor="@android:color/tertiary_text_dark"
            android:textSize="30sp" />
    </LinearLayout>
</androidx.constraintlayout.widget.ConstraintLayout>
```
MainActivity.java
-----------------
```
package com.example.text_input_output;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void displayName(View view) {
        EditText input = findViewById(R.id.inputName);
        String name = input.getText().toString();

        TextView display = findViewById(R.id.display);
        display.setText(name);
    }
}
```
