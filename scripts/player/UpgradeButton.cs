using Godot;
using System;

public partial class UpgradeButton : Button
{
	[Export] public UpgradeResource[] upgrades;
	private int _level =0;
	public override void _Ready()
	{
		Setup(_level);
	}

	public override void _Pressed()
	{
		_level++;
		Setup(_level);
	}

	void Setup(int level)
	{
		if (upgrades?[level] == null) return;
		Icon = upgrades[level].texture;
		Text = $"{upgrades[level].Name} \ncost: X{upgrades[level].Count}";
	}

}
