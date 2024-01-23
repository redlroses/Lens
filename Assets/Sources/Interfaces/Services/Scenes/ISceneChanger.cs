namespace Game.Interfaces.Services.Scenes
{
    public interface ISceneChanger
    {
        void ChangeScene<T>() where T : IScene;
    }
}