using System;
using UnityEngine;

namespace SampleGame
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 3f;
        [SerializeField]
        private Vector3 _moveDirection;
        [SerializeField]
        private bool _canMove = true;
        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private bool _useRigidbody = true;

        private readonly AndCondition _andCondition = new();
        public Vector3 MoveDirection => _moveDirection;

        private void Update() => this.Move();

        public void SetDirection(Vector3 direction)
        {
            _moveDirection = direction;
        }

        private void Move()
        {
            if (!_canMove || !_andCondition.IsTrue())
                return;

            if (_useRigidbody)
            {
                _rigidbody.velocity = new Vector2(_moveDirection.x * _speed, _rigidbody.velocity.y);
            }
            else
            {
                transform.position += _moveDirection * _speed * Time.deltaTime;
            }
        }

        public void AddCondition(Func<bool> condition) => _andCondition.AddCondition(condition);

        public void RemoveCondition(Func<bool> condition) => _andCondition.RemoveCondition(condition);
    }
}