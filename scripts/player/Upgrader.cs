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
			case What.Egg:  EggUpgrade(obj); break;
			case What.Bacon: BaconUpgrader(obj); break;
			case What.RedOnion: OnionGrader(obj); break;
			case What.Kotlet:  KotletUpgrade(obj); break;
			case What.Cheese : CheesyUpgrade(obj); break;
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
				var scene = GD.Load<PackedScene>("res://scenes/bullets/onionin.tscn");
				player.AddIngridient(scene, What.RedOnion);
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
				player.Egg.bulletResource.StartAngle += 0.15f;
				player.Egg.bulletResource.BetweenAngle -= 0.1f;
				break;
			case 3:
				player.Egg.Count += 2;
				player.Egg.bulletResource.StartAngle += 0.2f;
				player.Egg.bulletResource.BetweenAngle -= 0.08f;
				player.Egg.DamageModifer = 1.2f;
				break;
		}
	}

	public void KotletUpgrade(int level)
	{
		switch (level)
		{
			case 1:
				var scene = GD.Load<PackedScene>("res://scenes/bullets/calletaStrike.tscn");
				player.AddIngridient(scene, What.Kotlet);
				break;
			case 2:
				player.Kotlet.bulletResource.Speed += 90;
				break;
			case 3:
				player.Kotlet.Count = 6;
				player.Kotlet.bulletResource.BetweenAngle = Mathf.Tau / 6;
				player.Kotlet.bulletResource.Speed += 90;
				break;
		}
	}

	public void CheesyUpgrade(int level)
	{
		switch (level)
		{
			case 1:
				var scene = GD.Load<PackedScene>("res://scenes/bullets/cheese_shooter.tscn");
				player.AddIngridient(scene, What.Cheese);
				break;
			case 2:
				player.Cheese.DamageModifer = 1.25f;
				break;
			case 3:
				player.Cheese.Count = 3;
				break;
		}
	}
	
}
