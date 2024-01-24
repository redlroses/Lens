using Game.Interfaces.Services.Lenses;
using UnityEngine;

namespace Game.Implementations.Infrastructure.Services.Lenses
{
    public class SurfaceDeformService : ISurfaceDeformService
    {
        public Mesh Deform(Mesh lensMesh, float radius)
        {
            Vector3[] originalVertices = lensMesh.vertices;
            Vector3[] normalVerts = new Vector3[originalVertices.Length];
            Vector3[] displacedVertices = new Vector3[originalVertices.Length];

            for (int i = 0; i < originalVertices.Length; i++)
            {
                float x = originalVertices[i].x;
                float z = originalVertices[i].z;

                float position = Mathf.Sqrt(x * x + z * z);
                float height = Mathf.Sqrt(radius * radius - position * position);

                float y = normalVerts[i].y / 10000.0f + (height - Mathf.Sqrt(radius * radius - 1)) * Mathf.Sign(radius);

                Vector3 newVertPos = new Vector3(x, y, z);
                displacedVertices[i] = newVertPos;
            }

            Mesh newMesh = Object.Instantiate(lensMesh);
            newMesh.vertices = displacedVertices;
            newMesh.RecalculateNormals();
            return newMesh;
        }
    }
}