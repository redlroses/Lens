using Game.Implementations.Infrastructure.Services;
using Game.Implementations.Infrastructure.Services.Scenes;
using Game.Interfaces.Services;
using Game.Interfaces.Services.Scenes;
using Reflex.Core;
using UnityEngine;

namespace Game.Implementations.Installers
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(UpdateService), typeof(IUpdateService));
            builder.AddSingleton(typeof(SceneManageService), typeof(ISceneManageService));
            builder.AddSingleton(typeof(SceneStateMachineService), typeof(ISceneStateMachineService), typeof(ISceneChanger));
        }
    }
}