using System;
using UnityEngine;

namespace SampleGame
{
    public class TossController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;

        private TossComponent _tossController;
        private LookComponent _lookComponent;

        private void Awake()
        {
            _tossController = _character.GetComponent<TossComponent>();
            _lookComponent = _character.GetComponent<LookComponent>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.F) || Input.GetMouseButtonDown(1))
            {
                var target = _tossController.GetTarget();

                if (target != null)
                {
                    _tossController.Force(target, _lookComponent.LookDirection);
                }
            }
        }
    }
}