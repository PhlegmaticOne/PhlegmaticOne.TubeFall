using System.Collections.Generic;
using UnityEngine;

namespace Menu.Shop {
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Game/Shop config")]
    public class ShopConfig : ScriptableObject {
        [SerializeField] private List<ShopItemConfig> _shopItemConfigs;
        [SerializeField] private Material _defaultPlayerMaterial;

        public IReadOnlyList<ShopItemConfig> ShopItemConfigs => _shopItemConfigs;

        public Material GetPlayerMaterial(int id) {
            return id == -1 ? _defaultPlayerMaterial : _shopItemConfigs[id].PlayerMaterial;
        }
    }
}