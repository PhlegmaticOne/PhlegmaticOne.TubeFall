using System.Collections.Generic;
using UnityEngine;

namespace Game.Tun.Segment {
    public class TunSegmentRenderer : MonoBehaviour {
	    [SerializeField] private MeshRenderer _meshRenderer;
	    [SerializeField] private MeshFilter _meshFilter;
	    
        public Mesh RenderSegment(TunSegmentData data) {
            data.EnsureRingsInRightPlacement();
            			
            var sidesCount = data.SidesCount;
            var top = data.Top;
            var bottom = data.Bottom;

            // Create the mesh components
            // Init arrays
            var vertices = new Vector3[sidesCount * 2];
            var hardVertices = new List<Vector3>();
            var uv = new Vector2[sidesCount * 2 * 3];
            var triangles = new int[sidesCount * 2 * 3];

            // For each vertex of a ring
            for(var i = 0; i < sidesCount; i++)
            {
            	// Generate bottom ring vertex
            	vertices[i+sidesCount] = new Vector3(
            		bottom.Radius * Mathf.Cos(2 * Mathf.PI * i / sidesCount) + bottom.CenterX,
            		bottom.CenterY,
            		bottom.Radius * Mathf.Sin(2 * Mathf.PI * i / sidesCount) + bottom.CenterZ
            	);

            	// Generate top ring vertex
            	vertices[i] = new Vector3(
            		top.Radius * Mathf.Cos(2 * Mathf.PI * i / sidesCount) + top.CenterX,
            		top.CenterY,
            		top.Radius * Mathf.Sin(2 * Mathf.PI * i / sidesCount) + top.CenterZ
            	);

            	// Create tringles using new vertex
            	triangles[i*sidesCount] = (i + 1) % sidesCount;
            	triangles[i*sidesCount+1] = i;
            	triangles[i*sidesCount+2] = ((i + sidesCount) % sidesCount) + sidesCount;
            
            	triangles[i*sidesCount+3] = (i + 1) % sidesCount;
            	triangles[i*sidesCount+4] = ((i + sidesCount) % sidesCount) + sidesCount;
            	triangles[i*sidesCount+5] = ((i + sidesCount + 1) % sidesCount) + sidesCount;
            }

            // Give each triangle its own vertex (no sharing vertices)
            for(var k = 0; k < triangles.Length; k++) {
            	hardVertices.Add(vertices[triangles[k]]);
            	triangles[k] = k;
            	uv[k] = Vector2.zero;
            }

            var mesh = SetupMesh(hardVertices, uv, triangles);
            _meshRenderer.material = data.Material;
            return mesh;
        }

        private Mesh SetupMesh(List<Vector3> hardVertices, Vector2[] uv, int[] triangles) {
	        var mesh = _meshFilter.mesh;
	        mesh.Clear();
	        mesh.vertices = hardVertices.ToArray();
	        mesh.uv = uv;
	        mesh.triangles = triangles;
	        mesh.hideFlags = HideFlags.DontSave;
	        mesh.RecalculateBounds();
	        mesh.RecalculateNormals();
	        return mesh;
        }
    }
}