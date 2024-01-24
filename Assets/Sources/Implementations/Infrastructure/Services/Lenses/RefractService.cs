using Game.Implementations.Domain.Lenses;
using Game.Interfaces.Services.Lenses;
using UnityEngine;

namespace Game.Implementations.Infrastructure.Services.Lenses
{
    public class RefractService : IRefractService
    {
        private float _lensDiameter;
        private float _refractiveIndexAir = 1f;
        private float _refractiveIndexSphere = 1.5f;
        private float _spread = 0.1f;

        private Transform frontGo = new GameObject("FrontSurfaceFocus").transform;
        private Transform backGo = new GameObject("BackSurfaceFocus").transform;

        public bool TryRefract(Lens lens, Ray enteredRay, out Ray refractedRay)
        {
            if (frontGo == null)
                frontGo = new GameObject("FrontSurfaceFocus").transform;

            if (backGo == null)
                backGo = new GameObject("BackSurfaceFocus").transform;

            refractedRay = new Ray();
            bool isOutsideFirstSphere = lens.FrontSurface.CurvatureRadius > 0;
            bool isOutsideSecondSphere = lens.BackSurface.CurvatureRadius < 0;

            Vector3 firstSpherePosition = lens.GetFrontSurfaceFocusPosition();
            frontGo.position = firstSpherePosition;
            Vector3 secondSpherePosition = lens.GetBackSurfaceFocusPosition();
            backGo.position = secondSpherePosition;

            Debug.DrawRay(enteredRay.origin, enteredRay.direction * 10f, Color.green);

            if (IntersectRaySphere(
                    enteredRay.origin,
                    enteredRay.direction,
                    firstSpherePosition,
                    lens.FrontSurface.CurvatureRadius,
                    isOutsideFirstSphere,
                    out Vector3 intersectionPoint) == false)
                return true;

            Vector3 surfaceNormal = (isOutsideFirstSphere ? 1 : -1)
                                    * (intersectionPoint - firstSpherePosition).normalized;

            refractedRay.direction = Refract(
                enteredRay.direction,
                _refractiveIndexAir / _refractiveIndexSphere,
                surfaceNormal);

            DrawNormal(surfaceNormal, intersectionPoint);
            Vector3 prevOrigin = intersectionPoint;

            if (IntersectRaySphere(
                    intersectionPoint,
                    refractedRay.direction,
                    secondSpherePosition,
                    lens.BackSurface.CurvatureRadius,
                    isOutsideSecondSphere,
                    out intersectionPoint) == false)
                return true;

            Debug.DrawRay(
                prevOrigin,
                refractedRay.direction.normalized * Vector3.Distance(prevOrigin, intersectionPoint),
                Color.blue);

            surfaceNormal = (isOutsideSecondSphere ? 1 : -1)
                            * (intersectionPoint - secondSpherePosition).normalized;

            var newRay = Refract(
                refractedRay.direction,
                _refractiveIndexSphere / _refractiveIndexAir,
                surfaceNormal);

            DrawNormal(surfaceNormal, intersectionPoint);
            Debug.DrawRay(intersectionPoint, newRay * 10f, Color.blue);

            return true;
        }

        private bool IntersectRaySphere(
            Vector3 rayOrigin,
            Vector3 rayDirection,
            Vector3 sphereCenter,
            float sphereRadius,
            bool isFirst,
            out Vector3 intersectionPoint)
        {
            intersectionPoint = Vector3.zero;

            Vector3 oc = rayOrigin - sphereCenter;
            float a = Vector3.Dot(rayDirection, rayDirection);
            float b = 2f * Vector3.Dot(oc, rayDirection);
            float c = Vector3.Dot(oc, oc) - sphereRadius * sphereRadius;
            float discriminant = b * b - 4 * a * c;

            if (discriminant >= 0)
            {
                float sqrtDiscriminant = Mathf.Sqrt(discriminant);
                float t1 = (-b - sqrtDiscriminant) / (2 * a);
                float t2 = (-b + sqrtDiscriminant) / (2 * a);

                if (isFirst)
                {
                    intersectionPoint = rayOrigin + rayDirection * t1;
                }
                else
                {
                    intersectionPoint = rayOrigin + rayDirection * t2;
                }

                return true;
            }

            return false;
        }

        private Vector3 Refract(Vector3 rayDirection, float refractRatio, Vector3 surfaceNormal)
        {
            float cosTheta1 = -Vector3.Dot(rayDirection, surfaceNormal);

            float cosTheta2Squared = 1 - refractRatio * refractRatio * (1 - cosTheta1 * cosTheta1);

            cosTheta1 = Mathf.Abs(cosTheta1);

            if (cosTheta2Squared < 0f)
            {
                return Vector3.zero;
            }

            float cosTheta2 = Mathf.Sqrt(cosTheta2Squared);

            Vector3 refractedDirection =
                refractRatio * rayDirection + (refractRatio * cosTheta1 - cosTheta2) * surfaceNormal;

            return refractedDirection.normalized;
        }

        private void DrawNormal(Vector3 normal, Vector3 from)
        {
            Debug.DrawRay(from, normal * 0.3f, Color.yellow);
        }
    }
}