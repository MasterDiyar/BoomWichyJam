using Godot;
using System;
using BoomWichi.scripts;

public partial class Statics : StaticBody2D, IDamagable
{
	public override void _Ready()
	{
		Hp = Health;
	}

	[Export] public float Health;
	public float Hp { get; set; } 
	public void TakeDamage(float damage)
	{
		Hp -= damage;
		if (Hp <= 0)
			QueueFree();
	}
}
