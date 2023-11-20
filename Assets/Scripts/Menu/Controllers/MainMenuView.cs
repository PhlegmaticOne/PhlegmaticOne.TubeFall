using System;
using Common.Commands;
using Menu.Shop;
using Menu.ViewModels;
using UnityEngine;
using Zenject;

namespace Menu.Controllers {
    public class MainMenuView : MonoBehaviour, IInitializable, IDisposable {
        [SerializeField] private CommandButton _starGameButton;
        [SerializeField] private CommandButton _shopButton;
        [SerializeField] private ShopController _shopController;
        [SerializeField] private CommandButton _gyroButton;
        [SerializeField] private CommandButton _inputButton;
        [SerializeField] private CommandButton _addCoinsButton;

        [SerializeField] private int _addCoinsCount;
        
        private IMainMenuViewModel _mainMenuViewModel;

        [Inject]
        private void Construct(IMainMenuViewModel mainMenuViewModel) {
            _mainMenuViewModel = mainMenuViewModel;
        }

        public void Initialize() {
            _starGameButton.Setup(_mainMenuViewModel.StartGameCommand);
            _gyroButton.Setup(_mainMenuViewModel.SetGyroCommand);
            _inputButton.Setup(_mainMenuViewModel.SetInputCommand);
            _addCoinsButton.Setup(_mainMenuViewModel.AddCoinsCommand, _addCoinsCount);
            _shopButton.Setup(new RelayCommandEmpty(() => _shopController.Show()));
        }

        public void Dispose() {
            _starGameButton.OnReset();
            _inputButton.OnReset();
            _gyroButton.OnReset();
            _shopButton.OnReset();
            _addCoinsButton.OnReset();
        }
    }
}