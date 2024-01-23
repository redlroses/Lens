using Reflex.Core;
using UnityEngine;

namespace Game.Implementations.App.EntryPoint
{
    public class Bootstrapper : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder) =>
            containerBuilder.OnContainerBuilt += OnContainerBuilt;

        private void OnContainerBuilt(Container container) =>
            new GameObject(nameof(App)).AddComponent<App>();
    }
}