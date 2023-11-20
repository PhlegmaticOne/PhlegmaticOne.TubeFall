using UnityEngine;

namespace Game.Tun.Models {
	public class Ring {
		public float CenterX { get; }
		public float CenterY { get; }
		public float CenterZ { get; }
		public float Radius { get; }
		public Vector3 Center => new(CenterX, CenterY, CenterZ);

		public Ring(float centerX, float  centerY, float centerZ, float radius) {
			CenterX = centerX;
			CenterY = centerY;
			CenterZ = centerZ;
			Radius = radius;
		}

		public static Ring SmoothStep(Ring a, Ring b, float t) {
			return new(
				Mathf.SmoothStep(a.CenterX, b.CenterX, t),
				Mathf.Lerp(a.CenterY, b.CenterY, t), // Have to lerp here or it just goes linearly
				Mathf.SmoothStep(a.CenterZ, b.CenterZ, t),
				Mathf.SmoothStep(a.Radius, b.Radius, t)
			);
		}
	}
}