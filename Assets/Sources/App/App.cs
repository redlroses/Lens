using System;
using Game.Controllers.Scenes;
using Game.Infrastructure.Interfaces.Services;
using Game.Infrastructure.Interfaces.Services.Scenes;
using Reflex.Attributes;
using UnityEngine;

namespace Game.App
{
    public class App : MonoBehaviour
    {
        private IUpdateService _updateService;
        private ISceneStateMachineService _sceneService;

        [Inject]
        private void Construct(IUpdateService updateService, ISceneStateMachineService sceneService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            DontDestroyOnLoad(this);
        }

        private void Start() =>
            _sceneService.ChangeScene<GameMenuScene>();

        private void Update() =>
            _updateService.Update(Time.deltaTime);
    }
}