using Game.Interfaces.StateMachines;

namespace Game.Interfaces.Services.Scenes
{
    public interface IScene : IState
    {
        string Name { get; }
    }
}