using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class WallsOrientationSystem
{
    static public float GetDeviationAngleOf(Transform origin)
    {
        RaycastHit hitInfo = RayHitToWallFrom(origin);

        float rotationAngle = Vector3.Angle(hitInfo.normal, origin.right);

        if (Vector3.Angle(hitInfo.normal, origin.forward) < 90)
        {
            rotationAngle = -rotationAngle;
        }

        return rotationAngle;
    }

    static public Vector3 GetToCentreMovementFrom(Transform origin)
    {
        float distanceToCentre = 0.5f - RayHitToWallFrom(origin).distance;

        Vector3 toCentreMovement = origin.right * distanceToCentre;

        return toCentreMovement;
    }

    static public Vector3 GetToPositionMovementFrom(Transform origin, float position)
    {
        float distanceToCentre = position - RayHitToWallFrom(origin).distance;
        Vector3 toPositionMovement = origin.right * distanceToCentre;

        return toPositionMovement;
    }

    static RaycastHit RayHitToWallFrom(Transform origin)
    {
        int layerMask = 1 << 6;

        RaycastHit result;
        Physics.Raycast(origin.position, -origin.right, out result, 1, layerMask);
        return result;
    }
}
