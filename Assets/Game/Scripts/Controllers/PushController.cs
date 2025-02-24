using UnityEngine;

namespace SampleGame
{
    public class PushController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;

        private PushComponent _pushComponent;

        private void Awake()
        {
            _pushComponent = _character.GetComponent<PushComponent>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                var target = _pushComponent.GetTarget();

                if (target != null)
                {
                    _pushComponent.Push(target, Vector3.up);
                }
            }
        }
    }
}