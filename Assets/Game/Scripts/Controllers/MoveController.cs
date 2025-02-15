using System;
using UnityEngine;

namespace SampleGame
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;


        private MoveComponent _moveComponent;
        private RotateComponent _rotateComponent;

        private void Awake()
        {
            _moveComponent = _character.GetComponent<MoveComponent>();
            _rotateComponent = _character.GetComponent<RotateComponent>();
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
            _rotateComponent.SetDirection(direction);
        }
    }
}