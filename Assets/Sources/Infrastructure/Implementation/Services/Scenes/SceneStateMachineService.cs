using System;
using System.Collections.Generic;
using Game.Infrastructure.Implementation.StateMachines;
using Game.Infrastructure.Interfaces.Factories.Scenes;
using Game.Infrastructure.Interfaces.Services.Scenes;
using Game.Infrastructure.Interfaces.StateMachines;

namespace Game.Infrastructure.Implementation.Services.Scenes
{
    public class SceneStateMachineService : ISceneStateMachineService
    {
        private readonly IStateMachine _stateMachine;
        private readonly IReadOnlyDictionary<Type, ISceneFactory> _sceneFactories;
        private readonly UpdatableStateMachine _updatableStateMachine;

        public SceneStateMachineService(IStateMachine stateMachine, IReadOnlyDictionary<Type, ISceneFactory> sceneFactories)
        {
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));
            _sceneFactories = sceneFactories ?? throw new ArgumentNullException(nameof(sceneFactories));
            _updatableStateMachine = new UpdatableStateMachine(stateMachine);
        }

        public void Update(float deltaTime) =>
            _updatableStateMachine.Update(deltaTime);

        public void ChangeScene<T>() where T : IScene
        {
            if (_sceneFactories.TryGetValue(typeof(T), out ISceneFactory sceneFactory) == false)
                throw new InvalidOperationException();

            IState state = sceneFactory.Create(this);
            _stateMachine.ChangeState(state);
        }
    }
}