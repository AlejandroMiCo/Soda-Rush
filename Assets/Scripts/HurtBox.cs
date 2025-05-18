
using Godot;
using System;

public partial class HurtBox : Area2D
{
	[Export] public new Node2D Owner;

	public virtual void ReceiveDamage(int amount)
	{
		GD.Print($"{Owner.Name} recibió {amount} de daño.");

		// Aquí puedes llamar a métodos del objeto afectado
		if (Owner.HasMethod("TakeDamage"))
		{
			Owner.Call("TakeDamage", amount);
		}
	}
}
