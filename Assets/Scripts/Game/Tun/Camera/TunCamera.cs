using Game.Base;
using Game.Player;
using Game.Tun.Models;
using UnityEngine;

namespace Game.Tun.Camera {
	public class TunCamera : IUpdatable {
		private readonly TunPipelineCollection _tunPipelineCollection;
		private readonly PlayerEntity _playerEntity;
		private readonly CameraProvider _cameraProvider;

		public TunCamera(TunPipelineCollection tunPipelineCollection, PlayerEntity playerEntity, CameraProvider cameraProvider) {
			_tunPipelineCollection = tunPipelineCollection;
			_playerEntity = playerEntity;
			_cameraProvider = cameraProvider;
		}
		
		public void OnAwake() { }

		public void OnUpdate(float deltaTime) {
			var y = _playerEntity.transform.position.y + _cameraProvider.Distance;
			var transform = _cameraProvider.CameraTransform;

			for (var k = 0; k < _tunPipelineCollection.TunsCount - 1; k++) {
				var segment = _tunPipelineCollection.Get(k);

				if (!segment.IncludesDepth(y)) {
					continue;
				}
				
				transform.position = segment.LerpDepth(y);
				var t = segment.CalculateRelativePosition(y);
				var nextSegment = _tunPipelineCollection.Get(k + 1);
				var oldQ = Quaternion.LookRotation(segment.RingsPositionDifference(), Vector3.forward);
				var desiredQ = Quaternion.LookRotation(nextSegment.RingsPositionDifference(), Vector3.forward);
				transform.rotation = Quaternion.Slerp(oldQ, desiredQ, t);
				return;
			}
		}

		public void OnDispose() {
			
		}
	}
}
