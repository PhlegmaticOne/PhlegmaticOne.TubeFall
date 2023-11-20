using Game.Base;
using Game.Player;
using Game.Tun.Models;
using UnityEngine;

namespace Game.Tun.Pipeline {
    public class TunPipeline : IUpdatable {
        private const float MinFallBehind = 15;
        
        private readonly TunPipelineCollection _tunPipelineCollection;
        private readonly PlayerEntity _playerEntity;

        public TunPipeline(TunPipelineCollection tunPipelineCollection, PlayerEntity playerEntity) {
            _tunPipelineCollection = tunPipelineCollection;
            _playerEntity = playerEntity;
        }

        public void OnAwake() { }

        public void OnUpdate(float deltaTime) {
            var playerPosition = _playerEntity.transform.position.y;
            
            for (var i = _tunPipelineCollection.TunsCount - 1; i >= 0; i--) {
                var tun = _tunPipelineCollection.Get(i);

                if (!(tun.BottomY - playerPosition >= MinFallBehind)) {
                    continue;
                }
                
                Object.Destroy(tun.gameObject);
                _tunPipelineCollection.RemoveTun(tun);
            }
        }

        public void OnDispose() {
            
        }
    }
}