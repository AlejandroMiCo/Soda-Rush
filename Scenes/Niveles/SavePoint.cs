using Godot;
using System;

public partial class SavePoint : Area2D
{
	[Export] public string currentRoom; // ID único del punto de guardado
	private bool canSave = false;
	private Player player;
	[Export] private AudioStreamPlayer sonido;


	public void SetPlayer(Player p)
	{
		player = p;
	}

	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		Connect("body_exited", new Callable(this, nameof(OnBodyExited)));
	}

	private void OnBodyEntered(Node body)
	{
		if (body is Player)
		{
			canSave = true;
		}
	}

	private void OnBodyExited(Node body)
	{
		if (body is Player)
		{
			canSave = false;
		}
	}

	public override void _Process(double delta)
	{
		if (player == null)
		{
			player = GetTree().Root.FindChild("Player", true, false) as Player;
			if (player == null)
				return;
		}

		if (canSave && Input.IsActionJustPressed("interact"))
		{
			sonido.Play();
			var saveManager = GetTree().Root.GetNode<GameSaveManager>("/root/World/GameSaveManager");

			var data = player.GetCurrentState(); // Obtener estado actual del jugador
			data.CurrentRoom = currentRoom; // Agregar ID del punto de guardado

			saveManager.SaveGame(data);
		}
	}
}
