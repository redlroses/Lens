using Game.Infrastructure.Interfaces.Services.Scenes;

namespace Game.Infrastructure.Interfaces.Factories.Scenes
{
    public interface ISceneFactory
    {
        IScene Create();
    }
}