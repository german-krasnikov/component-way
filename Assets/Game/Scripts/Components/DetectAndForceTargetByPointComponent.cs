using System;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public class DetectAndForceTargetByPointComponent : MonoBehaviour
    {
        public event Action OnForce;

        [SerializeField]
        private LayerMask _targetLayer;
        [SerializeField]
        private float _force = 5f;
        [SerializeField]
        private float _checkRadius = 0.3f;
        [SerializeField]
        private Transform _checkPoint;

        public Collider2D GetTarget() => Physics2D.OverlapCircle(_checkPoint.position, _checkRadius, _targetLayer);

        public void Force(Collider2D target, Vector3 direction)
        {
            if (target.TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                var moveComponent = target.GetComponent<MoveComponent>();
                moveComponent?.AddCondition(FreezeCondition);
                rigidbody2D.AddForce(direction * _force, ForceMode2D.Impulse);
                DOVirtual.DelayedCall(0.3f, () => moveComponent?.RemoveCondition(FreezeCondition));
                OnForce?.Invoke();
            }
        }

        private bool FreezeCondition() => false;
    }
}