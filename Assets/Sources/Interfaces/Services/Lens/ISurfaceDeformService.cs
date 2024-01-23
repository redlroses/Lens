using UnityEngine;

namespace Game.Interfaces.Services.Lens
{
    public interface ISurfaceDeformService
    {
        public void Deform(Mesh lensMesh, float radius);
    }
}