using BoomWichi.scripts.enemy;
using Godot;

namespace BoomWichi.scripts.player;

public partial class DIeHandler : AttackHandler
{
    

    protected override void AttackAction(float angle)
    {
        base.AttackAction(angle);
        
        GetParent().QueueFree();
        
    }
}