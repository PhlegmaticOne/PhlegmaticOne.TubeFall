using Common.Scenes;
using Common.State;
using Common.State.Services;
using UnityEngine;
using Zenject;

namespace Common {
    public class ProjectMonoInstaller : MonoInstaller {
        public override void InstallBindings() {
            Application.targetFrameRate = 60;
            BindSceneProvider();
            BindRepository();
        }

        private void BindRepository() {
            Container.Bind<IPlayerStateRepository>().To<PlayerStateRepository>().AsSingle();
            Container.Bind<ICoinService>().To<CoinService>().AsSingle();
        }

        private void BindSceneProvider() {
            Container.Bind<ISceneProvider>().To<SceneProvider>().AsSingle();
        }
    }
}