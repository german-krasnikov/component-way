using System;
using UnityEngine;

namespace SampleGame
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField]
        private CollisionComponent _collisionComponent;
        [SerializeField]
        private TossComponent _tossComponent;
        [SerializeField]
        private Vector3 _direction = Vector3.up;

        private void OnEnable() => _collisionComponent.OnCollision += OnCollisionHandler;
        private void OnDisable() => _collisionComponent.OnCollision -= OnCollisionHandler;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, _direction);
        }

        private void OnCollisionHandler(Collider2D collider2D)
        {
            _tossComponent.Force(collider2D, _direction);
        }
    }
}