using Godot;
using System.Text.Json;

public partial class GameSaveManager : Node
{
	private const string SavePath = "user://savegame.json";
	public SaveData RuntimeData { get; private set; }

	public override void _Ready()
	{
		RuntimeData = LoadGame() ?? new SaveData();
	}
	public class SaveData
	{
		public Vector2 PlayerPosition { get; set; }
		public string CurrentRoom { get; set; }
		public string LastSavePointId { get; set; }
		public bool DoubleJumpUnlocked { get; set; }
	}

	public void SaveGame(SaveData data)
	{
		string json = JsonSerializer.Serialize(data);
		using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
		file.StoreString(json);
		GD.Print("Juego guardado.");
	}

	public SaveData LoadGame()
	{
		if (!FileAccess.FileExists(SavePath)) return null;
		using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Read);
		string json = file.GetAsText();
		return JsonSerializer.Deserialize<SaveData>(json);
	}

}
