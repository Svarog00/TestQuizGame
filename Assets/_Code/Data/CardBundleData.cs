using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New card bundle data", menuName = "Data", order = 1)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] private List<CardData> _cards;

        public List<CardData> Cards => _cards;
    }
}