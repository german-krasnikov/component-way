using UnityEngine;

namespace SampleGame
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField]
        private CollisionComponent _collisionComponent;
        [SerializeField]
        private TossComponent _tossComponent;

        private void OnEnable() => _collisionComponent.OnCollision += OnCollisionHandler;
        private void OnDisable() => _collisionComponent.OnCollision -= OnCollisionHandler;

        private void OnCollisionHandler(Collider2D collider2D) => _tossComponent.Force(collider2D, Vector3.up);
    }
}