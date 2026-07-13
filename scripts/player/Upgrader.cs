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
		RedOnion,
		Heal,
		RefrigeratorHeal
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
			case What.Lettuce: LettuceUpgrade(obj); break;
			
			case What.Bacon: BaconUpgrader(obj); break;
			case What.RedOnion: OnionGrader(obj); break;
			
			case What.Heal: player.TakeDamage(-30); break;
			case What.RefrigeratorHeal: GlobalController.Instance.holodos.TakeDamage(-60); break;
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

	private void LettuceUpgrade(int level)
	{
		switch (level)
		{
			case 1:
				var scene = GD.Load<PackedScene>("res://scenes/bullets/lettucant.tscn");
				player.AddIngridient(scene, What.Lettuce);
				break;
			case 2:
				player.Lettuce.AttackSpeed = 1;
				player.Lettuce.DamageModifer = 1.2f;
				break;
			case 3:
				player.Lettuce.AttackSpeed = 0.8f;
				break;
		}
	}


	public void BaconUpgrader(int level)
	{
		switch (level)
		{
			case 1:
				var scene = GD.Load<PackedScene>("res://scenes/bullets/baconShooter.tscn");
				player.AddIngridient(scene, What.Bacon);
				break;
			case 2:
				player.Bacon.ShootCount++;
				player.Bacon.bulletResource.Randomness += 0.01f;
				break;
			case 3:
				player.Bacon.ShootCount++;
				player.Bacon.bulletResource.Randomness += 0.04f;
				break;
		}
	}

	public void OnionGrader(int level)
	{
		switch (level)
		{
			case 1:
				player.MaxSpeed += 20;
				break;
			case 2:
				player.MaxSpeed += 30;
				break;
			case 3:
				player.MaxSpeed += 40;
				break;
		}
	}

	public void EggUpgrade(int level)
	{
		switch (level)
		{
			case 1:
				var scene = GD.Load<PackedScene>("res://scenes/bullets/eggshoot.tscn");
				player.AddIngridient(scene, What.Egg);
				break;
			case 2:
				player.Egg.Count += 2;
				break;
		}
	}
	
}
