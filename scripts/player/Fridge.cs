using Godot;
using System;
using BoomWichi.scripts;

public partial class Fridge : StaticBody2D, IDamagable
{

	[Export] private TextureProgressBar bar;
	public float Hp { get; set; } = 100;
	public float MaxHp { get; set; } = 100;

	public void TakeDamage(float damage)
	{
		Hp -= damage;
		bar.MaxValue = MaxHp;
		bar.Value = (int)Hp;
		if (Hp <= 0)
		{
			QueueFree();
		}
		
	}
	
	
}
