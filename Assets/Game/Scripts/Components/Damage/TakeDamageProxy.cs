using System;
using UnityEngine;

namespace SampleGame
{
    public class TakeDamageProxy : MonoBehaviour, IDamageTaker
    {
        public event Action OnTakeDamage;
        
        [SerializeField]
        private LifeComponent _lifeComponent;

        public void OnEnable() => _lifeComponent.OnTakeDamage += OnTakeDamageHandler;

        public void OnDisable() => _lifeComponent.OnTakeDamage -= OnTakeDamageHandler;

        public bool TakeDamage(int damage) => _lifeComponent.TakeDamage(damage);

        private void OnTakeDamageHandler() => OnTakeDamage?.Invoke();
    }
}