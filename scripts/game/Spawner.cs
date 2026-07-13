using Godot;
using System;

public partial class Spawner : Node2D
{
	[Export] public WaveResource[] Waves;
	private Node2D parent;
	public override void _Ready()
	{
		parent = GetParent<Node2D>();
		GlobalController.Instance.WaveStarted += WaveStarted;
	}

	private void WaveStarted(int num)
	{
		var obj = num - 1;
		if (obj >= Waves.Length ) obj = Waves.Length - 1;
		
		if (Waves[obj].Units == null) return;
		foreach (var res in Waves[obj].Units)
		{
			for (int i = 0; i < res.Count; i++)
			{
				var unit = res.Unit.Instantiate<Enemy>();
				unit.Position = GlobalPosition + res.SpawnOffset * Vector2.FromAngle(GD.Randf() * Mathf.Tau);
				parent.AddChild(unit);
			}
		}
	}
	public override void _ExitTree()
	{
		if (GlobalController.Instance != null)
		{
			GlobalController.Instance.WaveStarted -= WaveStarted;
		}
	}
}
