using System;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Presentation.Views;
using Game.Interfaces.Presenters;
using Game.Interfaces.Services;
using Game.Interfaces.Services.Lens;
using UnityEngine;

namespace Game.Implementations.Controllers.Presenters
{
    public class LensPresenter : IPresenter
    {
        private readonly Lens _lens;
        private readonly LensView _lensView;
        private readonly IUpdateService _updateService;
        private readonly ISurfaceDeformService _deformService;

        public LensPresenter(Lens lens, LensView lensView, IUpdateService updateService)
        {
            _lens = lens ?? throw new ArgumentNullException(nameof(lens));
            _lensView = lensView ?? throw new ArgumentNullException(nameof(lensView));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
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
            Debug.Log("UpdateLens " + deltaTime);
        }
    }
}