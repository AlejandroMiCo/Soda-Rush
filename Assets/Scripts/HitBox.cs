using Godot;
using System;

public partial class HitBox : Area2D
{
    [Export] public int damage;
    [Export] public Node2D owner; // Referencia al que genera el ataque

    public void ActivateHitbox()
    {
        System.Console.WriteLine("Hitbox activado");
        foreach (Node2D body in GetOverlappingBodies())
        {

            var x = body.GetNode<Area2D>("HurtBox");

            if (x is HurtBox hurtbox && hurtbox.Owner != owner)
            {
                System.Console.WriteLine("patata2");
                hurtbox.ReceiveDamage(damage);
            }
        }
    }
}
