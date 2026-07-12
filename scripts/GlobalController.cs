using Godot;
using System;

public partial class GlobalController : Node
{
	public Fridge holodos;
	[Export] public float MoneyAmplifier = 1;
	public float Money=1000;
	
	public static GlobalController Instance;
	
	public int TomatoSeedCount = 6;
	public float TomatoSeedDamageAmplifier = 1;
	
	public Hamburg Player;

	public int Wave = 0;

	public Action<int> WaveStarted;
	public override void _Ready()
	{
		Instance = this;
	}
}
