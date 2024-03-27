using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Animation
{
    public class DotweenAnimator : MonoBehaviour
    {
        private Sequence _bounceSequence;
        private Tween _activeTween;
        private Transform _prevTarget;

        private Vector3 _startScale;
        private Vector3 _startPosition;

        private void Start()
        {
            
        }

        public void BounseInOut(Transform target, float targetScale, float duration, Action callback = null)
        {
            ResetTween();

            SetTarget(target);
            GenerateSequence(target, targetScale, duration, callback);
        }

        public void Wiggle(Transform target, float endPosition, float duration)
        {
            ResetTween();

            SetTarget(target);
            _activeTween = target.DOLocalMoveX(endPosition, duration)
                .SetEase(Ease.InBounce).SetLoops(2, LoopType.Yoyo);
        }

        private void SetTarget(Transform target)
        {
            _prevTarget = target;
            _startPosition = _prevTarget.position;
            _startScale = _prevTarget.localScale;
        }

        private void ResetTween()
        {
            if (_activeTween != null & _prevTarget != null)
            {
                _prevTarget.localScale = _startScale;
                _prevTarget.position = _startPosition;
                _activeTween.Kill();
            }
        }

        private void GenerateSequence(Transform target, float targetScale, float duration, Action callback = null)
        {
            _bounceSequence = DOTween.Sequence();
            _bounceSequence.Append(target.DOScale(targetScale, duration))
                .Append(target.DOScale(_startScale/2, duration))
                .Append(target.DOScale(target.localScale, duration))
                .OnComplete(() => callback?.Invoke());
        }
    }

}
