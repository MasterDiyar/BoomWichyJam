using Godot;
using System;

public partial class Upgrader : Node
{
	public enum What
	{
		Tomato
	}

	[Export] private What _what;

	private UpgradeButton Parent;
	private Hamburg player;
	public override void _Ready()
	{
		player = GlobalController.Instance.Player;
		Parent = GetParent<UpgradeButton>();
		Parent.OnUpgradeSuccess += OnUpgradeSuccess;
	}

	private void OnUpgradeSuccess(int obj)
	{
		player = GlobalController.Instance.Player;
		player.MoneyChanged?.Invoke();
		switch (_what)
		{
			case What.Tomato:
				TomatoUpgrade(obj);
				break;
		}
	}

	private void TomatoUpgrade(int level)
	{
		switch (level)
		{
			case 1:
				var scene = GD.Load<PackedScene>("res://scenes/bullets/pomidorki.tscn");
				player.AddIngridient(scene, What.Tomato);
				break;
			case 2:
				player.Pomidor.AttackSpeed = 0.8f;
				GlobalController.Instance.TomatoSeedCount = 8;
				break;
			case 3:
				player.Pomidor.bulletResource.BetweenAngle *= 0.5f;
				player.Pomidor.bulletResource.StartAngle *= 0.5f;
				GlobalController.Instance.TomatoSeedCount = 10;
				GlobalController.Instance.TomatoSeedDamageAmplifier = 1.3f;
				break;
		}
	}
	
}
