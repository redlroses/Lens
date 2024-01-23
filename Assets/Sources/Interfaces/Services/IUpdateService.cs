using System;

namespace Game.Interfaces.Services
{
    public interface IUpdateService
    {
        event Action<float> Updated;
    }
}