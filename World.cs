using Godot;
using System;

public partial class World : Node2D
{
	[Export] public PackedScene defaultRoomScene;
	[Export] public NodePath gameSaveManagerPath = "GameSaveManager";

	public override void _Ready()
	{
		var saveManager = GetNode<GameSaveManager>(gameSaveManagerPath);
		var saveData = saveManager.LoadGame();

		if (saveData != null)
		{

			// Cargar habitación guardada
			var roomScene = GD.Load<PackedScene>($"res://Scenes/Niveles/{saveData.CurrentRoom}.tscn");
			var room = roomScene.Instantiate<Node2D>();
			AddChild(room);

			// Instanciar y posicionar jugador
			var player = GetTree().Root.GetNode<Player>("/root/World/Player");
			var position = room.GetNode<Marker2D>("SaveSpawn");
			System.Console.WriteLine(position.Position);
			player.GlobalPosition = position.Position;

			if (saveData.DoubleJumpUnlocked)
				player.UnlockFloatJump();

			AddChild(player);
		}
		else
		{
			var room = defaultRoomScene.Instantiate<Node2D>();
			AddChild(room);

			var player = GetTree().Root.GetNode<Player>("/root/World/Player");
			player.GlobalPosition = new Vector2(0, 350); // Ajusta según el nivel
			AddChild(player);
		}
	}
}
