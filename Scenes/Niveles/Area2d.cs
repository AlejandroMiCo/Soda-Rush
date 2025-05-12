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
                Vector2 extents = rectShape.Size;

                int left = Mathf.RoundToInt(globalCenter.X - extents.X);
                int right = Mathf.RoundToInt(globalCenter.X + extents.X);
                int top = Mathf.RoundToInt(globalCenter.Y - extents.Y);
                int bottom = Mathf.RoundToInt(globalCenter.Y + extents.Y);

                camera.LimitLeft = left;
                camera.LimitRight = right;
                camera.LimitTop = top;
                camera.LimitBottom = bottom;
            }

        }
    }
}

