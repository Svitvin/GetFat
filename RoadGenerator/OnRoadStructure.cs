using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRoadStructure : MonoBehaviour
{
    RoadObjectPoint[] points;
    Transform[] pointsTransforms;

    private void Start()
    {

        points = GetComponentsInChildren<RoadObjectPoint>();
        pointsTransforms = new Transform[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            pointsTransforms[i] = points[i].transform;
        }

        Vector3[] betweenPointsVectors = CalculateBetweenPointsVectors();

        SetPoints(betweenPointsVectors);
    }

    Vector3[] CalculateBetweenPointsVectors()
    {
        Vector3[] result = new Vector3[pointsTransforms.Length];

        for (int i = 0; i < pointsTransforms.Length - 1; i++)
        {
            result[i] = pointsTransforms[i + 1].position - pointsTransforms[i].position;
        }
        return result;
    }

    void SetPoints(Vector3[] betweenPointsVectors)
    {
        Vector3 nextPosition = pointsTransforms[0].position;
        float rotation = -Vector3.Angle(Vector3.forward, pointsTransforms[0].forward);

        for (int i = 0; i < points.Length; i++)
        {
            Transform currentPointTransform = pointsTransforms[i];
            RoadObjectPoint currentObjectPoint = points[i];
            currentPointTransform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
            currentPointTransform.position = nextPosition;
            rotation += WallsOrientationSystem.GetDeviationAngleOf(currentPointTransform);
            currentPointTransform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
            //ошибка
            //currentPointTransform.position += WallsOrientationSystem.GetToPositionMovementFrom(currentPointTransform, currentObjectPoint.Position);

            currentObjectPoint.SetEntity();

            if (i < points.Length - 1)
                nextPosition = currentPointTransform.position + betweenPointsVectors[i];
        }
    }
}
