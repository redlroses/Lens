using System;
using Game.Infrastructure.Interfaces.Services;

namespace Game.Infrastructure.Implementation.Services
{
    public class UpdateService : IUpdateService
    {
        public event Action<float> Updated = delegate { };

        public void Update(float deltaTime) =>
            Updated.Invoke(deltaTime);
    }
}