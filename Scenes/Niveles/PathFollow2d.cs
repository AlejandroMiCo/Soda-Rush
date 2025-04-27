using Godot;
using System;

public partial class PathFollow2d : PathFollow2D
{

    [Export] public float speed = 0.1f;
    public bool isMoonWalking = false;
    public bool isSkeleton = false;

    public Skeleton skeleton;

    public override void _Ready()
    {
        base._Ready();
        skeleton = GetChild(0) as Skeleton;

        isSkeleton = skeleton != null;
    }

    public override void _Process(double delta)
    {

        if (isMoonWalking)
        {
            ProgressRatio -= speed * (float)(delta);
            if (isSkeleton)
            {
                skeleton.sprite.FlipH = true;
            }

            if (ProgressRatio <= 0)
            {
                isMoonWalking = false;
            }
        }
        else
        {
            ProgressRatio += speed * (float)(delta);

            if (isSkeleton){
                skeleton.sprite.FlipH = false;
            }

            if (ProgressRatio >= 1)
            {
                isMoonWalking = true;
            }
        }

    }
}
