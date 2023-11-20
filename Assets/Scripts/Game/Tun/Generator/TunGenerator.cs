using System;
using Game.Base;
using Game.Difficulty;
using Game.Tun.Generator.Configs;
using Game.Tun.Generator.Factory;
using Game.Tun.Models;
using Game.Tun.Segment;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Tun.Generator {
	public class TunGenerator : IUpdatable {
		private readonly TunGeneratorConfig _config;
		private readonly TunPipelineCollection _tunPipelineCollection;
		private readonly IDifficulty _difficulty;
		private readonly ITunFactory _tunFactory;

		private float _curveT;
		private Ring _lastDesiredCenter;
		private Ring _nextDesiredCenter;

		public TunGenerator(TunGeneratorConfig config,
			TunPipelineCollection tunPipelineCollection,
			IDifficulty difficulty,
			ITunFactory tunFactory) {
			_tunFactory = tunFactory;
			_difficulty = difficulty;
			_tunPipelineCollection = tunPipelineCollection;
			_config = config;
		}

		public event Action<TunSegment> Generated; 

		public void OnAwake() {
			var difficulty = _difficulty.CalculateDifficulty(0);
			var top = new Ring(0, 10, 0, difficulty.Radius);
			var bottom = new Ring(0, -_config.FirstSegmentLength, 0, difficulty.Radius);
			CreateSegment(top, bottom);
			_nextDesiredCenter = bottom;
			PickNextDesiredCenter(difficulty);
		}

		public void OnUpdate(float deltaTime) {
			var difficulty = _difficulty.CalculateDifficulty(Time.timeSinceLevelLoad);
			
			while (_tunPipelineCollection.TunsCount < _config.SegmentsCount) {
				CreateNextSegment(difficulty);
			}
		}

		public void OnDispose() { }

		private void CreateNextSegment(in DifficultyData difficultyData) {
			if(_curveT >= 1) {
				PickNextDesiredCenter(difficultyData);
				_curveT = 0;
			}
			
			var top = Ring.SmoothStep(_lastDesiredCenter, _nextDesiredCenter, _curveT);
			_curveT += _config.CurveStepSize;
			var bottom = Ring.SmoothStep(_lastDesiredCenter, _nextDesiredCenter, _curveT);
			CreateSegment(top, bottom);
		}

		private void CreateSegment(Ring top, Ring bottom) {
			var segment = _tunFactory.CreateTun(top, bottom);
			_tunPipelineCollection.AddTun(segment);
			Generated?.Invoke(segment);
		}

		private void PickNextDesiredCenter(in DifficultyData difficulty) {
			_lastDesiredCenter = _nextDesiredCenter;
			var turnDir = Random.insideUnitCircle * difficulty.Turn;
			_nextDesiredCenter = new Ring(
				_lastDesiredCenter.CenterX + turnDir.x,
				_lastDesiredCenter.CenterY - _config.CurveLength,
				_lastDesiredCenter.CenterZ + turnDir.y,
				difficulty.Radius);
		}
	}
}
