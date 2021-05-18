using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Eye;

    private TraceVision mTriggerEye;

    private void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) 
        {
            if (mTriggerEye == null)
            {
                Instantiate(Eye, transform.position, Quaternion.identity);
            }
            else
            {
                mTriggerEye.CloseEyes();
                mTriggerEye = null;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Eye"))
        {
            if (collision.TryGetComponent(out TraceVision traceVision))
            {
                mTriggerEye = traceVision;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Eye"))
        {
            if (collision.TryGetComponent(out TraceVision traceVision))
            {
                if (mTriggerEye == traceVision)
                {
                    mTriggerEye = null;
                }
            }
        }
    }
}
