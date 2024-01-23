using System;
using Game.Implementations.Controllers.Scenes;
using Game.Interfaces.Services;
using Game.Interfaces.Services.Scenes;
using Reflex.Attributes;
using UnityEngine;

namespace Game.Implementations.App
{
    public class App : MonoBehaviour
    {
        private IUpdateHandler _updateService;
        private ISceneStateMachineService _sceneService;

        [Inject]
        private void Construct(IUpdateHandler updateHandler, ISceneStateMachineService sceneService)
        {
            _updateService = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            DontDestroyOnLoad(this);
        }

        private void Start() =>
            _sceneService.ChangeScene<GameMenuScene>();

        private void Update() =>
            _updateService.Update(Time.deltaTime);
    }
}