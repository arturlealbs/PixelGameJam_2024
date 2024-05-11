using Godot;
using System;

public partial class PlayerMovement : Node2D
{

	public int speed = 2;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Position += inputDirection * speed;
    }

}
