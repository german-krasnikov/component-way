using UnityEngine;

namespace SampleGame
{
    public class PushComponent : DetectAndForceTargetByPointComponent
    {
        [SerializeField]
        private AudioClip _pushSound;
        [SerializeField]
        private ParticleSystem _pushVfx;
        [SerializeField]
        private AudioComponent _audioComponent;
        private void OnEnable() => OnForce += ForceHandler;

        private void OnDisable() => OnForce -= ForceHandler;

        private void ForceHandler()
        {
            if (_pushSound != null)
                _audioComponent.Play(_pushSound);
            if (_pushVfx != null)
                _pushVfx.Play();
        }
    }
}