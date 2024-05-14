using Godot;
using System;

public partial class InteractableComponent : Node
{
	
	[Signal]
	public delegate void OnInteractionEventHandler(Player player);

	[Signal]
	public delegate void PlayerInRangeEventHandler(Player player);

	private Area2D hitbox;
	private Label label;
	private Player playerReference;

	public override void _Ready()
	{
		hitbox = GetChild<Area2D>(0);
		hitbox.BodyEntered += PlayerEntered;
		hitbox.BodyExited += PlayerExited;
		label = GetChild<Label>(1);
	}

    public override void _PhysicsProcess(double delta)
    {
        if(Input.IsActionJustPressed("interact1") && label.Visible)
        {
			GD.Print("OnInteraction emitted from: " + GetParent().Name);
			EmitSignal(SignalName.OnInteraction, playerReference);
		}
    }

	public void ChangeLabelText(string text)
	{
		label.Text = text;
	}

    private void PlayerEntered(Node2D player)
	{
		playerReference = (Player) player;
		EmitSignal(SignalName.PlayerInRange, player);
		label.Visible = true;
	}

	private void PlayerExited(Node2D player)
	{
		label.Visible = false;
		playerReference = null;
	}

	public string GetButtonNameFromAction(string action)
	{
		return InputMap.ActionGetEvents(action)[0].AsText().Split(" ")[0];
	}

}
