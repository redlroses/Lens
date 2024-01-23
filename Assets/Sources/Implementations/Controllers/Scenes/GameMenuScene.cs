using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Implementations.Domain.Lenses;
using Game.Implementations.Infrastructure.Factories.Presentation.Views;
using Game.Interfaces.Services.Scenes;

namespace Game.Implementations.Controllers.Scenes
{
    public class GameMenuScene : SceneBase
    {
        private readonly ISceneChanger _sceneChanger;
        private readonly ISceneManageService _sceneManageService;
        private readonly LensViewFactory _lensViewFactory;

        private CancellationTokenSource _cancellationToken;

        public GameMenuScene(ISceneChanger sceneChanger, ISceneManageService sceneManageService, LensViewFactory lensViewFactory)
        {
            _sceneChanger = sceneChanger ?? throw new ArgumentNullException(nameof(sceneChanger));
            _sceneManageService = sceneManageService ?? throw new ArgumentNullException(nameof(sceneManageService));
            _lensViewFactory = lensViewFactory ?? throw new ArgumentNullException(nameof(lensViewFactory));
        }

        public override string Name => nameof(GameMenuScene);

        public override async void Enter()
        {
            await LoadSceneAsync();
            var lens = new Lens();
            _lensViewFactory.Create(lens);
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