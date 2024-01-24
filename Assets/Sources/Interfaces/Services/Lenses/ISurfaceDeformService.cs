using UnityEngine;

namespace Game.Interfaces.Services.Lenses
{
    public interface ISurfaceDeformService
    {
        public Mesh Deform(Mesh lensMesh, float radius);
    }
}