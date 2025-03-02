using UnityEngine;

namespace SampleGame
{
    public class Spider : MonoBehaviour
    {
        [SerializeField]
        private LifeComponent _lifeComponent;
        [SerializeField]
        private DamageAnimationComponent _damageAnimationComponent;
        [SerializeField]
        private DamageMakerComponent _damageMakerComponent;
        [SerializeField]
        private PushComponent _pushComponent;
        [SerializeField]
        private LookComponent _lookComponent;

        private void OnEnable()
        {
            _damageMakerComponent.OnMakeDamage += OnMakeDamageHandler;
            _lifeComponent.OnTakeDamage += OnTakeDamageHandler;
        }

        private void OnDisable()
        {
            _damageMakerComponent.OnMakeDamage -= OnMakeDamageHandler;
            _lifeComponent.OnTakeDamage -= OnTakeDamageHandler;
        }

        private void OnTakeDamageHandler() => _damageAnimationComponent.AnimateDamage();

        private void OnMakeDamageHandler()
        {
            var target = _pushComponent.GetTarget();
            if (target == null) return;
            _pushComponent.Force(target, _lookComponent.LookDirection + Vector3.up);
        }
    }
}