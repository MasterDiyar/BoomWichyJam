using Godot;
using System;

public partial class NodeRoll : Node
{
	[Export] public float RollSpeed;
	private Node2D node;
	public override void _Ready()
	{
		node = GetParent<Node2D>();
	}

	public override void _Process(double delta)
	{
		node.Rotate((float)delta * RollSpeed);
	}
}
