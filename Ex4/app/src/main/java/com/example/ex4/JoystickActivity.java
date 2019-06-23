package com.example.ex4;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Canvas;
import android.os.Bundle;
import android.widget.Toast;

public class JoystickActivity extends AppCompatActivity {

    private JoystickView joystickView;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_joystick);
        Bundle b = getIntent().getExtras();
        if (b != null) {
            String ip = b.getString("IP");
            int port = b.getInt("PORT");
            String s = "port: " + port + ", ip: " + ip;
        }
        joystickView = new JoystickView(this);
        setContentView(joystickView);

    }

}
