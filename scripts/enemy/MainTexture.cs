using Godot;
using System;

public partial class MainTexture : Sprite2D
{
	[Export] private Texture2D[] text;
	public override void _Ready()
	{
		Texture = text[GD.RandRange(0, text.Length-1)];
	}
}
