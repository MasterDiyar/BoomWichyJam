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
	private Fridge holodos;
	
	private Node2D currentTarget;

	private bool mayAttack = false;
	public override void _Ready()
	{
		holodos = GlobalController.Instance.holodos;
		player = GlobalController.Instance.Player;
		vision.BodyEntered += VisionOnBodyEntered;
		vision.BodyExited += VisionOnBodyExited;
		CallDeferred(MethodName.InitHolodos);
	}

	private void InitHolodos()
	{
		holodos = GlobalController.Instance.holodos;
	}

	private void VisionOnBodyExited(Node2D body)
	{
		if (body == currentTarget)
			currentTarget = null;
	}

	private void VisionOnBodyEntered(Node2D body)
	{
		var parent = body;

		if (type == Type.Healer && parent is Enemy e && e != mob) {
			currentTarget = body; 
		}
		else if (type == Type.Attacker && parent is Hamburg) {
			currentTarget = body; 
		}
		else if (type == Type.Rusher && parent is Fridge) {
			currentTarget = body; 
		}
		
	}

	public override void _PhysicsProcess(double delta)
	{
		if (currentTarget != null && IsInstanceValid(currentTarget)) 
			AttackTarget();
		
		else 
			Act((float)delta);
		
		mob.MoveAndSlide(); 
	}
	
	void AttackTarget()
	{
		mob.Velocity = Vector2.Zero; 
		var angle = (currentTarget.GlobalPosition - mob.GlobalPosition).Angle();
		mob.AttackAction?.Invoke(angle);
	}

	void Act(float dt) {
		switch (type) {
			case Type.Rusher:
				if (holodos != null)MoveTo(holodos.GlobalPosition);
				break;
			case Type.Attacker:
				if (player != null)MoveTo(player.GlobalPosition);
				break;
			case Type.Healer:
				if (player != null)MoveTo(friend.GlobalPosition);
				break;
		}
	}

	void MoveTo(Vector2 dir)
	{
		mob.Velocity = mob.GlobalPosition.DirectionTo(dir) * mob.MaxSpeed; 
		
	}
}
