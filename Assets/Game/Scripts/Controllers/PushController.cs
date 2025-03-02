using UnityEngine;

namespace SampleGame
{
    public class PushController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;
        [SerializeField]
        private ReloadComponent _reloadComponent;

        private PushComponent _pushComponent;
        private LookComponent _lookComponent;

        private void Awake()
        {
            _pushComponent = _character.GetComponent<PushComponent>();
            _lookComponent = _character.GetComponent<LookComponent>();
        }

        private void Update()
        {
            if ((Input.GetKey(KeyCode.F) || Input.GetMouseButtonDown(0)) && _reloadComponent.IsReady())
            {
                var target = _pushComponent.GetTarget();

                if (target != null)
                {
                    _pushComponent.Force(target,_lookComponent.LookDirection);
                    _reloadComponent.Reload();
                }
            }
        }
    }
}