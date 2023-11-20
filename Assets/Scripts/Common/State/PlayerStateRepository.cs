using Newtonsoft.Json;
using UnityEngine;

namespace Common.State {
    public class PlayerStateRepository : IPlayerStateRepository {
        private const string Key = "PlayerState";

        private PlayerState _state;
        
        public PlayerState GetState() {
            if (_state != null) {
                return _state;
            }
            
            var json = PlayerPrefs.GetString(Key, string.Empty);
            _state = string.IsNullOrEmpty(json) ? PlayerState.Empty : JsonConvert.DeserializeObject<PlayerState>(json);
            return _state;
        }

        public void SaveState() {
            var json = JsonConvert.SerializeObject(_state);
            PlayerPrefs.SetString(Key, json);
        }
    }
}