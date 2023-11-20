using System.Windows.Input;
using Common.Commands;
using Common.Scenes;
using Common.State;
using Shared;

namespace Menu.ViewModels {
    public class MainMenuViewModel : IMainMenuViewModel {
        private readonly ISceneProvider _sceneProvider;
        private readonly IPlayerStateRepository _playerStateRepository;

        public MainMenuViewModel(ISceneProvider sceneProvider, IPlayerStateRepository playerStateRepository) {
            _sceneProvider = sceneProvider;
            _playerStateRepository = playerStateRepository;
            StartGameCommand = new RelayCommandEmpty(LoadGameScene);
            SetGyroCommand = new RelayCommandEmpty(SetGyro);
            SetInputCommand = new RelayCommandEmpty(SetInput);
            AddCoinsCommand = new RelayCommandGeneric<int>(AddCoins);
        }

        public ICommand StartGameCommand { get; }
        public ICommand SetGyroCommand { get; }
        public ICommand SetInputCommand { get; }
        public ICommand AddCoinsCommand { get; }

        private void AddCoins(int coins) {
            _playerStateRepository.GetState().CoinsCount += coins;
            _playerStateRepository.SaveState();
        }
        
        private void LoadGameScene() => _sceneProvider.ChangeScene(SceneType.Game);
        private void SetGyro() => StaticData.IsInputByGyro = true;
        private void SetInput() => StaticData.IsInputByGyro = false;
    }
}