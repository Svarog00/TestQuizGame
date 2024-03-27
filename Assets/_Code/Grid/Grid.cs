using System;
using UnityEngine;

namespace Grid
{
    public class Grid<TGridObject> where TGridObject : MonoBehaviour
    {
        private TGridObject[,] _gridObjects;

        private Vector3 _originPosition;

        private float _cellSize;
        private int _width;
        private int _height;

        public float CellSize => _cellSize;
        public int Width => _width;
        public int Height => _height;

        public TGridObject[,] GridObjects => _gridObjects;

        public Grid(int width, int height, float cellSize, Vector3 origin,
            Func<Grid<TGridObject>, int, int, TGridObject> createObject)
        {
            _gridObjects = new TGridObject[width, height];
            _cellSize = cellSize;
            _originPosition = origin;

            _width = width;
            _height = height;

            for (int i = 0; i < _height; i++)
            {
                for(int j = 0; j < _width; j++)
                {
                    _gridObjects[j, i] = createObject(this, j, i);
                }
            }
        }

        public void SetGridObject(TGridObject gridObject, int x, int y)
        {
            if(x < _width && x >= 0 &&
               y < _height && y >= 0)
            {
                _gridObjects[x, y] = gridObject;
            }
        }

        public Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, y) * _cellSize + _originPosition;
        }

        public void GetXY(Vector3 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt((worldPosition - _originPosition).x / _cellSize);
            y = Mathf.FloorToInt((worldPosition - _originPosition).y / _cellSize);
        }

        public TGridObject GetGridObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                return _gridObjects[x, y];
            }
            else
            {
                return default;
            }
        }

        public TGridObject GetGridObject(Vector3 worldPosition)
        {
            int x, y;
            GetXY(worldPosition, out x, out y);
            return GetGridObject(x, y);
        }

        public void ClearGrid()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    UnityEngine.Object.Destroy(_gridObjects[i, j].gameObject);
                }
            }
        }
    }
}