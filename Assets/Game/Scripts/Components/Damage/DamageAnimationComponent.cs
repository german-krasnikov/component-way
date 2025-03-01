using System;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public class DamageAnimationComponent : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Color _damageColor;
        private Color _originalColor;

        private void Awake() => _originalColor = _spriteRenderer.color;

        public void AnimateDamage()
        {
            _spriteRenderer.DOBlendableColor(_damageColor, 1f).OnComplete(() => _spriteRenderer.DOBlendableColor(_originalColor, 1f));
        }
    }
}