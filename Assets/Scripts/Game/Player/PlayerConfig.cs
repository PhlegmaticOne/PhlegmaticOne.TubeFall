using UnityEngine;

namespace Game.Player {
    [CreateAssetMenu(fileName = "PlayerMenu", menuName = "Game/Player config")]
    public class PlayerConfig : ScriptableObject {
        [SerializeField] private Vector3 _spin;
        [SerializeField] private float _speed = 5;
        [SerializeField] private float _maxSpeed = 15;
        [SerializeField] private float _fallSpeed = 50;
        [SerializeField] private float _dragCoefficient = .25f;

        public Vector3 Spin => _spin;
        public float Speed => _speed;
        public float MaxSpeed => _maxSpeed;
        public float FallSpeed => _fallSpeed;
        public float DragCoefficient => _dragCoefficient;
    }
}