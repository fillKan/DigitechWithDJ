using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Coordinate { World, Local }

public enum Shapes
{
    Shape0,
    Shape1, Shape2,
    Shape3, Shape4,
    Shape5, Shape6,
}

public static class Extension
{
    public static void PolarCoord(this Transform transform, float radius, float theta, Coordinate coordinate = Coordinate.World) 
    {
        Vector2 coord = new Vector2(Mathf.Sin(theta) * radius, Mathf.Cos(theta) * radius);

        switch (coordinate)
        {
            case Coordinate.World:

                transform.position = coord;
                break;

            case Coordinate.Local:

                transform.localPosition = coord;
                break;
        }
    }
}

public class PolarCoord : MonoBehaviour
{
    [SerializeField] private Shapes RenderShape;
    [SerializeField] private Coordinate Coordinate;

    [Space()]
    [SerializeField] private float MoveAccel;
    [SerializeField] private float Radius;

    private float mTime;

    private void Start()
    {
        mTime = 0;
    }

    private void Update() {
        mTime += Time.deltaTime * Time.timeScale * MoveAccel;

        switch (RenderShape)
        {
            case Shapes.Shape0:
                transform.PolarCoord(Radius, mTime, Coordinate);
                break;

            case Shapes.Shape1:
                transform.PolarCoord(Radius * Mathf.Cos(Time.time * 2f), mTime, Coordinate);
                break;

            case Shapes.Shape2:
                transform.PolarCoord(Radius * Mathf.Cos(Time.time * 2f) * Mathf.Sin(Time.time * 0.4f), mTime, Coordinate);
                break;

            case Shapes.Shape3:
                transform.PolarCoord(Radius * Mathf.Cos(Time.time * 2f) * Mathf.Sin(Time.time), mTime, Coordinate);
                break;

            case Shapes.Shape4:
                transform.PolarCoord(Radius * Mathf.Cos(Time.time * 2f) * Mathf.Sin(Time.time) * 0.4f + 5f, mTime, Coordinate);
                break;

            case Shapes.Shape5:
                transform.PolarCoord(Radius * Mathf.Cos(Time.time * 2.2f) * Mathf.Sin(Time.time) * 0.4f + 5f, mTime, Coordinate);
                break;

            case Shapes.Shape6:
                transform.PolarCoord(Radius * Mathf.Cos(Time.time * 2f) * Mathf.Sin(Time.time) * Mathf.Sin(Time.time * 3f), mTime, Coordinate);
                break;
        }
    }
}
