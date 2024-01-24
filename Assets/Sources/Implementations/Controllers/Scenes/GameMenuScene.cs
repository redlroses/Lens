using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Domain.Lenses.Surfaces;
using Game.Implementations.Infrastructure.Factories.Presentation.Views;
using Game.Interfaces.Services.Scenes;
using UnityEngine;

namespace Game.Implementations.Controllers.Scenes
{
    public class GameMenuScene : SceneBase
    {
        private readonly ISceneChanger _sceneChanger;
        private readonly ISceneManageService _sceneManageService;
        private readonly LensViewFactory _lensViewFactory;
        private readonly TubeViewFactory _tubeViewFactory;

        private CancellationTokenSource _cancellationToken;

        public GameMenuScene(ISceneChanger sceneChanger, ISceneManageService sceneManageService, LensViewFactory lensViewFactory, TubeViewFactory tubeViewFactory)
        {
            _sceneChanger = sceneChanger ?? throw new ArgumentNullException(nameof(sceneChanger));
            _sceneManageService = sceneManageService ?? throw new ArgumentNullException(nameof(sceneManageService));
            _lensViewFactory = lensViewFactory ?? throw new ArgumentNullException(nameof(lensViewFactory));
            _tubeViewFactory = tubeViewFactory ?? throw new ArgumentNullException(nameof(tubeViewFactory));
        }

        public override string Name => nameof(GameMenuScene);

        public override async void Enter()
        {
            await LoadSceneAsync();
            var lens = new Lens(new Vector3(0, 0, -3f), 1.5f, 2f, 0.5f, 1f, 1.5f);
            _lensViewFactory.Create(lens);

            var tube = new Tube();
            tube.InsertLens(lens);
            _tubeViewFactory.Create(tube);
        }

        public override void Exit()
        {
            _cancellationToken.Cancel();
        }

        private async UniTask LoadSceneAsync()
        {
            _cancellationToken = new CancellationTokenSource();
            await _sceneManageService.LoadSceneAsync(nameof(GameMenuScene), _cancellationToken.Token);
            _cancellationToken.Dispose();
        }
    }
}