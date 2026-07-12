using Godot;
using System;
using BoomWichi.scripts.enemy;

public partial class SecondTexture : Sprite2D
{
	private Entity parent;
	public override void _Ready()
	{
		parent = GetParent<Entity>();
		int i = GD.RandRange(0, 3), j = GD.RandRange(0, 3);
		RegionRect = new Rect2(new Vector2(i* 32, j* 32), new Vector2(32, 32));
	}

	public override void _Process(double delta)
	{
		Rotate((float)delta * parent.Velocity.Length() / 100);
	}
}
