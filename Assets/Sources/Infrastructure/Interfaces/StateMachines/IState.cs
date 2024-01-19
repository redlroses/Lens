namespace Game.Infrastructure.Interfaces.StateMachines
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}