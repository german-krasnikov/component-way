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
            //_pushComponent.Force();
        }
    }
}