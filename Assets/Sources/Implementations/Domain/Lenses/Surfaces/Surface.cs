namespace Game.Implementations.Domain.Lenses.Surfaces
{
    public class Surface
    {
        public float CurvatureRadius { get; set; }

        public Surface(float curvatureRadius)
        {
            CurvatureRadius = curvatureRadius;
        }
    }
}