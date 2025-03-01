using System;
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

        private void OnTakeDamage() => _damageAnimationComponent.AnimateDamage();

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