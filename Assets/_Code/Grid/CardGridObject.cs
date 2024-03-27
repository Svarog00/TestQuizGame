using Data;
using UnityEngine;
using Animation;
using Assets._Code.Tasks;
using System;
using System.Collections.Generic;

namespace Grid
{
    public class CardGridObject : MonoBehaviour
    {
        public Action<Vector3> OnCorrectAnswerChosen;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private DotweenAnimator _tweenAnimator;

        private TaskManager _taskManager;

        private CardData _cardData;

        private bool _isActive = true;

        private List<string> _rotatedNumbers = new List<string>{ "7", "8" };

        private const float TargetScale = 1f;
        private const float AnimationDuration = 0.5f;
        
        private const float WiggleEndPosition = 1f;

        private const int SpriteRotationAngle = -90;


        public CardData Data => _cardData;

        private void OnMouseDown()
        {
            ProcessClick();
        }

        public void SetActive(bool active) 
            => _isActive = active;

        private void ProcessClick()
        {
            if (_isActive == false)
                return;

            if (_taskManager.CheckChosenAnswer(_cardData.Value) == false)
            {
                _tweenAnimator.Wiggle(_spriteRenderer.transform, WiggleEndPosition, AnimationDuration);
            }
            else
            {
                _tweenAnimator.BounseInOut(_spriteRenderer.transform, TargetScale, AnimationDuration, _taskManager.ReactToCorrectAnswer);
                OnCorrectAnswerChosen?.Invoke(transform.position);
            }
        }

        public void Initialize(CardData cardData, float cellSize, TaskManager answerChecker)
        {
            _taskManager = answerChecker;
            _cardData = cardData;
            _spriteRenderer.sprite = _cardData.Sprite;

            if (_rotatedNumbers.Contains(_cardData.Value) == true)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, SpriteRotationAngle));
            }

        }

        public void PlayStartAnimation()
        {
            //_tweenAnimator.BounseInOut(_spriteRenderer.transform, TargetScale, AnimationDuration);
        }

        private void OnDestroy()
        {
            OnCorrectAnswerChosen = null;
        }
    }
}