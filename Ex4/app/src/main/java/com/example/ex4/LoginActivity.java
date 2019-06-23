package com.example.ex4;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

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
                String ip_str = ip.getText().toString().trim();
                String port_str = port.getText().toString().trim();
                if (!ip_str.equals("") && !port_str.equals("")) {
                    i.putExtra("IP", ip_str);
                    i.putExtra("PORT", Integer.parseInt(port.getText().toString().trim()));
                    startActivity(i);
                } else
                    Toast.makeText(LoginActivity.this, "IP or Port is empty", Toast.LENGTH_LONG).show();
            }
        });
    }
}
