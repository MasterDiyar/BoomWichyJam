using Godot;
using System;

public partial class UpgradeButton : Button
{
	[Export] public UpgradeResource[] upgrades;
	private int _level =0;
	public Action<int> OnUpgradeSuccess;
	public override void _Ready()
	{
		Setup(_level);
	}

	public override void _Pressed()
	{
		if (upgrades == null || _level >= upgrades.Length) return;
		
		float cost = upgrades[_level].Count;

		if (!(GlobalController.Instance.Money >= cost)) return;
		GlobalController.Instance.Money -= cost;
			
		_level++;
		Setup(_level);
            
		OnUpgradeSuccess?.Invoke(_level);
	}

	void Setup(int level)
	{
		if (upgrades == null || level >= upgrades.Length) {
			Text = "MAX LEVEL";
			Disabled = true;
			return;
		}
		TooltipText = upgrades[level].Description;
		Icon = upgrades[level].texture;
		Text = $"{upgrades[level].Name} \ncost: X{upgrades[level].Count}";
	}

}
