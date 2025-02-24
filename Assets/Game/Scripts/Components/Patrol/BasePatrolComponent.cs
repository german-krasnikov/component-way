using UnityEngine;

namespace SampleGame
{
    public abstract class BasePatrolComponent : MonoBehaviour
    {
        [SerializeField]
        private float _arriveRadius;

        private Vector3[] _points;
        private int _currentIndex = 0;

        private void Awake() => _points = InitPoints();

        protected abstract Vector3[] InitPoints();

        public Vector3 GetCurrentPoint()
        {
            return _points != null ? _points[_currentIndex] : Vector3.zero;
        }

        public bool IsArrived() => _points != null && Vector3.Distance(transform.position, _points[_currentIndex]) < _arriveRadius;

        public void NextPoint() => _currentIndex = (_currentIndex + 1) % _points.Length;
    }
}