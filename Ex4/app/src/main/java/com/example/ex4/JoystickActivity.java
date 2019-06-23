package com.example.ex4;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;

import java.io.OutputStream;
import java.net.Socket;
import java.nio.charset.Charset;

public class JoystickActivity extends AppCompatActivity implements JoystickView.JoystickListener {
    Socket socket;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_joystick);
        new Thread() {
            public void run() {
                Bundle b = getIntent().getExtras();
                if (b != null) {
                    try {
                        String ip = b.getString("IP");
                        int port = b.getInt("PORT");
                        socket = new Socket(ip, port);
                    } catch (Exception e) {
                        Log.d("Exception", "Normal");
                    }
                }
            }
        }.start();
    }

    @Override
    public void onJoystickMoved(float xPercent, float yPercent) {
        final float x = xPercent;
        final float y = yPercent;
        new Thread() {
            public void run() {
                OutputStream stream;
                try {
                    String aileron = "set /controls/flight/aileron " + x + System.lineSeparator();
                    String elevator = "set /controls/flight/elevator " + y + System.lineSeparator();
                    if (socket != null) {
                        stream = socket.getOutputStream();
                        byte[] aileronBytes = aileron.getBytes(Charset.forName("UTF-8"));
                        stream.write(aileronBytes);
                        byte[] elevatorBytes = elevator.getBytes(Charset.forName("UTF-8"));
                        stream.write(elevatorBytes);
                    }
                } catch (Exception e) {
                    Log.e("Error", "failed");
                }
            }
        }.start();
    }

    @Override
    public void onJoystickDestroyed() {
        try {
            socket.close();
        } catch (Exception e) {

        }
    }
}
