using Godot;
using System;

public partial class GlobalController : Node
{
	[Export] public float MoneyAmplifier = 1;
	public float Money=0;
	public static GlobalController Instance;
	public override void _Ready()
	{
		Instance = this;
	}
}
