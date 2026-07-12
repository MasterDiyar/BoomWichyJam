using Godot;
using System;

public partial class Duplicator : Node
{
	[Export] private Timer timer;
	 private PackedScene node;
	public override void _Ready()
	{
		node = GD.Load<PackedScene>("res://scenes/enemy/bacteria.tscn");
		GlobalController.Instance.BacteriaCount++;
		timer.Timeout += TimerOnTimeout;
	}
	private void TimerOnTimeout()
	{
		if (GlobalController.Instance.BacteriaCount < GlobalController.Instance.MaxBacteriaCount)
		{
			var a = node.Instantiate<Node2D>();
			a.GlobalPosition = GetParent<Node2D>().GlobalPosition + Vector2.FromAngle(GD.Randf() * Single.Tau) * 23f;
			GetParent().GetParent().AddChild(a);
		}
	}

	public override void _ExitTree()
	{
		GlobalController.Instance.BacteriaCount--;
	}
}
