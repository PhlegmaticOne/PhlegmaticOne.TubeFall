using Common.State;

namespace Game.Score {
    public class PlayerSession {
        private readonly IPlayerStateRepository _playerStateRepository;
        private int _currentScore;

        public PlayerSession(IPlayerStateRepository playerStateRepository) {
            _playerStateRepository = playerStateRepository;
        }

        public GameScore BuildGameScore() {
            return new(_currentScore, _playerStateRepository.GetState().MaxScore);
        }

        public void SetScore(int score) {
            _currentScore = score;

            if (_currentScore >= _playerStateRepository.GetState().MaxScore) {
                _playerStateRepository.GetState().MaxScore = _currentScore;
            }
        }

        public void Save() {
            _playerStateRepository.SaveState();
        }
    }
}