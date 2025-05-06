using Godot;
using System;

public partial class LimiteDeCamara : Area2D
{
	//private void _on_body_entered(Node body){
		//
		//if(body is Player){
			//CallDeferred("ChangeCameraLimits");
		//}
			//
		//}
	//}
	//
	//private void ChangeCameraLimits(){
			//var camera = body.GetNode<Camera2D>("Camera2D");
			//
			//var shape = GetNode<CollisionShape2D>("CollisionShape2D").Shape as RectangleShape2D;
			//
			//Vector2 globalPos = GlobalPosition;
			//Vector2 size = shape.Size;
			//
			//float halfWidth = size.X /2;
			//float halfHeight = size.Y /2;
			//
			//camera.LimitLeft = Mathf.RoundToInt(globalPos.X - halfWidth);
			//camera.LimitRight = Mathf.RoundToInt(globalPos.X + halfWidth);
			//camera.LimitTop = Mathf.RoundToInt(globalPos.Y - halfHeight);
			//camera.LimitBottom = Mathf.RoundToInt(globalPos.Y + halfHeight);
	//}
}
