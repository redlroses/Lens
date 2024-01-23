using Game.Interfaces.Services.Scenes;

namespace Game.Implementations.Controllers.Scenes
{
    public abstract class SceneBase : IScene
    {
        public abstract string Name { get; }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }
}