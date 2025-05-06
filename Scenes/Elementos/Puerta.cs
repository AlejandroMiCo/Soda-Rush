using Godot;
using System;
using System.Threading.Tasks;


public partial class Puerta : Area2D
{
	// Path to the target room scene
	[Export(PropertyHint.File)]
	public string targetRoomScenePath { get; set; }
	[Export] public string deletedRoom { get; set; }
	[Export] public string spawnMarker { get; set; }

	private Node2D player;


	private void _on_body_entered(Node2D body)
	{
		if (body is Player)
		{
			player = body;
			CallDeferred("ChangeRoom");
		}
	}

	private void ChangeRoom()
	{
		
		var world = GetTree().GetRoot().GetNode<Node>("/root/World");
		world.GetNode(deletedRoom).QueueFree(); 

		var newRoomScene = GD.Load<PackedScene>(targetRoomScenePath);

		var instatiatedRoom = newRoomScene.Instantiate();

		world.AddChild(instatiatedRoom);

		var marker = instatiatedRoom.GetNodeOrNull<Marker2D>(spawnMarker);

		if (marker != null)
		{
			player.Position = marker.Position;
		}
	}
}
