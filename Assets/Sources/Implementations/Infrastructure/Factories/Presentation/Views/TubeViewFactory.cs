using System;
using Game.Implementations.Controllers.Presenters;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Infrastructure.Factories.Controllers;
using Game.Implementations.Presentation.Views;
using UnityEngine;

namespace Game.Implementations.Infrastructure.Factories.Presentation.Views
{
    public class TubeViewFactory
    {
        private readonly TubePresenterFactory _presenterFactory;

        public TubeViewFactory(TubePresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public TubeView Create(Tube tube)
        {
            TubeView tubeView = new GameObject(nameof(Tube)).AddComponent<TubeView>();
            TubePresenter tubePresenter = _presenterFactory.Create(tube, tubeView);
            tubeView.Construct(tubePresenter);

            return tubeView;
        }
    }
}