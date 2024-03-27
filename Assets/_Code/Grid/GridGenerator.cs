using Animation;
using Assets._Code.Tasks;
using Data;
using DG.Tweening.Plugins;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace Grid
{
    public class GridGenerator : MonoBehaviour
    {
        public Action OnGridGenerated;

        [Header("Dependencies")]
        [SerializeField] private GridView _gridView;
        [SerializeField] private TaskManager _answerChecker;
        [SerializeField] private GameObject _gridElementPrefab;

        private CardBundleData _cardBundleData;

        private List<int> _previousIndexes = new List<int>();

        public void GenerateGrid(int width, int height, CardBundleData data)
        {
            _previousIndexes.Clear();
            _cardBundleData = Instantiate(data);
            var grid = new Grid<CardGridObject>(width, height, _gridView.CellSize, _gridView.OriginPosition, InstantiateCardObject);
            _gridView.SetGrid(grid);

            OnGridGenerated?.Invoke();
        }

        private CardGridObject InstantiateCardObject(Grid<CardGridObject> grid, int x, int y)
        {
            var position = grid.GetWorldPosition(x, -y) + new Vector3(grid.CellSize / 2f, -grid.CellSize / 2f);
            var obj = Instantiate(_gridElementPrefab, position, Quaternion.identity);
            var card = obj.GetComponent<CardGridObject>();
            card.OnCorrectAnswerChosen += _gridView.PlayParticles;

            var randomElement = UnityEngine.Random.Range(0, _cardBundleData.Cards.Count);

            if (_previousIndexes.Contains(randomElement) == true)
            {
                while (_previousIndexes.Contains(randomElement) == true)
                {
                    randomElement = UnityEngine.Random.Range(0, _cardBundleData.Cards.Count);
                    
                }
            }

            _previousIndexes.Add(randomElement);
            card.Initialize(_cardBundleData.Cards[randomElement], grid.CellSize, _answerChecker);

            return card;
        }
    }
}