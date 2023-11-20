using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Obstacles {
    [Serializable]
    public class ObstacleConfigModel {
        [SerializeField] [Range(0, 1f)] private float _startRange;
        [SerializeField] [Range(0, 1f)] private float _finalRange;
        [FormerlySerializedAs("_obstaclePrefab")] [SerializeField] private ObstacleComponent _obstacleComponentPrefab;

        public float StartRange => _startRange;
        public float FinalRange => _finalRange;
        public ObstacleComponent ObstacleComponentPrefab => _obstacleComponentPrefab;
    }
}