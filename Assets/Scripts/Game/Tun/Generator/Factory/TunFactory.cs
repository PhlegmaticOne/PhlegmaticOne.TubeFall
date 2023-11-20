using Game.Tun.Generator.Configs;
using Game.Tun.Models;
using Game.Tun.Segment;
using UnityEngine;
using Zenject;

namespace Game.Tun.Generator.Factory {
    public class TunFactory : MonoBehaviour, ITunFactory {
        private const int SidesCount = 6;
        private TunGeneratorConfig _config;

        [Inject]
        private void Construct(TunGeneratorConfig config) {
            _config = config;
        }
        
        public TunSegment CreateTun(Ring top, Ring bottom) {
            var segment = Instantiate(_config.TunSegment, transform);
            segment.SetupSegment(new TunSegmentData(top, bottom, SidesCount, _config.Material));
            segment.gameObject.layer = gameObject.layer;
            return segment;
        }
    }
}