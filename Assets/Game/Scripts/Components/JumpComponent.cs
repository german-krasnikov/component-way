using System;
using DG.Tweening;
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
                AnimateJump();
            }
        }

        private void AnimateJump()
        {
            var returnEase = Ease.OutBounce; 
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOPunchScale(new Vector3(0, 0.15f, 0), 0.3f));
            sequence.Append(transform.DOScaleY(1, 0.1f).SetEase(returnEase));
        }

        public void AddCondition(Func<bool> condition)
        {
            _canJump.AddCondition(condition);
        }
    }
}