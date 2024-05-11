using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{

	public int speed = 100;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * speed;
		MoveAndSlide();
    }

}
