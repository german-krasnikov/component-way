using UnityEngine;

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
        private AudioClip _damageAudio;

        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _jumpComponent.AddCondition(_groundCheckerComponent.IsGrounded);
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
            _audioComponent.Play(_damageAudio);
        }

        private void OnJump() => _jumpAnimationComponent.AnimateJump();

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= OnHealthEmpty;
            _jumpComponent.OnJump -= OnJump;
            _lifeComponent.OnTakeDamage -= OnTakeDamage;
        }

        private void OnHealthEmpty() => gameObject.SetActive(false);
    }
}