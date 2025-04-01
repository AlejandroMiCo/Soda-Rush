using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Export] public float speed = 100f;
    private Vector2 velocity;
    private AnimationNodeStateMachinePlayback stm;
    [Export] public AnimationTree aTree;
    [Export] public Sprite2D sprite;

    // Se ejecuta cuando el nodo se carga en la escena
    public override void _Ready()
    {
        base._Ready();
        stm = (AnimationNodeStateMachinePlayback)aTree.Get("parameters/playback");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        //pilla el nombre de los controles de godot
        Vector2 direccion = new Vector2(Input.GetActionStrength("derecha") - Input.GetActionStrength("izquierda"), 0);

        velocity.X = direccion.X * speed;
        Velocity = velocity;
        MoveAndSlide();

        if (Velocity.X != 0)
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

    }

}
