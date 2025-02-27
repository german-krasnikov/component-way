using System;
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
        private JumpDeformationComponent _jumpDeformationComponent;

        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _jumpComponent.AddCondition(_groundCheckerComponent.IsGrounded);
        }

        private void OnEnable()
        {
            _lifeComponent.OnEmpty += OnHealthEmpty;
            _jumpComponent.OnJump += OnJump;
        }

        private void OnJump() => _jumpDeformationComponent.AnimateJump();

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= OnHealthEmpty;
            _jumpComponent.OnJump -= OnJump;
        }

        private void OnHealthEmpty() => gameObject.SetActive(false);
    }
}