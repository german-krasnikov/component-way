using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    public class LifeComponent : MonoBehaviour, IDamageable
    {
        public event Action OnTakeDamage;
        public event Action OnEmpty;

        [SerializeField]
        private int _maxPoints;
        [SerializeField]
        private int _hitPoints;
        [SerializeField]
        private bool _isDead;

        [Button]
        public void TakeDamage(int damage)
        {
            if (_isDead)
            {
                return;
            }

            _hitPoints -= damage;
            OnTakeDamage?.Invoke();
            if (_hitPoints <= 0)
            {
                _isDead = true;
                OnEmpty?.Invoke();
            }
        }

        public bool IsAlive()
        {
            return !_isDead;
        }
    }
}