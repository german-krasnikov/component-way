using UnityEngine;

namespace SampleGame
{
    public class TakeDamageProxy : MonoBehaviour, IDamageable
    {
        [SerializeField] private LifeComponent _lifeComponent;
        
        public void TakeDamage(int damage)
        {
            _lifeComponent.TakeDamage(damage);    
        }
    }
}