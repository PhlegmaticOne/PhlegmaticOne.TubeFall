using System.Collections.Generic;
using UnityEngine;

namespace Game.Obstacles {
    [CreateAssetMenu(fileName = "ObstacleConfig", menuName = "Game/Obstacles config")]
    public class ObstaclesConfig : ScriptableObject {
        [SerializeField] private List<ObstacleConfigModel> _obstacleConfigModels;
        [SerializeField] private float _spawnProbability;

        public IReadOnlyList<ObstacleConfigModel> ObstacleConfigModels => _obstacleConfigModels;
        public float SpawnProbability => _spawnProbability;
    }
}