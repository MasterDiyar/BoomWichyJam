using Godot;
using System;

public partial class GlobalController : Node
{
	public Fridge holodos;
	public float MoneyAmplifier = 1;
	public float Money=0;
	
	public static GlobalController Instance;
	
	public int TomatoSeedCount = 6;
	public float TomatoSeedDamageAmplifier = 1;
	
	public Hamburg Player;
	public Map Mapmap;

	public int Wave = 0;

	public int BacteriaCount = 0;
	public int MaxBacteriaCount = 40;
	
	public Action<int> WaveStarted;
	
	public int TrumpCount = 0;

	public Action OnWin;
	public Action OnLose;
	
	public override void _Ready()
	{
		Instance = this;
	}
	
	public void Reload()
	{
		Money = 0;
		MoneyAmplifier = 1;
    
		TomatoSeedCount = 6;
		TomatoSeedDamageAmplifier = 1;
    
		Wave = 0;
		BacteriaCount = 0;
		TrumpCount = 0;
		
		holodos = null;
		Player = null;
		Mapmap = null;
    
		WaveStarted = null;
		OnWin = null;
		OnLose = null;
	}
}
