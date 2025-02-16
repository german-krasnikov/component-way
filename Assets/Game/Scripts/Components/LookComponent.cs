using UnityEngine;

namespace SampleGame
{
    public class LookComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _lookRoot;
        private bool _facingRight = true;
        private Vector3 _lookDirection;

        public void SetDirection(Vector3 direction) => _lookDirection = direction;

        private void Update()
        {
            if (_lookDirection.x > 0 && !_facingRight)
            {
                Flip();
            }
            else if (_lookDirection.x < 0 && _facingRight)
            {
                Flip();
            }
        }

        private void Flip()
        {
            _facingRight = _lookDirection.x > 0;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}