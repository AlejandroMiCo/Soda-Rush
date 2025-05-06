using Godot;
using System;

public partial class Skeleton : CharacterBody2D
{

	private Vector2 velocity;
	[Export] public AnimatedSprite2D sprite;
	
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		velocity.Y += GetGravity().Y * (float)delta;
		Velocity = velocity;
		MoveAndSlide();
	}
}
