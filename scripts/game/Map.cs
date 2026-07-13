using Godot;
using System;

public partial class Map : Node2D
{
	[Export] private Fridge holodos;
	[Export] public Timer timer;
	[Export] AudioStreamPlayer2D audio;
	GlobalController gl;
	public override void _Ready()
	{
		gl = GlobalController.Instance;
		
		gl.Mapmap = this;
		
		timer.Timeout += TimerOnTimeout;
		gl.holodos = holodos;
		TimerOnTimeout();
		
		audio.Play();
	}

	private void TimerOnTimeout()
	{
		gl.Wave++;
		gl.WaveStarted?.Invoke(gl.Wave);
	}
}
