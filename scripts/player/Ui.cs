using Godot;
using System;

public partial class Ui : CanvasLayer
{
	[Export] private Hamburg parent;

	[Export] private Label MoneyCountLabel;
	[Export] private ProgressBar HpProgressBar;
	
	public override void _Ready()
	{
		parent.MoneyChanged += MoneyChanged;
		parent.HpChanged += HpChanged;
	}

	private void HpChanged()
	{
		HpProgressBar.MaxValue = parent.MaxHp;
		HpProgressBar.Value = parent.Hp;
	}

	private void MoneyChanged()
	{
		MoneyCountLabel.Text = $"X{(int)GlobalController.Instance.Money}";
	}
	
	
}
