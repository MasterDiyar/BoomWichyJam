using Godot;
using System;
using BoomWichi.scripts;

public partial class Hamburg : CharacterBody2D, IDamagable
{
	[Export] public UnitResource playerResource; 
	[Export] public AnimationPlayer animationPlayer;
	[Export] public Node2D whereAdd, Head;
	[Export] public Area2D CollectArea;

	public Action<float> AttackAction;
	public Action MoneyChanged, HpChanged;
	
	public float MaxHp, MaxSpeed, MaxShield;
	public float Hp { get; set; }
	public float Shield {get; set;}
	public int Money;
	

	private float Speed = 30;
	

	public override void _Ready()
	{
		MaxHp = playerResource.MaxHp;
		Hp = MaxHp;
		MaxSpeed = playerResource.MaxSpeed;
		MaxShield = playerResource.MaxShield;
		Shield = MaxShield;

		CollectArea.AreaEntered += Collect;
	}


	public override void _PhysicsProcess(double delta)
	{
		var dt = (float)delta;
		Move(dt);
		MoveAndSlide();
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event.IsActionPressed("lm"))
			AttackAction?.Invoke((GetGlobalMousePosition() - GlobalPosition).Angle());
	}

	void Move(float dt)
	{
		Vector2 MoveDir = Input.GetVector("a", "d", "w", "s");

		if (MoveDir.Length() <= 0.01f)
		{
			Velocity = Vector2.Zero;
			animationPlayer.Play("RESET");
			return;
			
		}
		animationPlayer.Play("move");
		Velocity = MoveDir * Speed;
	}

	public void AddIngridient(PackedScene ingridientScene)
	{
		Head.Position += Vector2.Up * 4;
		var ingridient = ingridientScene.Instantiate<Node2D>();
		ingridient.Position += Vector2.Up * whereAdd.GetChildCount() * 4;
		whereAdd.AddChild(ingridient);
	}

	public void TakeDamage(float damage)
	{
		if (Shield > 0) {
			Shield -= damage;
			return;
		}
		
		Hp -= damage;
		
		if (Hp <= 0)
			OnLoose();
		
		HpChanged?.Invoke();
	}

	void OnLoose()
	{
		
		
	}

	void Collect(Area2D area)
	{
		if (area is Money n)
		{
			Money += n.Count;
			MoneyChanged?.Invoke();
		}
	}
}
