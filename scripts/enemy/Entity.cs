using System;
using Godot;

namespace BoomWichi.scripts.enemy;

public partial class Entity : CharacterBody2D, IAttacker, IDamagable
{
    public Action<float> AttackAction { get; set; }
    public float Hp { get; set; }
    public virtual void TakeDamage(float damage)
    {
        
    }
}