using Assets._Code.Tasks;
using Data;
using Grid;
using System;
using UnityEngine;

namespace Levels
{
    public class DifficultyLevelSwapper : MonoBehaviour
    {
        public Action OnFinalLevelReached;

        [SerializeField] private LevelData[] _levelDatas;
        [SerializeField] private GridGenerator _gridGenerator;
        [SerializeField] private TaskManager _taskManager;

        private LevelData _currentLevel;
        private int _currentLevelIndex = 0;

        public LevelData CurrentLevel => _currentLevel;

        private void Start()
        {
            _taskManager.OnCorrectAnswerGiven += GetToNextLevel;

            StartGame();
        }

        public void GetToNextLevel()
        {
            if (_currentLevelIndex + 1 >= _levelDatas.Length)
            {
                OnFinalLevelReached?.Invoke();
                return;
            }

            _currentLevelIndex++;
            _currentLevel = _levelDatas[_currentLevelIndex];

            _gridGenerator.GenerateGrid(_currentLevel.Columns, _currentLevel.Rows, _currentLevel.CardBundle);
            _taskManager.GenerateNewTask();
        }

        public void StartGame()
        {
            _currentLevel = _levelDatas[0];
            _currentLevelIndex = 0;

            _gridGenerator.GenerateGrid(_currentLevel.Columns, _currentLevel.Rows, _currentLevel.CardBundle);
            _taskManager.GenerateNewTask();
        }
    }
}