using System;

namespace SampleGame
{
    public interface IDamageTaker
    {
        event Action OnTakeDamage;
        bool TakeDamage(int damage);
    }
}