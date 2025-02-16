using System;
using UnityEngine;

namespace SampleGame
{
    public class JumpComponent : MonoBehaviour
    {
        [SerializeField]
        private float _jumpForce = 5f;
        [SerializeField]
        private Rigidbody2D _rigidbody;
        private readonly AndCondition _canJump = new AndCondition();

        public void Jump()
        {
            if (_canJump.IsTrue())
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        public void AddCondition(Func<bool> condition)
        {
            _canJump.AddCondition(condition);
        }
    }
}