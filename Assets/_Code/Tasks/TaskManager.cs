using Grid;
using Levels;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Code.Tasks
{
    public class TaskManager : MonoBehaviour
    {
        public Action<string> NewTaskGenerated;
        public Action OnCorrectAnswerGiven;

        [SerializeField] private GridView _gridView;

        private List<string> _previousAnswers = new List<string>();

        private string _correctAnswer;

        public void GenerateNewTask()
        {
            var objects = _gridView.GetGridObjects();

            int randomIndex = UnityEngine.Random.Range(0, objects.Count);

            _correctAnswer = objects[randomIndex].Data.Value;
            while (_previousAnswers.Contains(_correctAnswer) == true)
            {
                randomIndex = UnityEngine.Random.Range(0, objects.Count);
                _correctAnswer = objects[randomIndex].Data.Value;
            }
            
            _previousAnswers.Add(_correctAnswer);

            NewTaskGenerated?.Invoke(_correctAnswer);
        }

        public bool CheckChosenAnswer(string answer) 
            => _correctAnswer.Equals(answer);

        public void ReactToCorrectAnswer() 
            => OnCorrectAnswerGiven?.Invoke();
    }
}