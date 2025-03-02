using System;
using UnityEngine;

namespace SampleGame
{
    public class CollisionComponent:MonoBehaviour
    {
        public event Action<Collider2D> OnCollision;

        private void OnCollisionEnter2D(Collision2D other) => OnCollision?.Invoke(other.collider);

        private void OnTriggerEnter2D(Collider2D other) => OnCollision?.Invoke(other);
    }
}