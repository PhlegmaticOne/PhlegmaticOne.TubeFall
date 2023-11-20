using Common.Commands;
using Game.Score;
using UnityEngine;
using Zenject;

namespace Game.GameOver {
    public class GameOverView : MonoBehaviour {
        [SerializeField] private CommandButton _restartButton;
        [SerializeField] private CommandButton _quitButton;
        [SerializeField] private ScoreView _scoreView;
        
        private GameOverViewModel _viewModel;

        [Inject]
        private void Construct(GameOverViewModel viewModel) {
            _viewModel = viewModel;
        }

        public void Show() {
            _restartButton.Setup(_viewModel.RestartCommand);
            _quitButton.Setup(_viewModel.QuitCommand);
            _scoreView.SetScore(_viewModel.BuildGameScore());
            _viewModel.Pause();
            gameObject.SetActive(true);
        }
    }
}