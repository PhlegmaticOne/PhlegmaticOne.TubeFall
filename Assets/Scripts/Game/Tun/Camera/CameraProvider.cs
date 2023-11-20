using UnityEngine;

namespace Game.Tun.Camera {
    public class CameraProvider : MonoBehaviour {
        [SerializeField] private float _distance;
        [SerializeField] private UnityEngine.Camera _camera;

        public float Distance => _distance;
        public Transform CameraTransform => _camera.transform;
    }
}