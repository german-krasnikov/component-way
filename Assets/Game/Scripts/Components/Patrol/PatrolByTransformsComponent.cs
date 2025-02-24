using System.Linq;
using UnityEngine;

namespace SampleGame
{
    public class PatrolByTransformsComponent : BasePatrolComponent
    {
        [SerializeField]
        private Transform[] _transformPoints;

        protected override Vector3[] InitPoints() => _transformPoints.Select(t => t.position).ToArray();
    }
}