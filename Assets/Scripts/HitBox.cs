using Godot;
using System;

public partial class HitBox : Area2D
{
    [Export] public int damage;
    [Export] public Node2D owner; // Referencia al que genera el ataque

    public void ActivateHitbox()
    {
        foreach (Node2D body in GetOverlappingBodies())
        {

            var x = body.GetNode<Area2D>("HurtBox");

            if (x is HurtBox hurtbox && hurtbox.Owner != owner)
            {
                hurtbox.ReceiveDamage(damage);
            }
        }
    }
}
