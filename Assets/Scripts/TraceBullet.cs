using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceBullet : MonoBehaviour
{
    private void Update()
    {
        Vector3 MousePoint()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        Vector3 MousDir()
        {
            return MousePoint().normalized;
        }
        Vector3 dir = MousePoint() - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}
