using System;
using Game.Implementations.Controllers.Presenters;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Infrastructure.Factories.Controllers;
using Game.Implementations.Presentation.Views;
using Reflex.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Implementations.Infrastructure.Factories.Presentation.Views
{
    public class LensViewFactory
    {
        private readonly LensPresenterFactory _lensPresenterFactory;
        private readonly Container _container;

        public LensViewFactory(LensPresenterFactory lensPresenterFactory, Container container)
        {
            _lensPresenterFactory = lensPresenterFactory ?? throw new ArgumentNullException(nameof(lensPresenterFactory));
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public LensView Create(Lens lens)
        {
            GameObject prefab = Resources.Load<GameObject>("Views/Lens");
            LensView view = Object.Instantiate(prefab).GetComponent<LensView>();
            LensPresenter lensPresenter = _lensPresenterFactory.Create(lens, view);
            view.Construct(lensPresenter);

            return view;
        }
    }
}