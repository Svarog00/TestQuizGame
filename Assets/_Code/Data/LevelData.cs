using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New level data", menuName = "LevelData", order = 2)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private CardBundleData _cardBundle;
        [SerializeField] private int _columns;
        [SerializeField] private int _rows;

        public int Columns => _columns;
        public int Rows => _rows;
        public CardBundleData CardBundle => _cardBundle;
    }
}