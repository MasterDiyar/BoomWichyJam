using Godot;
using System;

public partial class Test : CanvasLayer
{
	[Export] private Hamburg Parent; 
	[Export] Button buttonAdd;
	[Export] PackedScene scene;
	public override void _Ready()
	{
		buttonAdd.Pressed += ButtonAddOnPressed;
	}

	private void ButtonAddOnPressed()
	{
		Parent.AddIngridient(scene);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("e")) Visible = !Visible;
	}
}
