using Godot;
using System;

public partial class Holodos : Control
{
	[Export] private Button ExitButton;
	
	public override void _Ready()
	{
		ExitButton.Pressed += () => Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
