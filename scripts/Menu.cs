using Godot;
using System;

public partial class Menu : Control
{
	[Export] public Button play;
	[Export] public AudioStreamPlayer2D audio;
	[Export] AudioStream before, after;
	[Export] AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		play.Pressed += PlayOnPressed;
		audio.Stream = before;
		audio.Play();
		audio.Finished += (() => 
		{
			audio.Stream = after;
			audio.Play();
		});
		animationPlayer.Play("dsa");
		animationPlayer.AnimationFinished += name => animationPlayer.Play((GD.Randf()>.5f)?"dsa" : "dsr");
	}

	private void PlayOnPressed()
	{
		var map = GD.Load<PackedScene>("res://scenes/map.tscn").Instantiate();
		GetParent().AddChild(map);
		QueueFree();
	}
}
