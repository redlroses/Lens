using System;
using Game.Implementations.Infrastructure.StateMachines;
using Game.Interfaces.Services.Scenes;
using Game.Interfaces.StateMachines;
using Reflex.Core;

namespace Game.Implementations.Infrastructure.Services.Scenes
{
    public class SceneStateMachineService : ISceneStateMachineService
    {
        private readonly IStateMachine _stateMachine;
        private readonly Container _container;
        private readonly UpdateHandlerStateMachine _updateHandlerStateMachine;

        public SceneStateMachineService(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _stateMachine = new StateMachineCore();
            _updateHandlerStateMachine = new UpdateHandlerStateMachine(_stateMachine);
        }

        public void Update(float deltaTime) =>
            _updateHandlerStateMachine.Update(deltaTime);

        public void ChangeScene<T>() where T : IScene
        {
            IState state = _container.Construct<T>();
            _stateMachine.ChangeState(state);
        }
    }
}