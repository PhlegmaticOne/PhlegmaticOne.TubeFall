using System;
using Common.Input;
using Common.State;
using Game.Coins;
using Game.Obstacles;
using Menu.Shop;
using UnityEngine;
using Zenject;

namespace Game.Player {
    public class PlayerEntity : MonoBehaviour {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MeshRenderer _meshRenderer;
        
        private PlayerConfig _playerConfig;
        public float Y => -transform.position.y;
        
        public event Action Collided;
        public event Action<Coin> CoinTake;

        [Inject]
        private void Construct(PlayerConfig playerConfig, IPlayerStateRepository repository, ShopConfig shopConfig) {
            _playerConfig = playerConfig;
            _rigidbody.angularVelocity = playerConfig.Spin;
            _meshRenderer.material = shopConfig.GetPlayerMaterial(repository.GetState().ViewId);
        }

        private void OnCollisionEnter(Collision other) {
            if (other.collider.TryGetComponent<ObstacleComponent>(out var obstacle) && obstacle.IsLostOnCollision) {
                Collided?.Invoke();
            }

            if (other.collider.TryGetComponent<Coin>(out var coin)) {
                CoinTake?.Invoke(coin);
            }
        }

        public void MoveByInput(in InputData input) {
            _rigidbody.AddForce(Vector3.right * (input.Horizontal * _playerConfig.Speed));
            _rigidbody.AddForce(Vector3.forward * (input.Vertical * _playerConfig.Speed));
            _rigidbody.velocity = CalculateVelocity();
        }
        
        private Vector3 CalculateVelocity() {
            var velocity = _rigidbody.velocity;
            var coefficient = 1 - _playerConfig.DragCoefficient;
            var initialSpeed = new Vector3(velocity.x * coefficient, 0, velocity.z * coefficient);
            var v  = Vector3.ClampMagnitude(initialSpeed, _playerConfig.MaxSpeed);
            v.y = -_playerConfig.FallSpeed;
            return v;
        }
    }
}