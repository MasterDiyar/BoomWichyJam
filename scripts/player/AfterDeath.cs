using Godot;

namespace BoomWichi.scripts.player;

public partial class AfterDeath : Node
{
    
    public override void _ExitTree()
    {
        After_Death();
    }

    public virtual void After_Death()
    {
        GD.Print("After death");    
    }
}