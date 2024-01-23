using System;

namespace Game.Interfaces.Services
{
    public interface IUpdateService : IUpdatable
    {
        event Action<float> Updated;
    }
}