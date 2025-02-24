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

        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _jumpComponent.AddCondition(_groundCheckerComponent.IsGrounded);
        }

        private void OnEnable()
        {
            _lifeComponent.OnEmpty += OnHealthEmpty;
        }

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= OnHealthEmpty;
        }

        private void OnHealthEmpty()
        {
            gameObject.SetActive(false);
        }
    }
}