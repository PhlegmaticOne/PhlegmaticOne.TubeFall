using Game.Tun.Generator.Configs;
using UnityEngine;

namespace Game.Difficulty {
    public class Difficulty : IDifficulty {
        private readonly TunGeneratorConfig _config;

        public Difficulty(TunGeneratorConfig config) {
            _config = config;
        }
        
        public DifficultyData CalculateDifficulty(float time) {
            var difficultyT = time/ _config.SecondsToHard;
            var radius = Mathf.Lerp(_config.EasyRadius, _config.HardRadius, difficultyT);
            var turn = Mathf.Lerp(_config.EasyTurn, _config.HardTurn, difficultyT);
            return new DifficultyData(radius, turn);
        }
    }
}