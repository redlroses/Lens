using System;
using Game.Implementations.Controllers.Presenters;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Presentation.Views;
using Game.Interfaces.Services;
using Game.Interfaces.Services.Lenses;

namespace Game.Implementations.Infrastructure.Factories.Controllers
{
    public class TubePresenterFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IRefractService _refractService;

        public TubePresenterFactory(IUpdateService updateService, IRefractService refractService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _refractService = refractService ?? throw new ArgumentNullException(nameof(refractService));
        }

        public TubePresenter Create(Tube tube, TubeView tubeView) =>
            new TubePresenter(tube, tubeView, _updateService, _refractService);
    }
}