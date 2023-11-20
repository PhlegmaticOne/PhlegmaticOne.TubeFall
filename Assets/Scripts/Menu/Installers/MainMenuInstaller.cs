using Menu.Controllers;
using Menu.ViewModels;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Menu.Installers {
    public class MainMenuInstaller : MonoInstaller {
        [FormerlySerializedAs("_mainMenuController")] [SerializeField] private MainMenuView _mainMenuView;
        
        public override void InstallBindings() {
            BindController();
            BindViewModel();
        }

        private void BindController() {
            Container.BindInterfacesTo<MainMenuView>().FromInstance(_mainMenuView).AsSingle();
        }

        private void BindViewModel() {
            Container.Bind<IMainMenuViewModel>().To<MainMenuViewModel>().AsSingle();
        }
    }
}