using Godot;
using System;

public partial class Leg : Sprite2D
{
	[Export] private Sprite2D[] legs;

	public override void _Process(double delta)
	{
		for (int i = 0; i < legs.Length; i++)
		{
			legs[i].Position += Vector2.Left * i * 5 * (float)delta;
		}
	}
}
