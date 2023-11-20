using UnityEngine;

namespace Game.Obstacles {
    public class ObstacleComponent : MonoBehaviour {
        [SerializeField] private bool _isLostOnCollision = true;

        public bool IsLostOnCollision => _isLostOnCollision;
    }
}