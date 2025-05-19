using Godot;
using System;

public partial class Zombie : Enemy
{

    private Vector2 velocity;
	private int health = 1;


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
