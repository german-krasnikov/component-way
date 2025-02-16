using System;
using UnityEngine;

namespace SampleGame
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;
        
        private MoveComponent _moveComponent;
        private LookComponent _lookComponent;

        private void Awake()
        {
            _moveComponent = _character.GetComponent<MoveComponent>();
            _lookComponent = _character.GetComponent<LookComponent>();
        }

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            Move(Vector3.zero);

            if (Input.GetKey(KeyCode.A))
            {
                Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Move(Vector3.right);
            }
        }

        private void Move(Vector3 direction)
        {
            _moveComponent.SetDirection(direction);
            _lookComponent.SetDirection(direction);
        }
    }
}