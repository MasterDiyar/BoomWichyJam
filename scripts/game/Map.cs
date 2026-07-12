using Godot;
using System;

public partial class Map : Node2D
{
	[Export] private StaticBody2D holodos;
	public override void _Ready()
	{
		GlobalController.Instance.holodos = holodos;
	}
}
