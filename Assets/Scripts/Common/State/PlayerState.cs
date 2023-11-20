using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.State {
    public class PlayerState {
        [JsonProperty] private int _maxScore;
        [JsonProperty] private int _coinsCount;
        [JsonProperty] private int _viewId;
        [JsonProperty] private List<int> _boughtViews;

        [JsonConstructor]
        public PlayerState(int maxScore, int coinsCount, int viewId, List<int> boughtViews) {
            _maxScore = maxScore;
            _coinsCount = coinsCount;
            _viewId = viewId;
            _boughtViews = boughtViews;
        }

        public static PlayerState Empty => new(0, 0, -1, new List<int>());

        [JsonIgnore]
        public int MaxScore {
            get => _maxScore;
            set => _maxScore = value;
        }

        [JsonIgnore]
        public int CoinsCount {
            get => _coinsCount;
            set => _coinsCount = value;
        }

        [JsonIgnore]
        public int ViewId {
            get => _viewId;
            set => _viewId = value;
        }

        [JsonIgnore]
        public List<int> BoughtViews => _boughtViews;

        public bool IsBought(int id) {
            return BoughtViews.Contains(id);
        }
    }
}