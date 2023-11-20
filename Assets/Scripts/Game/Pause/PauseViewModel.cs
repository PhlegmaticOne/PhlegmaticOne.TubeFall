using System;
using Common.Commands;
using Common.Scenes;
using Game.Base;
using Game.Score;
using UnityEngine;

namespace Game.Views.Pause {
    public class PauseViewModel {
        private readonly ISceneProvider _sceneProvider;
        private readonly IUpdatableBehaviour _updatableBehaviour;
        private readonly PlayerSession _playerSession;

        public event Action OnContinue;

        public PauseViewModel(ISceneProvider sceneProvider, IUpdatableBehaviour updatableBehaviour, PlayerSession playerSession) {
            _sceneProvider = sceneProvider;
            _updatableBehaviour = updatableBehaviour;
            _playerSession = playerSession;
            QuitCommand = new RelayCommandEmpty(Quit);
            ContinueCommand = new RelayCommandEmpty(Continue);
        }
        
        public IRelayCommand QuitCommand { get; }
        public IRelayCommand ContinueCommand { get; }
        public GameScore BuildGameScore() => _playerSession.BuildGameScore();
        
        public void Pause() {
            Time.timeScale = 0;
            _updatableBehaviour.Stop();
        }

        private void Continue() {
            Time.timeScale = 1;
            _updatableBehaviour.Continue();
            OnContinue?.Invoke();
        }

        private void Quit() {
            Time.timeScale = 1;
            _playerSession.Save();
            _updatableBehaviour.Dispose();
            _sceneProvider.ChangeScene(SceneType.Menu);
        }
    }
}