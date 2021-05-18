using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarCoordator : MonoBehaviour
{
    private const float MIN_CAMERA_SCALE = 5.4f;

    [SerializeField]
    private float ScalingSpeed;

    private float _Theta;
    private float _Radius;

    private IEnumerator _CameraUpSizing;
    private IEnumerator _CameraDownSizing;

    private void Start()
    {
        _Theta  = 0f;
        _Radius = 0f;

        // 16 : 9 - 9.6 : 5.4
    }

    private void Update()
    {
        void Zeroing(ref float value)
        {
            value = Mathf.Max(0f, value - Time.deltaTime);
        }
        if (Input.GetMouseButton(0))
        {
            _Radius += Time.deltaTime;
             _Theta += Time.deltaTime;
        }
        else
        {
            if (_Radius > 0)
            {
                Zeroing(ref _Radius);
            }
            if (_Theta > 0)
            {
                Zeroing(ref _Theta);
            }
        }
        transform.PolarCoord(_Radius, _Theta, Coordinate.Local);

        if (transform.position.y > +Camera.main.orthographicSize ||
            transform.position.y < -Camera.main.orthographicSize ||
            transform.position.x > +Camera.main.orthographicSize * 1.77777f ||
            transform.position.x < -Camera.main.orthographicSize * 1.77777f)
        {
            if (_CameraDownSizing != null)
            {
                StopCoroutine(_CameraDownSizing); _CameraDownSizing = null;
            }
            StartCoroutine(_CameraUpSizing = CameraSizing(Camera.main.orthographicSize * 2f));
        }
        // else if (Camera.main.orthographicSize > MIN_CAMERA_SCALE)
        // {
        //     if (transform.position.y > +Camera.main.orthographicSize * 0.5f ||
        //         transform.position.y < -Camera.main.orthographicSize * 0.5f ||
        //         transform.position.x > +Camera.main.orthographicSize * 0.888885f ||
        //         transform.position.x < -Camera.main.orthographicSize * 0.888885f)
        //     {
        //         if (_CameraUpSizing != null)
        //         {
        //             StopCoroutine(_CameraUpSizing); _CameraUpSizing = null;
        //         }
        //         StartCoroutine(_CameraDownSizing = CameraSizing(Camera.main.orthographicSize * 0.5f));
        //     }
        // }
    }
    private IEnumerator CameraSizing(float size)
    {
        for (float ratio = 0f; ratio < 1f; ratio += Time.deltaTime * ScalingSpeed)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, size, ratio);

            yield return null;
        }
        _CameraDownSizing = null;
        _CameraUpSizing = null;
    }
}
