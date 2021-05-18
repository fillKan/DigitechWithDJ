using UnityEngine;

public class MouseClick : MonoBehaviour
{
    private int mClickCount;

    [SerializeField]
    private float  WaitBuffer;
    private float mLastClickTime;

    private Vector3[] mClickPoint;

    private void Start()
    {
        mClickCount = 0;
        mLastClickTime = 0f;

        mClickPoint = new Vector3[2];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - mLastClickTime > WaitBuffer)
                mClickCount = 0;

            mClickCount++;

            switch (mClickCount)
            {
                case 1:
                    {
                        mLastClickTime = Time.time;
                        Debug.Log("One Click");
                    }
                    break;
                case 2:
                    {
                        mClickCount = 0;
                        Debug.Log("Double Click");
                    }
                    break;
            }
        }
    }
}
