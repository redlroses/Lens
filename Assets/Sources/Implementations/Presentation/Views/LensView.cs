using Game.Implementations.Controllers.Presenters;
using Game.Implementations.Domain.Lenses;
using Game.Interfaces.Services.Lens;
using UnityEngine;

namespace Game.Implementations.Presentation.Views
{
    public class LensView : View
    {
        [SerializeField] private MeshFilter _frontSurface;
        [SerializeField] private MeshFilter _backSurface;

        public void Construct(
            LensPresenter lensPresenter,
            LensParameters lensParameters,
            ISurfaceDeformService surfaceDeformService)
        {
            Construct(lensPresenter);

            surfaceDeformService.Deform(_frontSurface.sharedMesh, lensParameters.FrontSurfaceRadius);
            surfaceDeformService.Deform(_backSurface.sharedMesh, lensParameters.BackSurfaceRadius);

            Debug.Log("LensView Construct");
        }
    }
}