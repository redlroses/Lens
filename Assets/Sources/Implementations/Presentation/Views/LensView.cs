using Game.Implementations.Controllers.Presenters;
using Game.Implementations.Domain.Lenses;
using Game.Interfaces.Services.Lenses;
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

            _frontSurface.sharedMesh = surfaceDeformService.Deform(_frontSurface.sharedMesh, lensParameters.FrontSurfaceRadius);
            _backSurface.sharedMesh = surfaceDeformService.Deform(_backSurface.sharedMesh, lensParameters.BackSurfaceRadius);

            _frontSurface.transform.position += new Vector3(0, 0, lensParameters.Thickness / 2f);
            _backSurface.transform.position -= new Vector3(0, 0, lensParameters.Thickness / 2f);

            transform.position = lensParameters.Position;

            Debug.Log("LensView Construct");
        }
    }
}