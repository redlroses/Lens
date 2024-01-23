namespace Game.Implementations.Domain.Lenses
{
    public struct LensParameters
    {
        public readonly float FrontSurfaceRadius;
        public readonly float BackSurfaceRadius;
        public readonly float Thickness;
        public readonly float Radius;

        public LensParameters(Lens lens)
        {
            FrontSurfaceRadius = lens.FrontSurface.CurvatureRadius;
            BackSurfaceRadius = lens.BackSurface.CurvatureRadius;
            Thickness = lens.Thickness;
            Radius = lens.Radius;
        }
    }
}