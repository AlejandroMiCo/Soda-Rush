using Godot;
using System;

public partial class Skeleton : Enemy
{
	private int health = 3;
	private Vector2 velocity;
	[Export] public AnimatedSprite2D sprite;

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		velocity.Y += GetGravity().Y * (float)delta;
		Velocity = velocity;
		MoveAndSlide();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
		if (health <= 0)
		{
			QueueFree();
		}
	}
}
