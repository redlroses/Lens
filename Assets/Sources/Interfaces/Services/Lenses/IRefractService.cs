using Game.Implementations.Domain.Lenses;
using UnityEngine;

namespace Game.Interfaces.Services.Lenses
{
    public interface IRefractService
    {
        bool TryRefract(Lens lens, Ray enteredRay, out Ray refractedRay);
    }
}