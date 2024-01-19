using System;
using Game.Infrastructure.Interfaces.Services;
using Game.Infrastructure.Interfaces.StateMachines;

namespace Game.Infrastructure.Implementation.StateMachines
{
    public class UpdatableStateMachine : IStateMachine, IUpdatable
    {
        private readonly IStateMachine _stateMachine;

        private IUpdatable _updatableState;
        private Action<float> _updateAction = _ => { };

        public UpdatableStateMachine(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public IState CurrentState => _stateMachine.CurrentState;

        public void ChangeState(IState state)
        {
            _stateMachine.ChangeState(state);

            if (state is IUpdatable updatable)
                _updateAction = deltaTime => updatable.Update(deltaTime);
        }

        public void Update(float deltaTime) =>
            _updateAction.Invoke(deltaTime);
    }
}