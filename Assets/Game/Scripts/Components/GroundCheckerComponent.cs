using UnityEngine;

namespace SampleGame
{
    public class GroundCheckerComponent : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _groundLayer;
        [SerializeField]
        private Transform _groundCheck;
        [SerializeField]
        private float _groundCheckRadius;
        private bool _isGrounded;

        public bool IsGrounded() => _isGrounded;

        private void Update() => _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
}