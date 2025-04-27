using Godot;
using System;

public partial class PathFollow2d : PathFollow2D
{

    public float speed = 0.1f;
    public bool isMoonWalking = false;



    public override void _Process(double delta)
    {
        if (isMoonWalking)
        {
            ProgressRatio -= speed * (float)(delta);
            if (ProgressRatio <= 0)
            {
                isMoonWalking = false;
            }
        }
        else
        {
            ProgressRatio += speed * (float)(delta);
            if (ProgressRatio >= 1)
            {
                isMoonWalking = true;
            }
        }
    }
}
