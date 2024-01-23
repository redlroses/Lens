using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Interfaces.Services.Scenes;

namespace Game.Implementations.Controllers.Scenes
{
    public class GameMenuScene : SceneBase
    {
        private readonly ISceneChanger _sceneChanger;
        private readonly ISceneManageService _sceneManageService;

        private CancellationTokenSource _cancellationToken;

        public GameMenuScene(ISceneChanger sceneChanger, ISceneManageService sceneManageService)
        {
            _sceneChanger = sceneChanger ?? throw new ArgumentNullException(nameof(sceneChanger));
            _sceneManageService = sceneManageService ?? throw new ArgumentNullException(nameof(sceneManageService));
        }

        public override string Name => nameof(GameMenuScene);

        public override async void Enter()
        {
            await LoadSceneAsync();
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