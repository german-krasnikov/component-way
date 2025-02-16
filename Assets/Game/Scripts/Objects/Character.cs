using System;
using UnityEngine;

namespace SampleGame
{
    //Mediator, Facade
    public class Character : MonoBehaviour, ShootComponent.ICondition
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
        private ShootComponent _rightHandShootComponent;
        [SerializeField]
        private ShootComponent _leftHandShootComponent;

        private void Awake()
        {
            //_rightHandShootComponent.AddCondition(_lifeComponent.IsAlive);
            //_leftHandShootComponent.AddCondition(_lifeComponent.IsAlive);
            //_rotateComponent.AddCondition(_lifeComponent.IsAlive);
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _jumpComponent.AddCondition(_groundCheckerComponent.IsGrounded);
        }

        private void OnEnable()
        {
            _lifeComponent.OnEmpty += this.OnHealthEmpty;
        }

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= this.OnHealthEmpty;
        }

        bool ShootComponent.ICondition.Invoke()
        {
            return _lifeComponent.IsAlive();
        }

        private void OnHealthEmpty()
        {
            this.gameObject.SetActive(false);
        }
    }
}