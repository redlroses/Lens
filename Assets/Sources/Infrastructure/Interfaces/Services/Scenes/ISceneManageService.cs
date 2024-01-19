using System.Threading;
using Cysharp.Threading.Tasks;

namespace Game.Infrastructure.Interfaces.Services.Scenes
{
    public interface ISceneManageService
    {
        UniTask LoadSceneAsync(string sceneName, CancellationToken cancellationToken);
    }
}