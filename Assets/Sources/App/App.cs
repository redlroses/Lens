using System;
using Game.Infrastructure.Interfaces.Services.Scenes;
using UnityEngine;

namespace Game.App
{
    public class App : MonoBehaviour
    {
        private ISceneStateMachineService _sceneService;

        private void Awake() =>
            DontDestroyOnLoad(this);

        private void Update() =>
            _sceneService?.Update(Time.deltaTime);

        public void Construct(ISceneStateMachineService sceneService) =>
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
    }
}