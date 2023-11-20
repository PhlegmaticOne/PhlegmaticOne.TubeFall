using UnityEngine.SceneManagement;

namespace Common.Scenes {
    public class SceneProvider : ISceneProvider {
        public void ChangeScene(SceneType sceneType) {
            SceneManager.LoadScene((int)sceneType);
        }
    }
}