using Godot;
using System;

public partial class WaterFiller : Node2D
{
	/* TODO

		FAZER UMA STATE MACHINE PARA OS MAQUINÁRIOS
		STATES COMO: IDLE, FILLING, FILLED

		MELHORAR O TRACKING DO PLAYER / GLOBAL TALVEZ ?
	*/


	private InteractableComponent interactable;
	private Node waterCapacity;
	private bool isFilling = false;

	public override void _Ready()
	{
		interactable = GetNode<InteractableComponent>("InteractableComponent");
		interactable.PlayerInRange += UpdateInfo;
		interactable.OnInteraction += Interact;
		waterCapacity = GetNode("WaterCapacityComponent");
	}

	private void UpdateInfo(Player player)
	{
		string formattedString = String.Format("Capacity: {0}/{1}", waterCapacity.Get("current_capacity"), waterCapacity.Get("MAX_CAPACITY"));
		
		if(player.HasBackpack() && !player.IsBackpackFull())
		{
			formattedString += String.Format("\nPress {0} to Fill your backpack",  interactable.GetButtonNameFromAction("interact"));
		}
		else if(!player.HasBackpack() && isFilling)
		{
			formattedString += String.Format("\nPress {0} to get your backpack\nBackpack: {1}/{2}", interactable.GetButtonNameFromAction("interact"), player.GetBackpackCurrentCapacity(), player.GetBackpackMaxCapacity());
		}

		interactable.ChangeLabelText(formattedString);
	}

	private void Interact(Player player)
	{
		if(player.HasBackpack())
		{
			if(player.IsBackpackFull())
			{
				return;
			}
			Fill(player);
			return;
		}

		if(!player.HasBackpack() && isFilling)
		{
			player.SetHasBackpack(true);
			isFilling = false;
		}
		UpdateInfo(player);
	}

	private void Fill(Player player)
	{
		isFilling = true;
		player.SetHasBackpack(false);
		player.IncreaseBackpackCurrentCapacity(2.5f);
	}
}
