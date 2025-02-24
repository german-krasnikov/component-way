using UnityEngine;

namespace SampleGame
{
    public class PatrolByGroundComponent : BasePatrolComponent
    {
        [SerializeField]
        private BoxCollider2D _ground;

        protected override Vector3[] InitPoints()
        {
            var tr = _ground.transform;
            var size = _ground.size * 0.5f;
            var offset = _ground.offset;
            var topLeftLocal = new Vector2(-size.x, size.y) + offset;
            var topRightLocal = new Vector2(size.x, size.y) + offset;
            return new[] { tr.TransformPoint(topLeftLocal), tr.TransformPoint(topRightLocal) };
        }
    }
}