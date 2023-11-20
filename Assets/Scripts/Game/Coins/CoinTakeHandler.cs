using Common.State.Services;
using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Coins {
    public class CoinTakeHandler : MonoBehaviour {
        [FormerlySerializedAs("_coinVew")] [SerializeField] private CoinView _coinView;
        
        private ICoinService _coinService;
        private PlayerEntity _playerEntity;

        [Inject]
        private void Construct(PlayerEntity playerEntity, ICoinService coinService) {
            _playerEntity = playerEntity;
            _coinService = coinService;
            _playerEntity.CoinTake += PlayerEntityOnCoinTake;
        }

        private void Start() {
            UpdateCoins();
        }

        private void OnDestroy() {
            _playerEntity.CoinTake -= PlayerEntityOnCoinTake;
        }

        private void PlayerEntityOnCoinTake(Coin coinValue) {
            _coinService.ChangeCoins(coinValue.Value);
            Destroy(coinValue.gameObject);
            UpdateCoins();
        }

        private void UpdateCoins() {
            _coinView.UpdateCoins(_coinService.CoinsCount);
        }
    }
}