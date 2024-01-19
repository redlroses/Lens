using System;
using Game.Controllers.Scenes;
using Game.Infrastructure.Interfaces.Services.Scenes;
using UnityEngine;

namespace Game.App
{
    public class App : MonoBehaviour
    {
        private ISceneStateMachineService _sceneService;

        private void Awake() =>
            DontDestroyOnLoad(this);

        private void Start() =>
            _sceneService.ChangeScene<GameMenuScene>();

        private void Update() =>
            _sceneService?.Update(Time.deltaTime);

        public void Construct(ISceneStateMachineService sceneService) =>
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
    }
}