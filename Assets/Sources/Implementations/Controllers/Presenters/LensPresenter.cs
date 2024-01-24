using System;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Presentation.Views;
using Game.Interfaces.Presenters;
using Game.Interfaces.Services;
using Game.Interfaces.Services.Lenses;
using UnityEngine;

namespace Game.Implementations.Controllers.Presenters
{
    public class LensPresenter : IPresenter
    {
        private readonly Lens _lens;
        private readonly LensView _lensView;
        private readonly IUpdateService _updateService;
        private readonly IRefractService _refractService;
        private readonly ISurfaceDeformService _deformService;
        private float _spread = 0.1f;

        public LensPresenter(Lens lens, LensView lensView, IUpdateService updateService, IRefractService refractService)
        {
            _lens = lens ?? throw new ArgumentNullException(nameof(lens));
            _lensView = lensView ?? throw new ArgumentNullException(nameof(lensView));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _refractService = refractService ?? throw new ArgumentNullException(nameof(refractService));
        }

        public void Enable()
        {
            _updateService.Updated += OnUpdate;
        }

        public void Disable()
        {
            Debug.Log("LensPresenter Disable");
        }

        private void OnUpdate(float deltaTime)
        {
            _refractService.TryRefract(
                _lens,
                new Ray(Vector3.zero + new Vector3(0, _spread * 2f, 0), -Vector3.forward),
                out var refractedRay);

            _refractService.TryRefract(
                _lens,
                new Ray(Vector3.zero + new Vector3(0, _spread, 0), -Vector3.forward),
                out refractedRay);

            _refractService.TryRefract(
                _lens,
                new Ray(Vector3.zero + new Vector3(0, 0, 0), -Vector3.forward),
                out refractedRay);

            _refractService.TryRefract(
                _lens,
                new Ray(Vector3.zero + new Vector3(0, -_spread, 0), -Vector3.forward),
                out refractedRay);

            _refractService.TryRefract(
                _lens,
                new Ray(Vector3.zero + new Vector3(0, -_spread * 2f, 0), -Vector3.forward),
                out refractedRay);

            Debug.Log("UpdateLens " + deltaTime);
        }
    }
}