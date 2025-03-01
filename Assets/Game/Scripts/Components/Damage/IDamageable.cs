using System;

namespace SampleGame
{
    public interface IDamageable
    {
        event Action OnTakeDamage;
        void TakeDamage(int damage);
    }
}