using Godot;
using System;

public partial class UpgradeButton : Button
{
	[Export] public UpgradeResource[] upgrades;
	[Export] public bool IsInfinite  = false;
	private int _level =0;
	public Action<int> OnUpgradeSuccess;
	
	public override void _Ready()
	{
		Setup(_level);
	}

	public override void _Pressed()
	{
		float cost;
		if (IsInfinite)
		{
			cost = upgrades[0].Count;
			if (!(GlobalController.Instance.Money >= cost)) return;
			GlobalController.Instance.Money -= cost;
		}else {
			if (upgrades == null || _level >= upgrades.Length) return;

			cost = upgrades[_level].Count;

			if (!(GlobalController.Instance.Money >= cost)) return;
			GlobalController.Instance.Money -= cost;

			_level++;
		}
		Setup(_level);
            
		OnUpgradeSuccess?.Invoke(_level);
	}

	void Setup(int level)
	{
		if (IsInfinite && upgrades is { Length: > 0 })
		{
			TooltipText = upgrades[0].Description;
			Icon = upgrades[0].texture;
           
			Text = $"{upgrades[0].Name} (Lv.{level})\ncost: X{upgrades[0].Count}"; 
			return;
		}
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
