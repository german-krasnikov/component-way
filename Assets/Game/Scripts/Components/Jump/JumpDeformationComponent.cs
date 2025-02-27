using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public class JumpDeformationComponent : MonoBehaviour
    {
        public void AnimateJump()
        {
            var returnEase = Ease.OutBounce;
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOPunchScale(new Vector3(0, 0.15f, 0), 0.3f));
            sequence.Append(transform.DOScaleY(1, 0.1f).SetEase(returnEase));
        }
    }
}