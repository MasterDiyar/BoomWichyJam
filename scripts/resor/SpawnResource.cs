
using Godot;

[GlobalClass]
public partial class SpawnResource : Resource
{
    [Export] public PackedScene Unit;
    [Export] public int Count = 1;
    [Export] public float SpawnOffset = 1;
}