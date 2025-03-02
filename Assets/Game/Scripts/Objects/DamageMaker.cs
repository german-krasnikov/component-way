using System;
using UnityEngine;

namespace SampleGame
{
    public class DamageMaker : MonoBehaviour
    {
        public event Action OnMakeDamage;
        [SerializeField]
        private int _damage = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageTaker damageable) && damageable.TakeDamage(_damage))
            {
                OnMakeDamage?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageTaker damageable) && damageable.TakeDamage(_damage))
            {
                OnMakeDamage?.Invoke();
            }
        }
    }
}