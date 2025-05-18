using Godot;
using System;

public partial class Skeleton : CharacterBody2D
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
		// Resta vida, juega animaciones, etc.
		GD.Print($"Skeleton recibió {amount} de daño.");

		health -= amount;
		if (health <= 0)
		{
			GD.Print("Skeleton muerto");
			QueueFree();
		}
	}
}
