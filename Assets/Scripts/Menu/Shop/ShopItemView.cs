using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Shop {
    public class ShopItemView : MonoBehaviour {
        [SerializeField] private Image _textureImage;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private GameObject _isBoughtMark;
        [SerializeField] private GameObject _isCurrentMark;
        [SerializeField] private Button _button;


        public event Action<ShopItemView> Click;
        public int Id { get; private set; }
        private void Start() {
            _button.onClick.AddListener(() => Click?.Invoke(this));
        }

        private void OnDestroy() {
            _button.onClick.RemoveAllListeners();
        }

        public void UpdateView(ShopItemConfig itemConfig, bool isBought, bool isCurrent) {
            Id = itemConfig.Id;
            _textureImage.sprite = itemConfig.Sprite;
            _costText.text = itemConfig.Cost.ToString();
            _costText.gameObject.SetActive(!isBought && !isCurrent);
            _isBoughtMark.SetActive(isBought);
            _isCurrentMark.SetActive(isCurrent);
        }
    }
}