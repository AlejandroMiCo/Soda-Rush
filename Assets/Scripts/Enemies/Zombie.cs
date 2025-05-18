using Godot;
using System;

public partial class Zombie : CharacterBody2D
{

    private Vector2 velocity;

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
        GD.Print($"Jugador recibió {amount} de daño.");
    }

}
