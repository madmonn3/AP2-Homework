package com.example.ex4;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class LoginActivity extends AppCompatActivity {
    Button connect;
    EditText ip, port;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        this.connect = (Button) findViewById(R.id.connect_btn);
        this.ip = (EditText) findViewById(R.id.ip_txt);
        this.port = (EditText) findViewById(R.id.port_txt);

        connect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(LoginActivity.this , JoystickActivity.class);
                i.putExtra("IP", ip.getText().toString().trim());
                i.putExtra("PORT", Integer.parseInt(port.getText().toString().trim()));
                startActivity(i);
            }
        });
    }
}
