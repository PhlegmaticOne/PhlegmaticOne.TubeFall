using Common.Input;
using Game.Base;
using UnityEngine;

namespace Game.Player {
	public class PlayerMovementSystem : IUpdatable {
		private readonly IInputProvider _inputProvider;
		private readonly PlayerEntity _playerEntity;

		public PlayerMovementSystem(IInputProvider inputProvider, PlayerEntity playerEntity) {
			_playerEntity = playerEntity;
			_inputProvider = inputProvider;
		}

		public void OnAwake() { }

		public void OnUpdate(float deltaTime) {
			var input = _inputProvider.ReadInput();
			_playerEntity.MoveByInput(input);
		}

		public void OnDispose() {
			
		}
	}
}

