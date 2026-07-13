using BoomWichi.scripts.enemy;
using Godot;

namespace BoomWichi.scripts.player;
public partial class CheeseBullet : Bullet
{
    protected override void OnBodyEntered(Node2D body)
    {
        if (body is not IDamagable damagable) return;
        damagable.TakeDamage(Damage);
        QueueFree();
    }
}
