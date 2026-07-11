using Godot;
using System;
using BoomWichi.scripts.player;

public partial class KostBoom : AfterDeath
{
	[Export] PackedScene bulletScene;
	[Export] BulletResource bulletResource;
	[Export] private int Count = 6;
	public override void After_Death()
	{
		for (int i = 0; i < Count; i++)
		{
			Bullet bullet = bulletScene.Instantiate<Bullet>();

			bullet.Rotation = Mathf.Tau / Count * i;
			bullet.Position = GetParent<Node2D>().GlobalPosition;
			bullet.BulletResource = bulletResource;
			GetTree().Root.CallDeferred("add_child", bullet);
		}
	}
}
