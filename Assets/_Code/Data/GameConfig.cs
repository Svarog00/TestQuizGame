using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Config", order = 3)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levelDatas;
    }
}