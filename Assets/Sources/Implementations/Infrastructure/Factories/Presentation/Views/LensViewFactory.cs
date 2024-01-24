using System;
using Game.Implementations.Controllers.Presenters;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Infrastructure.Factories.Controllers;
using Game.Implementations.Presentation.Views;
using Game.Interfaces.Services.Lenses;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Implementations.Infrastructure.Factories.Presentation.Views
{
    public class LensViewFactory
    {
        private readonly LensPresenterFactory _lensPresenterFactory;
        private readonly ISurfaceDeformService _surfaceDeformService;

        public LensViewFactory(LensPresenterFactory lensPresenterFactory, ISurfaceDeformService surfaceDeformService)
        {
            _lensPresenterFactory = lensPresenterFactory ?? throw new ArgumentNullException(nameof(lensPresenterFactory));
            _surfaceDeformService = surfaceDeformService ?? throw new ArgumentNullException(nameof(surfaceDeformService));
        }

        public LensView Create(Lens lens)
        {
            GameObject prefab = Resources.Load<GameObject>("Views/Lens");
            LensView view = Object.Instantiate(prefab).GetComponent<LensView>();
            LensPresenter lensPresenter = _lensPresenterFactory.Create(lens, view);
            view.Construct(lensPresenter, new LensParameters(lens), _surfaceDeformService);

            return view;
        }
    }
}