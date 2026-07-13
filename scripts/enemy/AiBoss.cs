using Godot;
using System;

public partial class AiBoss : Node2D
{
    [Export] public Enemy mob;
    [Export] public Area2D vision;
    [Export] public Node2D Body; 
    [Export] public AnimationPlayer animPlayer; 
    [Export] public AudioStreamPlayer2D audioPlayer;
    
    private Hamburg player;
    private bool canAttack = false;

    public override void _Ready()
    {
        audioPlayer.Play();
        GlobalController.Instance.Mapmap.audio.Stop();
        player = GlobalController.Instance.Player;
        
        if (vision != null)
        {
            vision.BodyEntered += VisionOnBodyEntered;
            vision.BodyExited += VisionOnBodyExited;
        }

        if (animPlayer != null)
        {
            animPlayer.Play("walk");
        }
    }

    private void VisionOnBodyEntered(Node2D body)
    {
        if (body is Hamburg || body.GetParent() is Hamburg) 
        {
            canAttack = true;
        }
    }

    private void VisionOnBodyExited(Node2D body)
    {
        if (body is Hamburg || body.GetParent() is Hamburg)
        {
            canAttack = false;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (player == null || !IsInstanceValid(player)) return;

        Vector2 directionToPlayer = mob.GlobalPosition.DirectionTo(player.GlobalPosition);
        mob.Velocity = directionToPlayer * mob.MaxSpeed;
        mob.MoveAndSlide();

        float scaleX = (player.GlobalPosition.X > mob.GlobalPosition.X) ? -1 : 1;
        
        Body.Scale = new Vector2(scaleX, Body.Scale.Y);

        if (canAttack)
        {
            var angle = (player.GlobalPosition - mob.GlobalPosition).Angle();
            mob.AttackAction?.Invoke(angle);
        }
    }

    public override void _ExitTree()
    {
        GlobalController.Instance.OnWin?.Invoke();
    }
}