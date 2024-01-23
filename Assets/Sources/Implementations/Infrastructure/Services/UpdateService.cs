using System;
using Game.Interfaces.Services;

namespace Game.Implementations.Infrastructure.Services
{
    public class UpdateService : IUpdateService, IUpdateHandler
    {
        public event Action<float> Updated = delegate { };

        public void Update(float deltaTime) =>
            Updated.Invoke(deltaTime);
    }
}