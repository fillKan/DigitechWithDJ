using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHere : MonoBehaviour
{
    [SerializeField]
    private float Offset;

    private Vector3 MousePoint
    { get => Camera.main.ScreenToWorldPoint(Input.mousePosition); }

    private void Update()
    {
        float angle = (Mathf.Atan2(MousePoint.x - transform.localPosition.x, MousePoint.y - transform.localPosition.y) + Offset) * Mathf.Rad2Deg;

        Debug.Log(angle);
        transform.localRotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
