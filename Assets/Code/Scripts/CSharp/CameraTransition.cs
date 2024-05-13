using Godot;
using System;

public partial class CameraTransition : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += CallCamera;
	}

	private void CallCamera(Node2D player)
	{
		GetTree().CallGroup("Camera", "CameraTransition", player);
	}
}
