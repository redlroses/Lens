using System;
using Game.Controllers.Scenes;
using Game.Infrastructure.Implementation.Services.Scenes;
using Game.Infrastructure.Interfaces.Factories.Scenes;
using Game.Infrastructure.Interfaces.Services.Scenes;

namespace Game.Infrastructure.Implementation.Factories.Scenes
{
    public class GameMenuSceneFactory : ISceneFactory
    {
        private readonly SceneManageService _sceneStateMachineService;

        public GameMenuSceneFactory(SceneManageService sceneStateMachineService)
        {
            _sceneStateMachineService = sceneStateMachineService
                                        ?? throw new ArgumentNullException(nameof(sceneStateMachineService));
        }

        public IScene Create(ISceneChanger sceneChanger)
        {
            if (sceneChanger == null)
                throw new ArgumentNullException(nameof(sceneChanger));

            return new GameMenuScene(sceneChanger, _sceneStateMachineService);
        }
    }
}