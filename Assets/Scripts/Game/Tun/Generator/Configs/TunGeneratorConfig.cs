using Game.Tun.Segment;
using UnityEngine;

namespace Game.Tun.Generator.Configs {
    [CreateAssetMenu(fileName = "TubGeneratorConfig", menuName = "Game/Tub generator config")]
    public class TunGeneratorConfig : ScriptableObject {
        [SerializeField] private TunSegment _tunSegment;
        [SerializeField] private int _segmentsCount;
        [SerializeField] private float _curveLength;
        [SerializeField] private float _curveStepSize;
        [SerializeField] private float _firstSegmentLength;
        [SerializeField] private float _easyRadius;
        [SerializeField] private float _hardRadius;
        [SerializeField] private float _easyTurn;
        [SerializeField] private float _hardTurn;
        [SerializeField] private float _secondsToHard;
        [SerializeField] private Material _material;

        public int SegmentsCount => _segmentsCount;
        public float CurveLength => _curveLength;
        public float CurveStepSize => _curveStepSize;
        public float FirstSegmentLength => _firstSegmentLength;
        public float EasyRadius => _easyRadius;
        public float HardRadius => _hardRadius;
        public float EasyTurn => _easyTurn;
        public float HardTurn => _hardTurn;
        public float SecondsToHard => _secondsToHard;
        public Material Material => _material;
        public TunSegment TunSegment => _tunSegment;
    }
}