using Godot;
using System;

public partial class SavePoint : Area2D
{
	[Export] public string id; // ID único del punto de guardado
	private bool canSave = false;
	private Player player;

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
				return; // No hay player aún, salir
		}

		if (canSave && Input.IsActionJustPressed("interact"))
		{

			var saveManager = GetTree().Root.GetNode<GameSaveManager>("/root/World/GameSaveManager");

			var data = player.GetCurrentState(); // Obtener estado actual del jugador
			data.LastSavePointId = id; // Agregar ID del punto de guardado

			saveManager.SaveGame(data);

			GD.Print($"Guardado realizado en punto: {id}");
			// Aquí podrías agregar animación, sonido, etc.
		}
	}
}
