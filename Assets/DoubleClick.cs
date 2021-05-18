using System;
using UniRx;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    private void Start()
    {
        var clickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));

        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(o => o.Count >= 2).Subscribe(o => Debug.Log($"DoubleClick-count : {o.Count}"));
    }
}
