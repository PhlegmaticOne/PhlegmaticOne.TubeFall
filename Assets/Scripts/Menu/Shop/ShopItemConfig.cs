using System;
using UnityEngine;

namespace Menu.Shop {
    [Serializable]
    public class ShopItemConfig {
        [SerializeField] private int _id;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _cost;
        [SerializeField] private Material _playerMaterial;

        public int Id => _id;
        public Sprite Sprite => _sprite;
        public int Cost => _cost;
        public Material PlayerMaterial => _playerMaterial;
    }
}