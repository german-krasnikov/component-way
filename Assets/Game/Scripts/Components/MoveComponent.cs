using System;
using UnityEngine;

namespace SampleGame
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private bool _canMove = true;

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

            _root.position += _moveDirection * _speed * Time.deltaTime;
        }

        public void AddCondition(Func<bool> condition)
        {
            _andCondition.AddCondition(condition);
        }
    }
}