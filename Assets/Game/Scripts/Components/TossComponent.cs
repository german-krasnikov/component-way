using System;
using UnityEngine;

namespace SampleGame
{
    public class TossComponent : DetectAndForceTargetByPointComponent
    {
        [SerializeField]
        private AudioClip _tossSound;
        [SerializeField]
        private ParticleSystem _tossVfx;
        [SerializeField]
        private AudioComponent _audioComponent;
        private void OnEnable() => OnForce += ForceHandler;

        private void OnDisable() => OnForce -= ForceHandler;

        private void ForceHandler()
        {
            if (_tossSound != null)
                _audioComponent.Play(_tossSound);
            if (_tossVfx != null)
                _tossVfx.Play();
        }
    }
}