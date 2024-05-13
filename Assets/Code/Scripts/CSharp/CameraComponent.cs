using Godot;
using System;

public partial class CameraComponent : Camera2D
{

	private int xRoom = 0;
	private int yRoom = 0;

	public void CameraTransition(CharacterBody2D player)
	{
		GD.Print(GetParent().Name + " -> " + player.Position);
		MoveCamera(player.Position);		
	}

	private void MoveCamera(Vector2 playerPosition)
	{
		// Moving Right
		if(playerPosition.X > 450 + (480 * xRoom))
		{
			Position = new Vector2(Position.X + 480, Position.Y);
			xRoom++;
		}
		// Movin Left
		else if(playerPosition.X < 25 + (480 * xRoom))
		{
			Position = new Vector2(Position.X - 480, Position.Y);
			xRoom--;
		}
		// Moving Down
		else if(playerPosition.Y > 245 + (270 * yRoom))
		{
			Position = new Vector2(Position.X, Position.Y + 270);
			yRoom++;
		}
		// Moving Up
		else if(playerPosition.Y < 25 + (270 * yRoom))
		{
			Position = new Vector2(Position.X, Position.Y - 270);
			yRoom--;
		}
	}
}
