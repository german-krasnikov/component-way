using System.Linq;
using UnityEngine;

namespace SampleGame
{
    public class PatrolController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;

        private MoveComponent _moveComponent;
        private BasePatrolComponent _patrolComponent;
        private Vector3 _direction;

        private void Awake()
        {
            _moveComponent = _character.GetComponent<MoveComponent>();
            _patrolComponent = _character.GetComponent<BasePatrolComponent>();
        }
        
        private void Start() => InvalidateMoveDirection();

        private void InvalidateMoveDirection()
        {
            _direction = _patrolComponent.GetCurrentPoint() - transform.position;
            _moveComponent.SetDirection(_direction);
        }

        private void Update()
        {
            if (_patrolComponent.IsArrived())
            {
                _patrolComponent.NextPoint();
                InvalidateMoveDirection();
            }
        }
    }
}