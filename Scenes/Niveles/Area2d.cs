using Godot;
using System;

public partial class Area2d : Area2D
{
    private void OnBodyEntered(Node body)
    {
        if (body is Player player)
        {
            Camera2D camera = body.GetNode<Camera2D>("Camera2D");
            CollisionShape2D shapeNode = GetNode<CollisionShape2D>("CollisionShape2D");

            if (shapeNode.Shape is RectangleShape2D rectShape)
            {
                Vector2 globalCenter = GlobalPosition;
                Vector2 size = rectShape.Size;

                int left = Mathf.RoundToInt(globalCenter.X - (size.X / 2));
                int right = Mathf.RoundToInt(globalCenter.X + (size.X) / 2);
                int top = Mathf.RoundToInt(globalCenter.Y - (size.Y / 2));
                int bottom = Mathf.RoundToInt(globalCenter.Y + (size.Y) / 2);

                camera.LimitLeft = left;
                camera.LimitRight = right;
                camera.LimitTop = top;
                camera.LimitBottom = bottom;
            }

        }
    }
}

