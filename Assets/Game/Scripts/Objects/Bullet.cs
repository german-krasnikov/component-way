using UnityEngine;

namespace SampleGame
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 2;
        
        private void OnTriggerEnter(Collider other)
        {
            //Работа через прокси
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }
        }
    }
}