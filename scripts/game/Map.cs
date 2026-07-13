using Godot;
using System;

public partial class Map : Node2D
{
	[Export] private Fridge holodos;
	[Export] public Timer timer;
	[Export] public AudioStreamPlayer2D audio;
	GlobalController gl;
	public override void _Ready()
	{
		gl = GlobalController.Instance;
		
		gl.Mapmap = this;
		
		timer.Timeout += TimerOnTimeout;
		gl.holodos = holodos;
		TimerOnTimeout();
		
		audio.Play();
		GlobalController.Instance.OnLose += audio.Stop;
		GlobalController.Instance.OnWin +=  audio.Stop;
	}

	private void TimerOnTimeout()
	{
		gl.Wave++;
		if (gl.Wave == 7) timer.Timeout -= TimerOnTimeout;
		gl.WaveStarted?.Invoke(gl.Wave);
	}
}
