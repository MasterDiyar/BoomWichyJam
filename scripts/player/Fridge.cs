using Godot;
using System;
using BoomWichi.scripts;

public partial class Fridge : StaticBody2D, IDamagable
{


	public float Hp { get; set; } = 100;

	public void TakeDamage(float damage)
	{
		Hp -= damage;
		if (Hp <= 0)
		{
			QueueFree();
		}
	}
}
