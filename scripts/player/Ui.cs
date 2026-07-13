using Godot;
using System;

public partial class Ui : CanvasLayer
{
	[Export] private Hamburg parent;

	[Export] private Label MoneyCountLabel, TimerLabel;
	[Export] private ProgressBar HpProgressBar;
	[Export] private Control Holodos, Loose, Win;
	[Export] Button winButton, loseButton;
	
	public override void _Ready()
	{
		parent.MoneyChanged += MoneyChanged;
		parent.HpChanged += HpChanged;
		parent.OpenHolodilnik += OpenFridge;
		HpProgressBar.MaxValue = parent.MaxHp;

		GlobalController.Instance.OnLose += () => Loose.Visible = true;
		GlobalController.Instance.OnWin += () => Win.Visible = true;
		
		winButton.Pressed += WinButtonOnPressed;
		loseButton.Pressed += WinButtonOnPressed;
	}

	private void WinButtonOnPressed()
	{
		GlobalController.Instance.Mapmap.GetParent().AddChild(GD.Load<PackedScene>("res://scenes/menu.tscn").Instantiate());
		GlobalController.Instance.Mapmap.QueueFree();
		GlobalController.Instance.Reload();
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

	private void OpenFridge()
	{
		Holodos.Visible = true;
	}

	public override void _Process(double delta)
	{
		TimerLabel.Text = $"{(int)GlobalController.Instance.Mapmap.timer.TimeLeft}";
	}
}
