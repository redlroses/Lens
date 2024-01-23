using System;
using Game.Infrastructure.Implementation.StateMachines;
using Game.Infrastructure.Interfaces.Services.Scenes;
using Game.Infrastructure.Interfaces.StateMachines;
using Reflex.Core;

namespace Game.Infrastructure.Implementation.Services.Scenes
{
    public class SceneStateMachineService : ISceneStateMachineService
    {
        private readonly IStateMachine _stateMachine;
        private readonly Container _container;
        private readonly UpdatableStateMachine _updatableStateMachine;

        public SceneStateMachineService(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _stateMachine = new StateMachineCore();
            _updatableStateMachine = new UpdatableStateMachine(_stateMachine);
        }

        public void Update(float deltaTime) =>
            _updatableStateMachine.Update(deltaTime);

        public void ChangeScene<T>() where T : IScene
        {
            IState state = _container.Construct<T>();
            _stateMachine.ChangeState(state);
        }
    }
}