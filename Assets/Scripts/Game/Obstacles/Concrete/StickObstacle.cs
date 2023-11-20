using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Obstacles.Concrete {
    public class StickObstacle : MonoBehaviour {
        [SerializeField] private float _rotatableProbability;
        [SerializeField] private float _minRotateSpeed;
        [SerializeField] private float _maxRotateSpeed;
        
        private bool _isRotatable;
        private float _rotateSpeed;
        
        private void Start() {
            var rnd = Random.Range(0, 360);
            transform.eulerAngles += new Vector3(0, rnd, 0); 
            _isRotatable = Random.value <= _rotatableProbability;
            _rotateSpeed = Random.Range(_minRotateSpeed, _maxRotateSpeed);
        }
        
        private void Update() {
            if (!_isRotatable) {
                return;
            }

            transform.eulerAngles += new Vector3(0, _rotateSpeed * Time.deltaTime, 0);
        }
    }
}