using System;
using Game.Implementations.Controllers.Presenters;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Presentation.Views;
using Game.Interfaces.Services;
using Game.Interfaces.Services.Lenses;

namespace Game.Implementations.Infrastructure.Factories.Controllers
{
    public class LensPresenterFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IRefractService _refractService;

        public LensPresenterFactory(IUpdateService updateService, IRefractService refractService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _refractService = refractService;
        }

        public LensPresenter Create(Lens lens, LensView lensView) =>
            new LensPresenter(lens, lensView, _updateService, _refractService);
    }
}