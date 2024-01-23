using System;

namespace Game.Infrastructure.Interfaces.Services
{
    public interface IUpdateService : IUpdatable
    {
        event Action<float> Updated;
    }
}