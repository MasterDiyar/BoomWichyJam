using Godot;

[GlobalClass]
public partial class BulletResource : Resource
{
    [Export] public float Damage;
    [Export] public float Speed;
    [Export] public float Acceleration;
    [Export] public float LifeTime;
    [Export] public float Pierce=0;

    [Export] public float Randomness;
    [Export] public float BetweenAngle;
    [Export] public float StartAngle;
    [Export] public float Scaler =1;

}