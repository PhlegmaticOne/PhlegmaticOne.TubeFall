using Common.Input;
using Game.Base;
using Game.Coins;
using Game.Difficulty;
using Game.GameOver;
using Game.Player;
using Game.Score;
using Game.Tun.Camera;
using Game.Tun.Generator;
using Game.Tun.Generator.Factory;
using Game.Tun.Models;
using Game.Tun.Pipeline;
using Game.Views.Pause;
using Shared;
using UnityEngine;
using Zenject;

namespace Game.Installers {
    public class GameSceneInstaller : MonoInstaller {
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private UpdatableBehavior _updatableBehavior;
        [SerializeField] private TunFactory _tunFactory;
        [SerializeField] private CameraProvider _cameraProvider;
        [SerializeField] private GameController _gameController;
        
        public override void InstallBindings() {
            BindTunCollection();
            BindInput();
            BindPlayer();
            BindTunFactory();
            BindSystems();
            BindUpdatableBehavior();
            BindDifficulty();
            BindCameraProvider();
            BindViewModels();
        }

        private void BindUpdatableBehavior() {
            Container.BindInterfacesTo<UpdatableBehavior>().FromInstance(_updatableBehavior).AsSingle();
        }

        private void BindSystems() {
            Container.BindInterfacesAndSelfTo<TunGenerator>().AsSingle();
            Container.Bind<IUpdatable>().To<PlayerMovementSystem>().AsSingle();
            Container.Bind<IUpdatable>().To<TunPipeline>().AsSingle();
            Container.Bind<IUpdatable>().To<TunCamera>().AsSingle();
            Container.Bind<IUpdatable>().To<ObstacleGenerator>().AsSingle();
            Container.Bind<IUpdatable>().To<GameController>().FromInstance(_gameController).AsSingle();
        }

        private void BindInput() {
            if (Application.platform == RuntimePlatform.Android) {
                if (StaticData.IsInputByGyro) {
                    Container.Bind<IInputProvider>().To<InputProviderAcceleration>().AsSingle();
                }
                else {
                    Container.Bind<IInputProvider>().To<InputProviderTouch>().AsSingle();
                }
            }
            else {
                Container.Bind<IInputProvider>().To<InputProviderKeys>().AsSingle();
            }
        }

        private void BindViewModels() {
            Container.Bind<PauseViewModel>().AsSingle();
            Container.Bind<GameOverViewModel>().AsSingle();
            Container.Bind<PlayerSession>().AsSingle();
        }

        private void BindCameraProvider() {
            Container.Bind<CameraProvider>().FromInstance(_cameraProvider).AsSingle();
        }

        private void BindDifficulty() {
            Container.Bind<IDifficulty>().To<Difficulty.Difficulty>().AsSingle();
        }

        private void BindTunFactory() {
            Container.Bind<ITunFactory>().To<TunFactory>().FromInstance(_tunFactory).AsSingle();
        }

        private void BindPlayer() {
            Container.Bind<PlayerEntity>().FromInstance(_playerEntity).AsSingle();
        }

        private void BindTunCollection() {
            Container.Bind<TunPipelineCollection>().AsSingle();
        }
    }
}