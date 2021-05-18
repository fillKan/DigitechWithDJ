using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CirclePattern : MonoBehaviour
{
    [SerializeField] private float Speed  = 1f;
    [SerializeField] private float Radius = 1f;

    private float mRunTime;
    private Vector2 mNewPos;

    private void Start()
    {
        this.UpdateAsObservable().Subscribe(o => 
        {
            mRunTime += Time.deltaTime * Time.timeScale * Speed;

            float x = Mathf.Cos(mRunTime);
            float y = Mathf.Sin(mRunTime);

            transform.position = (new Vector2(x, y)) * Radius;
        });
    }
}