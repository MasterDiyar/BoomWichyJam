namespace BoomWichi.scripts;

public interface IDamagable
{
    float Hp { get; set; }
    
    void TakeDamage(float damage);
}