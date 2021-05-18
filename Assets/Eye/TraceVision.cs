using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceVision : MonoBehaviour
{
    [Header("Trace Info")]
    [SerializeField] private float Radius;
    [SerializeField] private Transform Pupil;

    private Vector3 MousePoint
    { get => Camera.main.ScreenToWorldPoint(Input.mousePosition); }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void CloseEyes()
    {
        if (gameObject.TryGetComponent(out Animator animator))
        {
            animator.SetBool(animator.GetParameter(0).nameHash, true);
        }
    }

    private void Update()
    {
        Vector2 direction = (MousePoint - Pupil.localPosition).normalized;

        Pupil.localPosition = direction * Radius;
    }
}
