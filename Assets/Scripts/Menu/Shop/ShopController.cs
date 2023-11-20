using System.Collections.Generic;
using Common.State;
using Game.Coins;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.Shop {
    public class ShopController : MonoBehaviour {
        [SerializeField] private GridLayoutGroup _layoutGroup;
        [SerializeField] private ShopItemView _shopItemView;
        [SerializeField] private CoinView _coinView;
        [SerializeField] private Button _button;
        
        private ShopConfig _shopConfig;
        private IPlayerStateRepository _playerStateRepository;

        private readonly List<ShopItemView> _shopItemViews = new();

        [Inject]
        private void Construct(ShopConfig shopConfig, IPlayerStateRepository playerStateRepository) {
            _playerStateRepository = playerStateRepository;
            _shopConfig = shopConfig;
        }

        public void Show() {
            foreach (var shopItemConfig in _shopConfig.ShopItemConfigs) {
                var view = Instantiate(_shopItemView, _layoutGroup.transform);
                view.Click += ViewOnClick;
                _shopItemViews.Add(view);
            }
            
            UpdateStateAll();
            _coinView.UpdateCoins(_playerStateRepository.GetState().CoinsCount);
            _button.onClick.AddListener(CloseShop);
            gameObject.SetActive(true);
        }

        private void CloseShop() {
            foreach (var shopItemView in _shopItemViews) {
                Destroy(shopItemView.gameObject);
            }
            
            _button.onClick.RemoveAllListeners();
            _shopItemViews.Clear();
            gameObject.SetActive(false);
        }

        private void UpdateStateAll() {
            var state = _playerStateRepository.GetState();
            
            foreach (var shopItemConfig in _shopConfig.ShopItemConfigs) {
                var view = _shopItemViews[shopItemConfig.Id];
                var isCurrent = state.ViewId == shopItemConfig.Id;
                var isBought = state.BoughtViews.Contains(shopItemConfig.Id);
                view.UpdateView(shopItemConfig, isBought, isCurrent);
            }
        }

        private void ViewOnClick(ShopItemView itemView) {
            var id = itemView.Id;
            var state = _playerStateRepository.GetState();
            var config = _shopConfig.ShopItemConfigs[id];

            if (state.IsBought(id)) {
                state.ViewId = id;
            }
            else {
                if (state.CoinsCount < config.Cost) {
                    return;
                }
            
                state.BoughtViews.Add(id);
                state.ViewId = id;
                _playerStateRepository.GetState().CoinsCount -= config.Cost;
            }
            
            UpdateStateAll();
            _playerStateRepository.SaveState();
            _coinView.UpdateCoins(_playerStateRepository.GetState().CoinsCount);
        }
    }
}