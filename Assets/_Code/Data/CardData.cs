using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class CardData
    {
        [SerializeField] private string _value;
        [SerializeField] private Sprite _sprite;

        public string Value => _value;
        public Sprite Sprite => _sprite;
    }
}