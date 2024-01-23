using Game.Infrastructure.Implementation.Services;
using Game.Infrastructure.Implementation.Services.Scenes;
using Game.Infrastructure.Interfaces.Services;
using Game.Infrastructure.Interfaces.Services.Scenes;
using Reflex.Core;
using UnityEngine;

namespace Game.Installers
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