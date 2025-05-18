using Godot;
using System;

public partial class UnlockJump : Area2D
{

	public override void _Ready()
	{
		var saveManager = GetTree().Root.GetNode<GameSaveManager>("World/GameSaveManager");

		if (saveManager.RuntimeData.DoubleJumpUnlocked)
		{
			QueueFree(); // Ya lo recogió en esta sesión
		}
	}
	public void OnBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			player.UnlockFloatJump();

			QueueFree();
			var saveManager = GetTree().Root.GetNode<GameSaveManager>("World/GameSaveManager");
			saveManager.RuntimeData.DoubleJumpUnlocked = true;

		}
	}
}
