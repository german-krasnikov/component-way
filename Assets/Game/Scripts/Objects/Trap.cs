using UnityEngine;

namespace SampleGame
{
    public class Trap : MonoBehaviour
    {
        [SerializeField]
        private DamageMakerComponent _damageMakerComponent;

        private void OnEnable() => _damageMakerComponent.OnMakeDamage += OnMakeDamageHandler;

        private void OnDisable() => _damageMakerComponent.OnMakeDamage -= OnMakeDamageHandler;

        private void OnMakeDamageHandler() => Destroy(gameObject);
    }
}