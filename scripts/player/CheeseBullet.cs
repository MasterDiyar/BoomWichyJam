using BoomWichi.scripts.enemy;
using Godot;

namespace BoomWichi.scripts.player;
public partial class CheeseBullet : Bullet
{
    private void OnBodyEntered(Node2D body)
    {
        if (body is IDamagable damagable)
            damagable.TakeDamage(Damage);
    }
}
