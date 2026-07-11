using Godot;
using System;
using BoomWichi.scripts;

public partial class Enemy : CharacterBody2D, IDamagable
{

    [Export] public UnitResource Resource;
    [Export] private PackedScene Money;
    [Export] private int MoneyCount; 

    public float Hp { get; set; }
    public float MaxHp, MaxSpeed, MaxShield;

    public override void _Ready()
    {
        MaxHp = Resource.MaxHp;
        MaxSpeed = Resource.MaxSpeed;
        MaxShield = Resource.MaxShield;
        Hp = MaxHp;
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
            OnDie();
    }

    public void OnDie()
    {
        Money money = Money.Instantiate<Money>();
        money.Count = MoneyCount * GlobalController.Instance.MoneyAmplifier;
        money.Position = GlobalPosition + Vector2.FromAngle(GD.Randf() * Mathf.Tau) * 10f;
        GetTree().Root.CallDeferred("add_child", money);
        QueueFree();
    }
}
