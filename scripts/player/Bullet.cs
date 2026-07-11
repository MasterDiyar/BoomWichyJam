using Godot;
using System;
using BoomWichi.scripts;

public partial class Bullet : Area2D
{
	public IDamagable parent;
	public BulletResource BulletResource;
	public float LifeTime, Damage = 1, Speed, Pierce, Acceleration;
	
	public override void _Ready()
	{
		LifeTime = BulletResource.LifeTime;
		Damage *= BulletResource.Damage;
		Speed = BulletResource.Speed;
		Pierce = BulletResource.Pierce;
		Acceleration = BulletResource.Acceleration;
		
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body == parent) return;
		LifeTime -= Pierce;
		if (body is IDamagable damagable)
		{
			damagable.TakeDamage(Damage);
		}
	}

	public override void _Process(double delta)
	{
		var dt = (float)delta;
		LifeTime -= dt;
		Speed += Acceleration * dt;
		Position += Vector2.FromAngle(Rotation) * Speed * dt;
		
		if (LifeTime <= 0) QueueFree();
	}
	
	
}
