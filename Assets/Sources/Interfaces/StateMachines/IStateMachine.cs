namespace Game.Interfaces.StateMachines
{
    public interface IStateMachine
    {
        IState CurrentState { get; }

        void ChangeState(IState state);
    }
}