using UnityEngine;
using Unity.VectorGraphics;

public class DynamicPattern : MonoBehaviour
{
    [SerializeField][Range(0.001f, 3f)]
    private float Amplitude;

    [SerializeField][Range(0.001f, 3f)]
    private float Period;

    [SerializeField]
    private Vector2 Offset;

    private PathProperties PathProperties;

    private void Update()
    {
        transform.localPosition = SinCurve(Amplitude, Period, Offset);
    }

    private Vector3 SinCurve(float amplitude, float period, Vector3 offset)
    {
        return Vector3.up * (amplitude * Mathf.Sin(Mathf.PI * 2 * (Time.time) / period)) + offset;
    }
}
