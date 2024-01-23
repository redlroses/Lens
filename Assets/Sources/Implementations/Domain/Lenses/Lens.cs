using Game.Implementations.Domain.Lenses.Surfaces;

namespace Game.Implementations.Domain.Lenses
{
    public class Lens
    {
        public Lens(float frontSurfaceRadius, float backSurfaceRadius, float thickness, float radius)
        {
            FrontSurface = new Surface(frontSurfaceRadius);
            BackSurface = new Surface(backSurfaceRadius);
            Thickness = thickness;
            Radius = radius;
        }

        public Surface FrontSurface { get; set; }
        public Surface BackSurface { get; set; }
        public float Thickness { get; set; }
        public float Radius { get; set; }
    }
}