using Godot;
using System;

public partial class UnlockJump : Area2D
{
	[Export] private AudioStreamPlayer sound;
	public override void _Ready()
	{
		var saveManager = GetTree().Root.GetNode<GameSaveManager>("World/GameSaveManager");
		if (saveManager.RuntimeData.DoubleJumpUnlocked)
		{
			QueueFree();
		}
	}
	public void OnBodyEnteredPowerUp(Node2D body)
	{
		sound.Play();
		if (body is Player player)
		{

			player.UnlockFloatJump();
			QueueFree();
			var saveManager = GetTree().Root.GetNode<GameSaveManager>("World/GameSaveManager");
			saveManager.RuntimeData.DoubleJumpUnlocked = true;

		}
	}
}
