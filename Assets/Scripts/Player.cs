using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Export] public float speed = 200f;
    private Vector2 velocity;
    private AnimationNodeStateMachinePlayback stm;
    [Export] public AnimationTree aTree;
    [Export] public Sprite2D sprite;
    [Export] public float jumpForce = 50f;

    // Se ejecuta cuando el nodo se carga en la escena
    public override void _Ready()
    {
        base._Ready();
        stm = (AnimationNodeStateMachinePlayback)aTree.Get("parameters/playback");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        //Obtiene el nombre de los controles de godot
        Vector2 direccion = new Vector2(Input.GetActionStrength("right") - Input.GetActionStrength("left"), 0);

        if (IsOnFloor() && Input.IsActionJustPressed("jump"))
        {
            velocity.Y = -jumpForce * 8F;
            stm.Travel("jump");

        }
        else if (!IsOnFloor())
        {
            velocity.Y += GetGravity().Y * (float)delta;
        }
        else if(Input.IsActionPressed("attack")){
            stm.Travel("Attack");
        }
        else if (Velocity.X != 0)
        {
            stm.Travel("Run");
            if (Velocity.X < 0)
            {
                sprite.FlipH = true;
            }

            if (Velocity.X > 0)
            {
                sprite.FlipH = false;
            }
        }
        else
        {
            stm.Travel("Idle");
        }

        velocity.X = direccion.X * speed;
        Velocity = velocity;
        MoveAndSlide();
    }
}
