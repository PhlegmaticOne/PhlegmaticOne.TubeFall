using Common.Input;
using Game.Base;
using Game.Coins;
using Game.GameOver;
using Game.Player;
using Game.Score;
using Game.Views.Pause;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game {
	public class GameController : MonoBehaviour, IUpdatable {
		[SerializeField] private PauseGameView _pauseGameView;
		[SerializeField] private GameOverView _gameOverView;
		[SerializeField] private ScoreView _scoreView;
		[FormerlySerializedAs("_coinVew")] [SerializeField] private CoinView _coinView;
		[SerializeField] private TextMeshProUGUI _inputText;

		private PlayerEntity _playerEntity;
		private PlayerSession _playerSession;
		private IInputProvider _inputProvider;

		[Inject]
		private void Construct(PlayerEntity playerEntity, PlayerSession playerSession, IInputProvider inputProvider) {
			_inputProvider = inputProvider;
			_playerSession = playerSession;
			_playerEntity = playerEntity;
			_playerEntity.Collided += PlayerEntityOnCollided;
			_pauseGameView.Continue += PauseGameViewOnContinue;
		}

		public void OnAwake() { }

		public void OnUpdate(float deltaTime) {
			var score = _playerEntity.Y;
			_playerSession.SetScore((int)score);
			
			if(Input.GetKeyDown(KeyCode.Escape)) {
				_scoreView.gameObject.SetActive(false);
				_coinView.gameObject.SetActive(false);
				_pauseGameView.Show();
			}
			
			_scoreView.SetScore(_playerSession.BuildGameScore());
			_inputText.text = _inputProvider.ReadInput().ToString();
		}

		public void OnDispose() {
			_playerEntity.Collided -= PlayerEntityOnCollided;
			_pauseGameView.Continue -= PauseGameViewOnContinue;
		}

		private void PlayerEntityOnCollided() {
			_scoreView.gameObject.SetActive(false);
			_coinView.gameObject.SetActive(false);
			_gameOverView.Show();
		}

		private void PauseGameViewOnContinue() {
			_scoreView.gameObject.SetActive(true);
		}
	}
}
