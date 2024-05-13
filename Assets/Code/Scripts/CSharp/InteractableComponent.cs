using Godot;
using System;

public partial class InteractableComponent : Node
{
	
	[Signal]
	public delegate void OnInteractionEventHandler();

	private Area2D hitbox;
	private Label label;

	public override void _Ready()
	{
		hitbox = GetChild<Area2D>(0);
		hitbox.BodyEntered += PlayerEntered;
		hitbox.BodyExited += PlayerExited;
		label = GetChild<Label>(1);
		label.Text = InputMap.ActionGetEvents("interact")[0].AsText().Split(" ")[0];
	}

    public override void _PhysicsProcess(double delta)
    {
        if(Input.IsActionJustPressed("interact") && label.Visible)
        {
			GD.Print("OnInteraction emitted from: " + GetParent().Name);
			EmitSignal(SignalName.OnInteraction);
		}
    }

    private void PlayerEntered(Node2D player)
	{
		label.Visible = true;
	}

	private void PlayerExited(Node2D player)
	{
		label.Visible = false;
	}

}
