using Godot;
using System;
using BoomWichi;
using BoomWichi.scripts.enemy;

public partial class AttackHandler : Node2D
{
	[Export] PackedScene bulletScene;
	[Export] public BulletResource bulletResource;
	[Export] private int Count = 1;
	[Export] public float DamageModifer =1;
	[Export] public float AttackSpeed =1;
	[Export] public float Offset = 0;
	[Export] public PackedScene[] Additionals;
	private float TimeAfterAttack = 0;
	private bool CanAttack = true;
	private Entity parent;
	public override void _Ready()
	{
		parent = this.GetFirstParentOfType<Entity>();
		parent.AttackAction += AttackAction;
	}

	private void AttackAction(float angle)
	{
		if (!CanAttack) return;
		CanAttack = false;
		TimeAfterAttack = AttackSpeed;
		for (int i = 0; i < Count; i++) {
			Bullet bullet = bulletScene.Instantiate<Bullet>();
			bullet.parent = parent;
			var rand = GD.Randf() * bulletResource.Randomness;
			bullet.Rotation = -bulletResource.StartAngle + angle + i * bulletResource.BetweenAngle + rand;
			bullet.Position = GlobalPosition + Vector2.FromAngle(bullet.Rotation) * Offset;
			
			bullet.BulletResource = bulletResource;
			bullet.Damage = DamageModifer;
			bullet.Scale *= bulletResource.Scaler;

			if (Additionals != null) 
				foreach (var node in Additionals)
					bullet.AddChild(node.Instantiate());
			
			GetTree().Root.AddChild(bullet);
			
		}
	}

	public override void _Process(double delta)
	{
		if (TimeAfterAttack > 0)
			TimeAfterAttack -= (float)delta;
		
		else CanAttack = true;
	}
}
