# BMI APP Code.md
This is an H1
=============

This is an H2
-------------
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
