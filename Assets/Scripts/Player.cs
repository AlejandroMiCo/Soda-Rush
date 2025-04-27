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

    private float SPEED = 200f;
    private bool canDoubleJump = true;
    private bool isFloating = false;



    // Se ejecuta cuando el nodo se carga en la escena
    public override void _Ready()
    {
        base._Ready();
        stm = (AnimationNodeStateMachinePlayback)aTree.Get("parameters/playback");
    }

    public override void _PhysicsProcess(double delta)
    {

        System.Console.WriteLine("Velocity: " + Velocity.Y);

        base._PhysicsProcess(delta);
        speed = SPEED;

        //Obtiene el nombre de los controles de godot
        Vector2 direccion = new Vector2(Input.GetActionStrength("right") - Input.GetActionStrength("left"), 0);


        if (Input.IsActionJustPressed("attack"))
        {
            stm.Travel("Attack");
            return;
        }

        if (IsOnFloor() && Input.IsActionJustPressed("jump"))
        {
            velocity.Y = -jumpForce * 8F;
        }

        if (!IsOnFloor())
        {
            stm.Travel("jump");
        }

        if (!IsOnFloor() && Input.IsActionPressed("jump") && canDoubleJump && velocity.Y > 0)
        {
            doubleJump();
        }

        if (!IsOnFloor() && Input.IsActionJustReleased("jump"))
        {
            isFloating = false;
        }

        if (!IsOnFloor() && !isFloating)
        {
            velocity.Y += GetGravity().Y * (float)delta;
        }

        if (isFloating)
        {
            velocity.Y -= 2;
            speed = SPEED / 3;
        }

        if (IsOnFloor())
        {
            canDoubleJump = true;
        }

        if (IsOnFloor() && Velocity.X != 0)
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
        
        if (IsOnFloor() && Velocity.X == 0)
        {
            stm.Travel("Idle");
        }

        velocity.X = direccion.X * speed;
        Velocity = velocity;
        MoveAndSlide();
    }

    public void doubleJump()
    {
        canDoubleJump = false;
        isFloating = true;
    }
}
