using Game.Implementations.Infrastructure.Factories.Controllers;
using Game.Implementations.Infrastructure.Factories.Presentation.Views;
using Game.Implementations.Infrastructure.Services;
using Game.Implementations.Infrastructure.Services.Lenses;
using Game.Implementations.Infrastructure.Services.Scenes;
using Game.Implementations.Presentation.Views;
using Game.Interfaces.Services;
using Game.Interfaces.Services.Lenses;
using Game.Interfaces.Services.Scenes;
using Reflex.Core;
using UnityEngine;

namespace Game.Implementations.Installers
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(UpdateService), typeof(IUpdateHandler), typeof(IUpdateService));
            builder.AddSingleton(typeof(SceneManageService), typeof(ISceneManageService));
            builder.AddSingleton(typeof(SceneStateMachineService), typeof(ISceneStateMachineService), typeof(ISceneChanger));
            builder.AddSingleton(typeof(SurfaceDeformService), typeof(ISurfaceDeformService));
            builder.AddSingleton(typeof(RefractService), typeof(IRefractService));
            builder.AddSingleton(typeof(LensPresenterFactory));
            builder.AddSingleton(typeof(LensViewFactory));
            builder.AddSingleton(typeof(TubePresenterFactory));
            builder.AddSingleton(typeof(TubeViewFactory));
        }
    }
}