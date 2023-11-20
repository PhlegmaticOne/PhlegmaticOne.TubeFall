using System;
using Common.Commands;
using Game.Score;
using UnityEngine;
using Zenject;

namespace Game.Views.Pause {
    public class PauseGameView : MonoBehaviour {
        [SerializeField] private CommandButton _continueButton;
        [SerializeField] private CommandButton _quitButton;
        [SerializeField] private ScoreView _scoreView;
        
        private PauseViewModel _pauseViewModel;

        public event Action Continue;

        [Inject]
        private void Construct(PauseViewModel pauseViewModel) {
            _pauseViewModel = pauseViewModel;
        }

        public void Show() {
            _continueButton.Setup(_pauseViewModel.ContinueCommand);
            _quitButton.Setup(_pauseViewModel.QuitCommand);
            _scoreView.SetScore(_pauseViewModel.BuildGameScore());
            _pauseViewModel.Pause();
            gameObject.SetActive(true);
            _pauseViewModel.OnContinue += Hide;
        }

        public void Hide() {
            _continueButton.OnReset();
            _quitButton.OnReset();
            gameObject.SetActive(false);
            _pauseViewModel.OnContinue -= Hide;
            Continue?.Invoke();
        }
    }
}