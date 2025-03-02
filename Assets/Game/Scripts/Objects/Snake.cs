using UnityEngine;

namespace SampleGame
{
    public class Snake : MonoBehaviour
    {
        [SerializeField]
        private LifeComponent _lifeComponent;
        [SerializeField]
        private DamageAnimationComponent _damageAnimationComponent;
        [SerializeField]
        private TossComponent _tossComponent;
        [SerializeField]
        private DamageMakerComponent _damageMakerComponent;

        private void OnEnable()
        {
            _lifeComponent.OnTakeDamage += OnTakeDamageHandler;
            _damageMakerComponent.OnMakeDamage += OnMakeDamageHandler;
        }

        private void OnDisable()
        {
            _lifeComponent.OnTakeDamage -= OnTakeDamageHandler;
            _damageMakerComponent.OnMakeDamage -= OnMakeDamageHandler;
        }

        private void OnTakeDamageHandler() => _damageAnimationComponent.AnimateDamage();
        
        private void OnMakeDamageHandler()
        {
            var target = _tossComponent.GetTarget();
            if (target == null) return;
            _tossComponent.Force(target,  Vector3.up);
        }
    }
}