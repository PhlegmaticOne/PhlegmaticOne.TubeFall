using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Obstacles.Concrete {
    public class SphereObstacle : MonoBehaviour {
        [SerializeField] private float _minScale;
        [SerializeField] private float _maxScale;

        private void Start() {
            var rndScale = Random.Range(_minScale, _maxScale);
            transform.localScale = Vector3.one * rndScale;
        }
    }
}