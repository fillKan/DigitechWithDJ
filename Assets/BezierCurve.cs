using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BezierCurveExtension
{
    public static Vector2 BezierCurve2(this Vector2 v, Vector2 pointA, Vector2 pointB, Vector2 pointC, float ratio)
    {
        Vector2 a = Vector2.Lerp(pointA, pointB, ratio);
        Vector2 b = Vector2.Lerp(pointB, pointC, ratio);

        return Vector2.Lerp(a, b, ratio);
    }
    public static Vector2 BezierCurve3(this Vector2 v, Vector2 pointA, Vector2 pointB, Vector2 pointC, Vector2 pointD, float ratio)
    {
        Vector2 a = Vector2.Lerp(pointA, pointB, ratio);
        Vector2 b = Vector2.Lerp(pointB, pointC, ratio);
        Vector2 c = Vector2.Lerp(pointC, pointD, ratio);

        Vector2 _a = Vector2.Lerp(a, b, ratio);
        Vector2 _b = Vector2.Lerp(b, c, ratio);

        return Vector2.Lerp(_a, _b, ratio);
    }
    public static Vector3 BezierCurve2(this Vector3 v, Vector3 pointA, Vector3 pointB, Vector3 pointC, float ratio)
    {
        Vector3 a = Vector3.Lerp(pointA, pointB, ratio);
        Vector3 b = Vector3.Lerp(pointB, pointC, ratio);

        return Vector3.Lerp(a, b, ratio);
    }
    public static void BezierCurve3(this Transform transform, Vector3 pointA, Vector3 pointB, Vector3 pointC, Vector3 pointD, float ratio)
    {
        Vector3 a = Vector3.Lerp(pointA, pointB, ratio);
        Vector3 b = Vector3.Lerp(pointB, pointC, ratio);
        Vector3 c = Vector3.Lerp(pointC, pointD, ratio);

        Vector3 _a = Vector3.Lerp(a, b, ratio);
        Vector3 _b = Vector3.Lerp(b, c, ratio);

        transform.position = Vector3.Lerp(_a, _b, ratio);
    }
}

public class BezierCurve : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private Transform _Object;

    [Header("Points")]
    [SerializeField] private Vector2 PointA;
    [SerializeField] private Vector2 PointB;
    [SerializeField] private Vector2 PointC;
    [SerializeField] private Vector2 PointD;

    [Header("Ratio")][Range(0f, 1f)]
    [SerializeField] private float Ratio;

    private void Update()
    {
        _Object.BezierCurve3(PointA, PointB, PointC, PointD, Ratio);
    }
}
