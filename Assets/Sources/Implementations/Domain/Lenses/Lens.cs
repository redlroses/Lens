using Game.Implementations.Domain.Lenses.Surfaces;
using UnityEngine;

namespace Game.Implementations.Domain.Lenses
{
    public class Lens
    {
        public Lens(
            Vector3 position,
            float frontSurfaceRadius,
            float backSurfaceRadius,
            float thickness,
            float radius,
            float refractiveIndex)
        {
            FrontSurface = new Surface(frontSurfaceRadius);
            BackSurface = new Surface(backSurfaceRadius);
            Position = position;
            Thickness = thickness;
            Radius = radius;
            RefractiveIndex = refractiveIndex;
        }

        public float RefractiveIndex { get; set; }

        public Surface FrontSurface { get; set; }

        public Surface BackSurface { get; set; }

        public Vector3 Position { get; set; }

        public float Thickness { get; set; }

        public float Radius { get; set; }

        public Vector3 GetFrontSurfaceFocusPosition()
        {
            float curvatureRadius = FrontSurface.CurvatureRadius;

            return Position - new Vector3(
                0,
                0,
                Mathf.Sqrt(curvatureRadius * curvatureRadius - Radius * Radius) * Mathf.Sign(curvatureRadius) - Thickness / 2f);
        }

        public Vector3 GetBackSurfaceFocusPosition()
        {
            float curvatureRadius = BackSurface.CurvatureRadius;

            return Position + new Vector3(
                0,
                0,
                Mathf.Sqrt(curvatureRadius * curvatureRadius - Radius * Radius) * Mathf.Sign(curvatureRadius) - Thickness / 2f);
        }
    }
}