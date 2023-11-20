using Common.Commands;
using Common.Scenes;
using Game.Base;
using Game.Score;

namespace Game.GameOver {
    public class GameOverViewModel {
        private readonly ISceneProvider _sceneProvider;
        private readonly IUpdatableBehaviour _updatableBehaviour;
        private readonly PlayerSession _playerSession;


        public GameOverViewModel(ISceneProvider sceneProvider, IUpdatableBehaviour updatableBehaviour, PlayerSession playerSession) {
            _sceneProvider = sceneProvider;
            _updatableBehaviour = updatableBehaviour;
            _playerSession = playerSession;
            QuitCommand = new RelayCommandEmpty(Quit);
            RestartCommand = new RelayCommandEmpty(Restart);
        }
        
        public IRelayCommand QuitCommand { get; }
        public IRelayCommand RestartCommand { get; }
        
        public GameScore BuildGameScore() => _playerSession.BuildGameScore();

        public void Pause() => _updatableBehaviour.Stop();
        private void Restart() => _sceneProvider.ChangeScene(SceneType.Game);
        private void Quit() {
            _playerSession.Save();
            _updatableBehaviour.Dispose();
            _sceneProvider.ChangeScene(SceneType.Menu);
        }
    }
}