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

        private readonly AndCondition _andCondition = new();

        private void Update()
        {
            this.Move();
        }

        public void SetDirection(Vector3 direction)
        {
            _moveDirection = direction;
        }

        private void Move()
        {
            if (!_canMove || !_andCondition.IsTrue())
                return;

            _rigidbody.velocity = new Vector2(_moveDirection.x * _speed, _rigidbody.velocity.y);
        }

        public void AddCondition(Func<bool> condition)
        {
            _andCondition.AddCondition(condition);
        }
    }
}