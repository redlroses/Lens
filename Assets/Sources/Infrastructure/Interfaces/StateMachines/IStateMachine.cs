namespace Game.Infrastructure.Interfaces.StateMachines
{
    public interface IStateMachine
    {
        IState CurrentState { get; }

        void ChangeState(IState state);
    }
}