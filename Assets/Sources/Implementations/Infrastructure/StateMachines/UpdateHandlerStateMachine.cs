using System;
using Game.Interfaces.Services;
using Game.Interfaces.StateMachines;

namespace Game.Implementations.Infrastructure.StateMachines
{
    public class UpdateHandlerStateMachine : IStateMachine, IUpdateHandler
    {
        private readonly IStateMachine _stateMachine;

        private IUpdateHandler _updateHandlerState;
        private Action<float> _updateAction = _ => { };

        public UpdateHandlerStateMachine(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public IState CurrentState => _stateMachine.CurrentState;

        public void ChangeState(IState state)
        {
            _stateMachine.ChangeState(state);

            if (state is IUpdateHandler updatable)
                _updateAction = deltaTime => updatable.Update(deltaTime);
        }

        public void Update(float deltaTime) =>
            _updateAction.Invoke(deltaTime);
    }
}