using UnityEngine;

namespace SampleGame
{
    public class PushComponent : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _targetLayer;
        [SerializeField]
        private float _pushForce = 5f;
        [SerializeField]
        private float _pushCheckRadius = 0.3f;
        [SerializeField]
        private Transform _pushPoint;

        public Collider2D GetTarget() => Physics2D.OverlapCircle(_pushPoint.position, _pushCheckRadius, _targetLayer);

        public void Push(Collider2D target, Vector3 direction)
        {
            if (target.TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                rigidbody2D.AddForce(direction * _pushForce, ForceMode2D.Impulse);
            }
        }
    }
}