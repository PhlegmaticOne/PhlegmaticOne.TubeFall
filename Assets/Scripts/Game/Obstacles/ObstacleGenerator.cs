using System.Linq;
using Game.Base;
using Game.Obstacles;
using Game.Tun.Generator;
using Game.Tun.Segment;
using UnityEngine;

namespace Game.Coins {
    public class ObstacleGenerator : IUpdatable {
        private readonly TunGenerator _tunGenerator;
        private readonly ObstaclesConfig _obstaclesConfig;

        public ObstacleGenerator(TunGenerator tunGenerator, ObstaclesConfig obstaclesConfig) {
            _tunGenerator = tunGenerator;
            _obstaclesConfig = obstaclesConfig;
            _tunGenerator.Generated += TunGeneratorOnGenerated;
        }

        private void TunGeneratorOnGenerated(TunSegment segment) {
            var rnd = Random.value;
            if (rnd > _obstaclesConfig.SpawnProbability) {
                return;
            }

            var obstacleRnd = Random.value;
            var obstacle =
                _obstaclesConfig.ObstacleConfigModels.FirstOrDefault(x => x.StartRange <= obstacleRnd && obstacleRnd <= x.FinalRange);

            if (obstacle == null) {
                return;
            }

            var transform = segment.transform;
            var position = segment.RandomInTubPoint();
            var coin = Object.Instantiate(obstacle.ObstacleComponentPrefab, transform);
            coin.transform.position = position;
        }

        public void OnAwake() { }

        public void OnUpdate(float deltaTime) { }

        public void OnDispose() {
            _tunGenerator.Generated -= TunGeneratorOnGenerated;
        }
    }
}