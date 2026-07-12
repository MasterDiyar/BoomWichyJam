using Godot;
using System;

public partial class Ai : Node2D
{
	public enum Type
	{
		Attacker,
		Rusher,
		Healer
	}
	
	[Export] public Type type;
	[Export] public Enemy mob;
	[Export] public Area2D vision;
	
	private Hamburg player;
	private Enemy friend;
	private StaticBody2D holodos;
	public override void _Ready()
	{
		player = GlobalController.Instance.Player;
		vision.BodyEntered += VisionOnBodyEntered;
	}

	private void VisionOnBodyEntered(Node2D body)
	{
		if (type == Type.Healer) return;
		
		
	}

	public override void _Process(double delta)
	{
	}

	void Act(float dt)
	{
		switch (type)
		{
			case Type.Attacker:
				MoveTo(holodos.GlobalPosition);
				break;
		}
	}

	void MoveTo(Vector2 dir)
	{
		var angle = (mob.GlobalPosition - dir).Angle();
		mob.Velocity = Vector2.FromAngle(angle) * mob.MaxSpeed;
		mob.MoveAndSlide();
	}
}
