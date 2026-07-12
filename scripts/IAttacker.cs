using System;

namespace BoomWichi;

public interface IAttacker
{
    public Action<float> AttackAction { get; set; }
}