using System;
using Game.Interfaces.StateMachines;

namespace Game.Implementations.Infrastructure.StateMachines
{
    public class StateMachineCore : IStateMachine
    {
        public IState CurrentState { get; private set; }

        public void ChangeState(IState state)
        {
            CurrentState?.Exit();
            CurrentState = state ?? throw new ArgumentNullException(nameof(state));
            CurrentState?.Enter();
        }
    }
}