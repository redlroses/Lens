using UnityEngine;

namespace Game.Interfaces.Services.Lens
{
    public interface IRefractService
    {
        Vector3 Refract(Implementations.Domain.Lenses.Lens lens);
    }
}