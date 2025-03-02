using UnityEngine;
using UnityEngine.Serialization;

namespace SampleGame
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private LifeComponent _lifeComponent;
        [SerializeField]
        private LookComponent _lookComponent;
        [SerializeField]
        private MoveComponent _moveComponent;
        [SerializeField]
        private GroundCheckerComponent _groundCheckerComponent;
        [SerializeField]
        private JumpComponent _jumpComponent;
        [SerializeField]
        private JumpAnimationComponent _jumpAnimationComponent;
        [SerializeField]
        private DamageAnimationComponent _damageAnimationComponent;
        [SerializeField]
        private AudioComponent _audioComponent;
        [SerializeField]
        private AudioClip _damageSound;
        [SerializeField]
        private ReloadComponent _jumpReloadComponent;
        [SerializeField]
        private AudioClip _jumpSound;

        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _jumpComponent.AddCondition(_groundCheckerComponent.IsGrounded);
            _jumpComponent.AddCondition(_lifeComponent.IsAlive);
            _jumpComponent.AddCondition(_jumpReloadComponent.IsReady);
        }

        private void OnEnable()
        {
            _lifeComponent.OnEmpty += OnHealthEmpty;
            _lifeComponent.OnTakeDamage += OnTakeDamage;
            _jumpComponent.OnJump += OnJump;
        }

        private void OnTakeDamage()
        {
            _damageAnimationComponent.AnimateDamage();
            _audioComponent.Play(_damageSound);
        }

        private void OnJump()
        {
            _jumpAnimationComponent.AnimateJump();
            _jumpReloadComponent.Reload();
            _audioComponent.Play(_jumpSound);
        }

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= OnHealthEmpty;
            _jumpComponent.OnJump -= OnJump;
            _lifeComponent.OnTakeDamage -= OnTakeDamage;
        }

        private void OnHealthEmpty() => gameObject.SetActive(false);
    }
}