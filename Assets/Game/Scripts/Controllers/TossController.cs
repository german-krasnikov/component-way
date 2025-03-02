using System;
using UnityEngine;

namespace SampleGame
{
    public class TossController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;
        [SerializeField]
        private ReloadComponent _reloadComponent;

        private TossComponent _tossController;

        private void Awake() => _tossController = _character.GetComponent<TossComponent>();

        private void Update()
        {
            if ((Input.GetKey(KeyCode.E) || Input.GetMouseButtonDown(1)) && _reloadComponent.IsReady())
            {
                var target = _tossController.GetTarget();

                if (target != null)
                {
                    _tossController.Force(target, Vector3.up);
                    _reloadComponent.Reload();
                }
            }
        }
    }
}