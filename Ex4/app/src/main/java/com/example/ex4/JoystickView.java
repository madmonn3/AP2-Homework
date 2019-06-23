package com.example.ex4;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.PorterDuff;
import android.util.AttributeSet;
import android.view.SurfaceView;
import android.view.SurfaceHolder;

public class JoystickView extends SurfaceView implements SurfaceHolder.Callback {
    private float centerX;
    private float centerY;
    private float baseRadius;
    private float hatRadius;

    public JoystickView(Context ctx) {
        super(ctx);
        getHolder().addCallback(this);
    }

    public JoystickView(Context ctx, AttributeSet attributeSet, int style) {
        super(ctx, attributeSet, style);
        getHolder().addCallback(this);
    }

    public JoystickView(Context ctx, AttributeSet attributeSet) {
        super(ctx, attributeSet);
        getHolder().addCallback(this);
    }

    private void drawJoystick(float x, float y) {
        if (getHolder().getSurface().isValid()) {
            Canvas canvas = this.getHolder().lockCanvas();
            Paint colors = new Paint();
            canvas.drawColor(Color.TRANSPARENT, PorterDuff.Mode.CLEAR);
            // joystick base:
            colors.setARGB(255, 50, 50, 50);
            canvas.drawCircle(centerX, centerY, baseRadius, colors);
            // joystick hat:
            colors.setARGB(255, 0, 0, 255);
            canvas.drawCircle(x, y,hatRadius, colors);
            getHolder().unlockCanvasAndPost(canvas);
        }
    }

    @Override
    public void surfaceCreated(SurfaceHolder surfaceHolder) {
        setupDimensions();
        drawJoystick(centerX, centerY);
    }

    @Override
    public void surfaceChanged(SurfaceHolder surfaceHolder, int i, int i1, int i2) {

    }

    @Override
    public void surfaceDestroyed(SurfaceHolder surfaceHolder) {

    }

    private void setupDimensions() {
        centerX = getWidth() / 2;
        centerY = getHeight() / 2;
        baseRadius = Math.min(getWidth(), getHeight()) / 3;
        hatRadius = Math.min(getWidth(), getHeight()) / 5;
    }
}
