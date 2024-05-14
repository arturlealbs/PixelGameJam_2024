using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public int speed = 100;
	private Side currentSide = Side.Bottom;
	private bool hasBackpack = true;
	private Node waterCapacity;
	private AnimatedSprite2D animation;

    public override void _Ready()
    {
        animation = GetChild<AnimatedSprite2D>(0);
		waterCapacity = GetNode("WaterCapacityComponent");
    }

    public override void _PhysicsProcess(double delta)
	{
		SideTick();
		switch(currentSide)
		{
			case Side.Bottom:
			{
				Bottom();
				break;
			}
			case Side.Top:
			{
				Top();
				break;
			}

			case Side.Left:
			{
				Left();
				break;
			}

			case Side.Right:
			{
				Right();
				break;
			}
		}

	}

	private void SideTick()
	{
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		
		Velocity = inputDirection * speed;
		MoveAndSlide();

		if(inputDirection.X > 0)
		{
			currentSide = Side.Right;
			return;
		}

		if(inputDirection.X < 0)
		{
			currentSide = Side.Left;
			return;
		}

		if(inputDirection.Y > 0)
		{
			currentSide = Side.Bottom;
			return;
		}

		if(inputDirection.Y < 0)
		{
			currentSide = Side.Top;
			return;
		}

		animation.Frame = 0;
	}

	private void Bottom()
	{
		PlayAnimation("down_walk", false, true);
	}

	private void Top()
	{
		PlayAnimation("up_walk", false, true);
	}

	private void Left()
	{
		PlayAnimation("left_walk", false, true);
	}

	private void Right()
	{
		PlayAnimation("right_walk", false, true);
	}

	private void PlayAnimation(String animationName, bool backwards = false, bool force = false)
	{
		if(!hasBackpack) animationName += "_nowater";

		if(!backwards && (force || !animation.IsPlaying()))
		{
			animation.Play(animationName);
			return;
		}

		if(backwards && (force || !animation.IsPlaying()))
		{
			animation.Play(animationName, -1, true);
			return;
		}
	}

	public bool HasBackpack()
	{
		return hasBackpack;
	}

	public void SetHasBackpack(bool state)
	{
		hasBackpack = state;
	}

	public bool IsBackpackFull()
	{
		return (bool) waterCapacity.Call("is_full");
	}

	public float GetBackpackCurrentCapacity()
	{
		return (float) waterCapacity.Get("current_capacity");
	}

	public float GetBackpackMaxCapacity()
	{
		return (float) waterCapacity.Get("MAX_CAPACITY");
	}

	public void IncreaseBackpackCurrentCapacity(float amount)
	{
		waterCapacity.Call("increase", amount);
	}

	public void DecreaseBackpackCurrentCapacity(float amount)
	{
		waterCapacity.Call("decrease", amount);
	}
}
