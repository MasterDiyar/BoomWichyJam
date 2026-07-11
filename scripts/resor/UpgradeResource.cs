using Godot;

[GlobalClass]
public partial class UpgradeResource : Resource
{
    [Export] public Texture2D texture;
    [Export] public string Name;
    [Export] public int Count;
    [Export] public string Description;
}