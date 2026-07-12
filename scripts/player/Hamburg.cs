using Godot;
using System;
using BoomWichi;
using BoomWichi.scripts;
using BoomWichi.scripts.enemy;

public partial class Hamburg : Entity
{
	[Export] public UnitResource playerResource;
	[Export] public AnimationPlayer animationPlayer;
	[Export] public Node2D whereAdd, Head, body;
	[Export] public Area2D CollectArea;

	public Action MoneyChanged, HpChanged, OpenHolodilnik;

	public float MaxHp, MaxSpeed, MaxShield;
	public float Shield { get; set; }


	private float Speed = 30;
	private bool _canOpen = false;

	public AttackHandler Pomidor,
		Cucumber,
		Lettuce,
		Egg,
		Kotlet,
		Bacon,
		Cheese,
		RedOnion;


	public override void _Ready()
	{
		if (GlobalController.Instance.Player == null) GlobalController.Instance.Player = this;
		MaxHp = playerResource.MaxHp;
		Hp = MaxHp;
		MaxSpeed = playerResource.MaxSpeed;
		Speed = MaxSpeed;
		MaxShield = playerResource.MaxShield;
		Shield = MaxShield;

		CollectArea.AreaEntered += Collect;
		CollectArea.BodyEntered += Find;
		CollectArea.BodyExited += UnFind;
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
		if (@event.IsActionPressed("e") && _canOpen) OpenHolodilnik?.Invoke();
			
	}

	void Move(float dt)
	{
		Vector2 MoveDir = Input.GetVector("a", "d", "w", "s");
		body.Scale = Input.IsActionPressed("a") ? new Vector2(-1, 1) : new Vector2(1, 1);
		
		if (MoveDir.Length() <= 0.01f)
		{
			Velocity = Vector2.Zero;
			animationPlayer.Play("RESET");
			return;

		}

		animationPlayer.Play("move");
		Velocity = MoveDir * Speed;
	}

	public void AddIngridient(PackedScene ingridientScene, Upgrader.What what)
	{
		Head.Position += Vector2.Up * 4;
		var ingridient = ingridientScene.Instantiate<AttackHandler>();
		ingridient.Position += Vector2.Up * whereAdd.GetChildCount() * 4;
		whereAdd.AddChild(ingridient);

		switch (what)
		{
			case Upgrader.What.Tomato: Pomidor = ingridient; break;
			case Upgrader.What.Cucumber: Cucumber = ingridient; break;
			case Upgrader.What.Lettuce: Lettuce = ingridient; break;
			case Upgrader.What.Egg: Egg = ingridient; break;
			case Upgrader.What.Kotlet: Kotlet = ingridient; break;
			case Upgrader.What.Bacon: Bacon = ingridient; break;
			case Upgrader.What.RedOnion: RedOnion = ingridient; break;
			case Upgrader.What.Cheese: Cheese = ingridient; break;
		}
	}

	public override void TakeDamage(float damage)
	{
		if (Shield > 0)
		{
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
			GlobalController.Instance.Money += n.Count;
			n.QueueFree();
			MoneyChanged?.Invoke();
		}
	}

	void Find(Node2D node)
	{
		if (node is not StaticBody2D g) return;
		if (g.IsInGroup("holodilnik"))
		{
			_canOpen = true;
		}
	}

	void UnFind(Node2D node)
	{
		if (node is not StaticBody2D g) return;
		if (g.IsInGroup("holodilnik"))
		{
			_canOpen = false;
		}
	}
}
