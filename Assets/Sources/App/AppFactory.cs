using System;
using System.Collections.Generic;
using Game.Controllers.Scenes;
using Game.Infrastructure.Implementation.Factories.Scenes;
using Game.Infrastructure.Implementation.Services.Scenes;
using Game.Infrastructure.Implementation.StateMachines;
using Game.Infrastructure.Interfaces.Factories.Scenes;
using UnityEngine;

namespace Game.App
{
    public class AppFactory
    {
        public App Create()
        {
            App app = CreateApp();

            var stateMachine = new StateMachineCore();
            var sceneManageService = new SceneManageService();

            var sceneFactories = new Dictionary<Type, ISceneFactory>()
            {
                [typeof(GameMenuScene)] = new GameManuSceneFactory(sceneManageService),
            };

            var sceneService = new SceneStateMachineService(stateMachine, sceneFactories);
            app.Construct(sceneService);

            return app;
        }

        private App CreateApp() =>
            new GameObject(nameof(App)).AddComponent<App>();
    }
}