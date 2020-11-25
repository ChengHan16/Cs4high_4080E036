# invisible
```
package com.example.ksuie.mybmi_final;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

public class Main2Activity extends AppCompatActivity {

    ImageView imageview;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);
        Bundle bundle = getIntent().getExtras(); //接收第一頁傳來的值，並放進bundle
        String info_s = bundle.getString("key1", "Default"); //擷取從bundle傳來的字串
        TextView display = findViewById(R.id.display2);
        display.setText(info_s); //顯示結果

        imageview = (ImageView)findViewById(R.id.imageView);

        //-----findViewById跟View有關係的都必須放在onCreate內-----
    }
    public void backButton(View view){
        //返回第一頁
        Intent intent = new Intent();
        intent.setClass(Main2Activity.this, MainActivity.class);
        startActivity(intent);
    }

    public void pic1Button(View view){
        imageview.setImageResource(R.drawable.no1);
        imageview.setVisibility(View.VISIBLE);
    }

    public void pic2Button(View view){
        imageview.setImageResource(R.drawable.no2);
        imageview.setVisibility(View.VISIBLE);
    }

    public void pic3Button(View view){
        imageview.setImageResource(R.drawable.no6);
        imageview.setVisibility(View.VISIBLE);
    }
}
```
[*]
```
public void pic1Button(View view){
        imageview.setImageResource(R.drawable.no1);
        imageview.setVisibility(View.VISIBLE);
    }

    public void pic2Button(View view){
        imageview.setImageResource(R.drawable.no2);
        imageview.setVisibility(View.VISIBLE);
    }

    public void pic3Button(View view){
        imageview.setImageResource(R.drawable.no6);
        imageview.setVisibility(View.VISIBLE);
    }
```
