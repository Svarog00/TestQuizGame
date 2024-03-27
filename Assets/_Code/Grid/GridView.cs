using UnityEngine;
using Data;
using Animation;
using System.Collections.Generic;
using Assets._Code.Particles;

namespace Grid
{
    public class GridView : MonoBehaviour
    {
        [Space]
        [Header("Grid settings")]
        [SerializeField] private Transform _originPositionMarker;

        [SerializeField] private float _cellSize;

        [Space]
        [Header("Dependencies")]
        [SerializeField] private ParticleEmitter _emitter;

        private Grid<CardGridObject> _grid;

        public float CellSize => _cellSize;
        public Vector3 OriginPosition => _originPositionMarker.position;

        public void SetGrid(Grid<CardGridObject> grid)
        {
            if (_grid != null)
            {
                _grid.ClearGrid();
            }

            _grid = grid;
        }

        public List<CardGridObject> GetGridObjects()
        {
            var newList = new List<CardGridObject>();
            for (int i = 0; i < _grid.Width; i++)
            {
                for (int j = 0; j < _grid.Height; j++)
                {
                    newList.Add(_grid.GetGridObject(i, j));
                }
            }

            return newList;
        }

        public void PlayParticles(Vector3 position)
        {
            _emitter.PlayParticles(position);
        }

        public void SetGridObjectsClickable(bool active)
        {
            for (int i = 0; i < _grid.Width; i++)
            {
                for (int j = 0; j < _grid.Height; j++)
                {
                    _grid.GetGridObject(i, j).SetActive(active);
                }
            }
        }
    }
}