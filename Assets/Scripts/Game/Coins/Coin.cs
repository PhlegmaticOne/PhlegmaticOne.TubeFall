using UnityEngine;

namespace Game.Coins {
    public class Coin : MonoBehaviour {
        [SerializeField] private CoinsConfig _coinsConfig;

        private void Start() => Value = _coinsConfig.CoinValue;

        public int Value { get; private set; }
    }
}