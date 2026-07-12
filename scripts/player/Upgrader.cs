using Godot;
using System;

public partial class Upgrader : Node
{
	public enum What
	{
		Tomato,
		Cucumber,
		Lettuce,
		Egg,
		Kotlet,
		Bacon,
		Cheese,
		RedOnion
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
			case What.Tomato: TomatoUpgrade(obj); break;
			case What.Cucumber: CucumberUpgrade(obj); break;
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

	private void CucumberUpgrade(int level)
	{
		switch (level)
		{
			case 1:
				var scene = GD.Load<PackedScene>("res://scenes/bullets/cucumbritta.tscn");
				player.AddIngridient(scene, What.Cucumber);
				break;
			case 2:
				player.Cucumber.Additionals = [GD.Load<PackedScene>("res://scenes/bullets/ogurets_boom.tscn")];
				player.Cucumber.bulletResource.Speed += 90;
				break;
			case 3:
				player.Cucumber.bulletResource.Speed += 90;
				player.Cucumber.bulletResource.Randomness = 0.2f;
				player.Cucumber.bulletResource.Damage += 10;
				break;
		}
	}
	
	
	
}
