using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Interfaces.Services.Scenes;
using UnityEngine.SceneManagement;

namespace Game.Implementations.Infrastructure.Services.Scenes
{
    public class SceneManageService : ISceneManageService
    {
        public async UniTask LoadSceneAsync(string sceneName, CancellationToken cancellationToken) =>
            await SceneManager.LoadSceneAsync(sceneName).WithCancellation(cancellationToken);
    }
}