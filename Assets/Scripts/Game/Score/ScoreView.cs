using TMPro;
using UnityEngine;

namespace Game.Score {
    public class ScoreView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private TextMeshProUGUI _maxScore;

        public void SetScore(GameScore gameScore) {
            _currentScore.text = $"Current:{gameScore.CurrentScore}";
            _maxScore.text = $"Max:{gameScore.MaxScore}";
        }
    }
}