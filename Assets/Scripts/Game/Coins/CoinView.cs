using TMPro;
using UnityEngine;

namespace Game.Coins {
    public class CoinView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _coinsText;
        
        public void UpdateCoins(int coins) {
            _coinsText.text = $"Coins:{coins}";
        }
    }
}