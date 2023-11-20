using UnityEngine;

namespace Game.Tun.Segment {
	public class TunSegment : MonoBehaviour {
		[SerializeField] private TunSegmentRenderer _renderer;
		[SerializeField] private MeshCollider _meshCollider;
		[SerializeField] [Range(0, 1f)] private float _radiusRandomDecreaseFactor = 0.8f;
		
		private TunSegmentData _data;
		public float BottomY => _data.Bottom.CenterY;

		public float CalculateRelativePosition(float y) => (y - _data.Top.CenterY) / (_data.Bottom.CenterY - _data.Top.CenterY);
		public Vector3 RingsPositionDifference() => _data.Bottom.Center - _data.Top.Center;
		public bool IncludesDepth(float y) => _data.Top.CenterY > y && y > _data.Bottom.CenterY;
		public Vector3 LerpDepth(float y) {
			var top = _data.Top;
			var bottom = _data.Bottom;
			var t = CalculateRelativePosition(y);
			return new Vector3(Mathf.Lerp(top.CenterX, bottom.CenterX, t), y, Mathf.Lerp(top.CenterZ, bottom.CenterZ, t));
		}

		public Vector3 RandomInTubPoint() {
			var lerp = Random.Range(0, 1);
			var minRadius = Mathf.Min(_data.Bottom.Radius, _data.Top.Radius) * _radiusRandomDecreaseFactor;
			var noise = Random.insideUnitSphere * minRadius;
			return Vector3.Lerp(_data.Bottom.Center, _data.Top.Center, lerp) + noise;
		}

		public void SetupSegment(TunSegmentData data) {
			_data = data;
			var mesh = _renderer.RenderSegment(data);
			_meshCollider.sharedMesh = mesh;
		}
	}
}
