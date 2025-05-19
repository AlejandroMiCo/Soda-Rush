using Godot;
using System;

public partial class PathFollow2d : PathFollow2D
{

	[Export] public float speed = 0.1f;
	public bool isMoonWalking = false;
	public bool isSkeleton = false;
	public Enemy enemy;

	public override void _Ready()
	{
		base._Ready();
		enemy = GetChild(0) as Enemy;
		isSkeleton = enemy.GetType() == typeof(Skeleton);
	}

	public override void _Process(double delta)
	{
		if (enemy != null && IsInstanceValid(enemy))
		{
			if (isMoonWalking)
			{
				ProgressRatio -= speed * (float)delta;
				if (isSkeleton)
				{
					((Skeleton)enemy).sprite.FlipH = true;
				}

				if (ProgressRatio <= 0)
				{
					isMoonWalking = false;
				}
			}
			else
			{

				ProgressRatio += speed * (float)delta;

				if (isSkeleton)
				{
					((Skeleton)enemy).sprite.FlipH = false;
				}

				if (ProgressRatio >= 1)
				{
					isMoonWalking = true;
				}
			}	
		}
	}
}
