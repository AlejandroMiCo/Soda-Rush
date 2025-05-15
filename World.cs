using Godot;
using System;

public partial class World : Node2D
{
	[Export] public PackedScene defaultRoomScene;
	[Export] public PackedScene playerScene;
	[Export] public NodePath gameSaveManagerPath = "GameSaveManager";

	public override void _Ready()
	{
		var saveManager = GetNode<GameSaveManager>(gameSaveManagerPath);
		var saveData = saveManager.LoadGame();

		if (saveData != null)
		{
			GD.Print("✅ Cargando partida guardada...");

			// Cargar habitación guardada
			var roomScene = GD.Load<PackedScene>($"res://Scenes/Niveles/{saveData.CurrentRoom}.tscn");
			var room = roomScene.Instantiate<Node2D>();
			AddChild(room);

			// Instanciar y posicionar jugador
			var player = playerScene.Instantiate<Player>();
			player.GlobalPosition = saveData.PlayerPosition;

			if (saveData.DoubleJumpUnlocked)
				player.UnlockFloatJump(); // Usamos el método, no una propiedad pública

			AddChild(player);
		}
		else
		{
			GD.Print("🆕 No se encontró guardado, cargando habitación y jugador por defecto.");

			var room = defaultRoomScene.Instantiate<Node2D>();
			AddChild(room);

			var player = playerScene.Instantiate<Player>();
			player.GlobalPosition = new Vector2(100, 100); // Ajusta según el nivel
			AddChild(player);
		}
	}
}
