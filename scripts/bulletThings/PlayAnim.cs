using Godot;
using System;

public partial class PlayAnim : AnimatedSprite2D
{

	[Export] private string AnimName;
	public override void _Ready()
	{
		Play(AnimName);
	}

}
