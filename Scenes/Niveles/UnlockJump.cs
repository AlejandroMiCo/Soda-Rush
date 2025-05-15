using Godot;
using System;

public partial class UnlockJump : Area2D
{
	public void OnBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			player = (Player)body;
			player.UnlockFloatJump();
			QueueFree();
		}
	}
}
