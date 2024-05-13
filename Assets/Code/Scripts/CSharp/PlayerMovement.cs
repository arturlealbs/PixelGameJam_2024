using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[Export]
	public int speed = 100;

	public override void _PhysicsProcess(double delta)
	{
		MoveTick();
	}

	private void MoveTick()
	{
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * speed;
		MoveAndSlide();
	}

}
