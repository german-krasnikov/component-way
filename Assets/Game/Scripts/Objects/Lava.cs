using System;
using UnityEngine;

namespace SampleGame
{
    public class Lava : DamageMaker
    {
        [SerializeField] 
        private AudioComponent _audioComponent;
        [SerializeField] 
        private AudioClip _damageSound;
        
        private void OnEnable() => OnMakeDamage += OnMakeDamageHandler;

        private void OnDisable() => OnMakeDamage -= OnMakeDamageHandler;

        private void OnMakeDamageHandler() => _audioComponent.Play(_damageSound);
    }
}