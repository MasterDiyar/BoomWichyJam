using Godot;
using System;

public partial class GlobalController : Node
{
	[Export] public float MoneyAmplifier = 1;
	public float Money=1000;
	
	public static GlobalController Instance;
	
	public int TomatoSeedCount = 6;
	public float TomatoSeedDamageAmplifier = 1;
	
	public Hamburg Player;
	
	public override void _Ready()
	{
		Instance = this;
	}
}
