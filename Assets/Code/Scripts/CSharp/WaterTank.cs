using Godot;
using System;

public partial class WaterTank : StaticBody2D
{

	private InteractableComponent interactable;
	private Node waterCapacity;

	public override void _Ready()
	{
		waterCapacity = GetNode("WaterCapacityComponent");

		interactable = GetNode<InteractableComponent>("InteractableComponent");
		interactable.PlayerInRange += UpdateInfo;

	}

	private void UpdateInfo(Player player)
	{
		string formattedString = String.Format("Capacity: {0}/{1}\nPress '{2}' to fill\nPress '{3}' to drain", waterCapacity.Get("current_capacity"), waterCapacity.Get("MAX_CAPACITY"), interactable.GetButtonNameFromAction("interact"), "X");
		interactable.ChangeLabelText(formattedString);
	}

}
