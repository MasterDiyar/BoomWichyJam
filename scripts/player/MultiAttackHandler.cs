using Godot;
using System;

public partial class MultiAttackHandler : AttackHandler
{
    [Export] public Timer timer;
    [Export] public int ShootCount = 2;

    private int _currentShots = 0;
    private float _currentAngle = 0f;

    public override void _Ready()
    {
        base._Ready();
       
        if (timer != null)
        {
            timer.OneShot = true; 
            timer.Timeout += TimerOnTimeout;
        }
    }

    protected override void AttackAction(float angle)
    {
        if (!CanAttack) return;
       
        CanAttack = false;
        TimeAfterAttack = AttackSpeed;
       
        _currentAngle = angle;
        _currentShots = 0;
       
        PerformShoot();
    }

    private void PerformShoot()
    {
        SpawnBullets(_currentAngle);
        _currentShots++;

        if (_currentShots < ShootCount && timer != null)
            timer.Start();
    }

    private void TimerOnTimeout()
    {
        PerformShoot();
    }
}