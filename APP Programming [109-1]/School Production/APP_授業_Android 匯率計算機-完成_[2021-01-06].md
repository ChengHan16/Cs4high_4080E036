Android 匯率計算機
=================
![Android 匯率計算機](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/image/Android%20%E5%8C%AF%E7%8E%87%E8%A8%88%E7%AE%97%E6%A9%9F.PNG)
Gradle Scripts => build.gradle(:app)
-----------------------------------
### 在dependencies {`implementation 'org.jsoup:jsoup:1.13.1'` //**加上這行**
```
apply plugin: 'com.android.application'

android {
    compileSdkVersion 30
    buildToolsVersion "30.0.3"

    defaultConfig {
        applicationId "com.example.mycurrency"
        minSdkVersion 21
        targetSdkVersion 30
        versionCode 1
        versionName "1.0"

        testInstrumentationRunner "android.support.test.runner.AndroidJUnitRunner"
    }

    buildTypes {
        release {
            minifyEnabled false
            proguardFiles getDefaultProguardFile('proguard-android-optimize.txt'), 'proguard-rules.pro'
        }
    }

}

dependencies {
    implementation fileTree(dir: 'libs', include: ['*.jar'])

    implementation 'com.android.support:appcompat-v7:28.0.0'
    implementation 'com.android.support.constraint:constraint-layout:2.0.4'
    implementation 'org.jsoup:jsoup:1.13.1'
    testImplementation 'junit:junit:4.12'
    androidTestImplementation 'com.android.support.test:runner:1.0.2'
    androidTestImplementation 'com.android.support.test.espresso:espresso-core:3.0.2'
}
```
values => strings.xml
---------------------
```
<resources>
    <string name="app_name">My Currency</string>

    <string-array name="currencyAbbreviaion">
        <item>USD</item>
        <item>GBP</item>
        <item>CAD</item>
        <item>KRW</item>
        <item>JPY</item>
    </string-array>

</resources>
```
AndroidManifest.xml
------------------
### 在manifests`<uses-permission android:name="android.permission.INTERNET"></uses-permission>` //**加上這行**
```
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android"
    package="com.example.mycurrency">

    <uses-permission android:name="android.permission.INTERNET"></uses-permission>

    <application
        android:allowBackup="true"
        android:icon="@mipmap/ic_launcher"
        android:label="@string/app_name"
        android:roundIcon="@mipmap/ic_launcher_round"
        android:supportsRtl="true"
        android:theme="@style/AppTheme">
        <activity android:name=".Main2Activity"></activity>
        <activity android:name=".MainActivity">
            <intent-filter>
                <action android:name="android.intent.action.MAIN" />

                <category android:name="android.intent.category.LAUNCHER" />
            </intent-filter>
        </activity>
    </application>

</manifest>
```
Activity_main
------------------
```
package com.example.mycurrency;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void  clickButton (View view){
        Intent intent = new Intent(MainActivity.this,Main2Activity.class);
        startActivity(intent);
    }
}
```
Activity_main2
------------------
```
package com.example.mycurrency;

import android.provider.SettingsSlicesContract;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.ListView;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.select.Elements;

import java.text.DecimalFormat;
import java.io.IOException;
import java.util.ArrayList;

public class Main2Activity extends AppCompatActivity {

    DecimalFormat df = new DecimalFormat("#.##");
    private double input_value;
    private double currency_USD;
    private double currency_GBP;
    private double currency_CAD;
    private double currency_KRW;
    private double currency_JPY;

    String[] currencyAbbreviation;
    String[] currencyValue = new String[5];
    LinearLayout linearLayout;
    ListView listView;
    ArrayList<String> currencyAbbreviationList;
    ArrayList<MyListElement> elementList = new ArrayList<MyListElement>();
    MyListAdapter myListAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);


        boolean done = getCurrencyFromBOT(); //呼叫副函式

        linearLayout = new LinearLayout(this);
        linearLayout.setOrientation(LinearLayout.VERTICAL);

        listView = new ListView(this);

        currencyAbbreviation = getResources().getStringArray(R.array.currencyAbbreviaion);

        for (int i = 0 ; i < currencyAbbreviation.length ; i++){
            MyListElement element = new MyListElement();
            element.setCurrencyAbbreiation(currencyAbbreviation[i]);
            element.setCurrencyValue(currencyValue[i]);
            element.setCountryIcon(android.R.drawable.btn_star_big_on);
            elementList.add(element);
        }
        myListAdapter = new MyListAdapter(this,elementList);
        listView.setAdapter(myListAdapter);

        linearLayout.addView(listView, new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT,0,1));

        setContentView(linearLayout);
    }
    private boolean getCurrencyFromBOT() {

        final boolean[] completeProcess = {false};

        Thread t = new Thread(new Runnable() {
            @Override
            public void run() {
                final StringBuilder builder = new StringBuilder();

                try {
                    //台灣銀行牌告匯率
                    Document doc = Jsoup.connect("https://rate.bot.com.tw/xrt?Lang=zh-TW").get();
                    String title = doc.title(); //取得網頁標題
                    Elements tds = doc.select("td"); //選擇網頁中td標籤中的內容
                    String currency_country = null;
                    String currency_rate_buy = null;
                    String currency_rate_sell = null;
                    String[] currency_country_token = null;

                    //builder.append(title).append("\n");

                    //for(int i = 0; i < tds.size(); i=i+11){
                    int i = 0;  //currency_USD 美金
                    currency_country = tds.get(i).text();
                    currency_country_token = currency_country.split(" "); //字串切割
                    currency_rate_buy = tds.get((i + 1)).text();
                    currency_rate_sell = tds.get((i + 2)).text();
                    currency_USD = (Double.parseDouble(currency_rate_buy)
                            + Double.parseDouble(currency_rate_sell)) / 2;
                    builder.append(currency_country_token[0])
                            .append("\t").append(currency_USD)
                            .append("\n");
                    currencyValue[0] = df.format(currency_USD);

                    int j = 22; //currency_GBP 英鎊
                    currency_country = tds.get(j).text();
                    currency_country_token = currency_country.split(" "); //字串切割
                    currency_rate_buy = tds.get((j + 1)).text();
                    currency_rate_sell = tds.get((j + 2)).text();
                    currency_GBP = (Double.parseDouble(currency_rate_buy)
                            + Double.parseDouble(currency_rate_sell)) / 2;
                    builder.append(currency_country_token[0])
                            .append("\t").append(currency_GBP)
                            .append("\n");
                    currencyValue[1] = df.format(currency_GBP);

                    int k = 44; //currency_CAD 加幣
                    currency_country = tds.get(k).text();
                    currency_country_token = currency_country.split(" "); //字串切割
                    currency_rate_buy = tds.get((k + 1)).text();
                    currency_rate_sell = tds.get((k + 2)).text();
                    currency_CAD = (Double.parseDouble(currency_rate_buy)
                            + Double.parseDouble(currency_rate_sell)) / 2;
                    builder.append(currency_country_token[0])
                            .append("\t").append(currency_CAD)
                            .append("\n");
                    currencyValue[2] = df.format(currency_CAD);


                    int l = 165; //currency_KRW 韓元
                    currency_country = tds.get(l).text();
                    currency_country_token = currency_country.split(" "); //字串切割
                    currency_rate_buy = tds.get((l + 1)).text();
                    currency_rate_sell = tds.get((l + 2)).text();
                    currency_KRW = (Double.parseDouble(currency_rate_buy)
                            + Double.parseDouble(currency_rate_sell)) / 2;
                    builder.append(currency_country_token[0])
                            .append("\t").append(currency_KRW)
                            .append("\n");
                    currencyValue[3] = df.format(currency_KRW);


                    int m = 77; //currency_JPY 日圓
                    currency_country = tds.get(m).text();
                    currency_country_token = currency_country.split(" "); //字串切割
                    currency_rate_buy = tds.get((m + 1)).text();
                    currency_rate_sell = tds.get((m + 2)).text();
                    currency_JPY = (Double.parseDouble(currency_rate_buy)
                            + Double.parseDouble(currency_rate_sell)) / 2;
                    builder.append(currency_country_token[0])
                            .append("\t").append(currency_JPY)
                            .append("\n");
                    currencyValue[4] = df.format(currency_JPY);

                    completeProcess[0] = true;


                } catch (IOException e) {
                    builder.append("Error : ").append(e.getMessage()).append("\n");
                }

                }
        });

        t.start();
        try {
            t.join();
        } catch (InterruptedException e) { e.printStackTrace(); }

        if(completeProcess[0] == true){
            return true;
        }
        else{
            return false;
        }
    }//getCurrencyFromBOT() 函式結束
}
```
MyListAdapter
------------------
```
package com.example.mycurrency;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

public class MyListAdapter extends BaseAdapter {

    private Activity activity;
    private ArrayList<MyListElement> elementList;

    MyListAdapter(Activity activity, ArrayList<MyListElement> elementList){
        this.activity = activity;
        this.elementList = elementList;
    }

    @Override
    public int getCount() {
        return elementList.size();
    }

    @Override
    public Object getItem(int i) {
        return elementList.get(i);
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        view = activity.getLayoutInflater().inflate(
                R.layout.layout_mylist_element, null);

        ImageView img = (ImageView)view.findViewById(R.id.imageView);
        TextView textViewTitle = (TextView)view.findViewById(R.id.textViewLarge);
        TextView textViewValue = (TextView)view.findViewById(R.id.textViewValue);
        img.setImageResource(elementList.get(i).getCountryIcon());

        String currencyAbbreviation = elementList.get(i).getCurrencyAbbreiation();
        String currencyValue = elementList.get(i).getCurrencyValue();
        textViewTitle.setText(currencyAbbreviation);
        textViewValue.setText(currencyValue);
        return view;
    }
}
```
MyListElement
------------------
```
package com.example.mycurrency;

public class MyListElement {
    public int getCountryIcon() {
        return countryIcon;
    }

    public void setCountryIcon(int countryIcon) {
        this.countryIcon = countryIcon;
    }

    public String getCurrencyAbbreiation() {
        return currencyAbbreiation;
    }

    public void setCurrencyAbbreiation(String currencyAbbreiation) {
        this.currencyAbbreiation = currencyAbbreiation;
    }

    private int countryIcon;
    private String currencyAbbreiation;

    public String getCurrencyValue() {
        return currencyValue;
    }

    public void setCurrencyValue(String currencyValue) {
        this.currencyValue = currencyValue;
    }

    private String currencyValue;
}
```
activity_main.xml
------------------
```
<?xml version="1.0" encoding="utf-8"?>
<android.support.constraint.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context=".MainActivity">

    <LinearLayout
        android:layout_width="409dp"
        android:layout_height="729dp"
        android:layout_marginStart="1dp"
        android:layout_marginTop="1dp"
        android:layout_marginEnd="1dp"
        android:layout_marginBottom="1dp"
        android:orientation="vertical"
        app:layout_constraintBottom_toBottomOf="parent"
        app:layout_constraintEnd_toEndOf="parent"
        app:layout_constraintStart_toStartOf="parent"
        app:layout_constraintTop_toTopOf="parent">

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="120dp"
            android:orientation="horizontal">

            <TextView
                android:id="@+id/textView"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:gravity="center"
                android:text="My Currency"
                android:textSize="30sp" />
        </LinearLayout>

        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="120dp"
            android:orientation="horizontal">

            <ImageButton
                android:id="@+id/imageButton"
                android:layout_width="match_parent"
                android:layout_height="match_parent"
                android:layout_weight="1"
                android:onClick="clickButton"
                app:srcCompat="@mipmap/ic_launcher" />
        </LinearLayout>
    </LinearLayout>
</android.support.constraint.ConstraintLayout>
```
layout_mylist_element.xml
------------------
```
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical" android:layout_width="match_parent"
    android:layout_height="match_parent">

  <LinearLayout
      android:layout_width="match_parent"
      android:layout_height="wrap_content"
      android:orientation="horizontal">

      <LinearLayout
          android:layout_width="match_parent"
          android:layout_height="wrap_content"
          android:orientation="horizontal">

        <ImageView
            android:id="@+id/imageView"
            android:layout_width="64dp"
            android:layout_height="64dp"
            android:layout_marginLeft="16dp"
            android:layout_marginRight="16dp"
            android:src="@android:drawable/btn_star_big_on" />

        <TextView
            android:id="@+id/textViewLarge"
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_marginLeft="12dp"
            android:layout_marginRight="12dp"
            android:gravity="center_vertical"
            android:text="Text"
            android:textAppearance="?android:attr/textAppearanceLarge"
            android:textSize="50sp" />

        <TextView
            android:id="@+id/textViewValue"
            android:layout_width="match_parent"
            android:layout_height="match_parent"
            android:layout_marginLeft="12dp"
            android:layout_marginRight="12dp"
            android:gravity="right|center_horizontal|center_vertical"
            android:text="Value"
            android:textAppearance="?android:attr/textAppearanceLarge"
            android:textSize="40sp" />
      </LinearLayout>

  </LinearLayout>

</LinearLayout>
```
strings.xml
------------------
```
<resources>
    <string name="app_name">My Currency</string>

    <string-array name="currencyAbbreviaion">
        <item>USD</item>
        <item>GBP</item>
        <item>CAD</item>
        <item>KRW</item>
        <item>JPY</item>
    </string-array>

</resources>
```
