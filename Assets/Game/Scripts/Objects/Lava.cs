using System;
using UnityEngine;

namespace SampleGame
{
    public class Lava : MonoBehaviour
    {
        [SerializeField]
        private DamageMakerComponent _damageMakerComponent;
        [SerializeField] 
        private AudioComponent _audioComponent;
        [SerializeField] 
        private AudioClip _damageSound;
        
        private void OnEnable() => _damageMakerComponent.OnMakeDamage += OnMakeDamageHandler;

        private void OnDisable() => _damageMakerComponent.OnMakeDamage -= OnMakeDamageHandler;

        private void OnMakeDamageHandler() => _audioComponent.Play(_damageSound);
    }
}