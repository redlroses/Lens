using System;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Presentation.Views;
using Game.Interfaces.Presenters;
using Game.Interfaces.Services;
using Game.Interfaces.Services.Lenses;

namespace Game.Implementations.Controllers.Presenters
{
    public class TubePresenter : IPresenter
    {
        private readonly Tube _tube;
        private readonly TubeView _tubeView;
        private readonly IUpdateService _updateService;
        private readonly IRefractService _refractService;

        public TubePresenter(Tube tube, TubeView tubeView, IUpdateService updateService, IRefractService refractService)
        {
            _tube = tube ?? throw new ArgumentNullException(nameof(tube));
            _tubeView = tubeView ?? throw new ArgumentNullException(nameof(tubeView));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _refractService = refractService ?? throw new ArgumentNullException(nameof(refractService));
        }

        public void Enable() =>
            _updateService.Updated += OnUpdate;

        public void Disable() =>
            _updateService.Updated -= OnUpdate;

        private void OnUpdate(float deltaTime) =>
            _refractService.Refract(_tube);
    }
}