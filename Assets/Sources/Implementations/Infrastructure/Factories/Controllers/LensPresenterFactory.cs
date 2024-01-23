using System;
using Game.Implementations.Controllers.Presenters;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Presentation.Views;
using Game.Interfaces.Services;

namespace Game.Implementations.Infrastructure.Factories.Controllers
{
    public class LensPresenterFactory
    {
        private readonly IUpdateService _updateService;

        public LensPresenterFactory(IUpdateService updateService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
        }

        public LensPresenter Create(Lens lens, LensView lensView) =>
            new LensPresenter(lens, lensView, _updateService);
    }
}