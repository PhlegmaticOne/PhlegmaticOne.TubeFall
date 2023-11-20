using UnityEngine;

namespace Game.Coins {
    [CreateAssetMenu(fileName = "CoinsConfig", menuName = "Game/Coin config")]
    public class CoinsConfig : ScriptableObject {
        [SerializeField] private int _coinValue;
        public int CoinValue => _coinValue;
    }
}