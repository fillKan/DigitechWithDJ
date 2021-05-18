using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public static class AAA
{
    public static bool IsNull(this GameObject game) => game == null;

    public static bool IsVaild<T>(T instance) where T : class => instance == null;
}

public class BBB { }

public class Chapter01 : MonoBehaviour
{
    [SerializeField]
    private GameObject Capsule;

    [SerializeField]
    private float CapsuleRotationSpeed;
    [SerializeField]
    private float SphereFrequency;

    [SerializeField]
    private Vector2 SphereMagnitude;

    private GameObject Sphere;
    private Vector3 CapsuleScreenPoint
    {
        get => Camera.main.WorldToScreenPoint(Capsule.transform.position);
    }

    private float TargetAngle;
    private float ButtonDownTime;

    private void Reset()
    {
        if (!Application.isPlaying)
        {
            if (FindObjectOfType(typeof(EventSystem)) == null)
            {
                GameObject eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));

                Undo.RecordObject(eventSystem, "Add to eventSystem");
            }
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TargetAngle = PositionToAngle(Input.mousePosition);

            if (!Sphere.IsNull())
            {
                Destroy(Sphere); Sphere = null;
            }
            Sphere = SpawnSphere(Input.mousePosition);

            ButtonDownTime = Time.time;
        }
        Capsule.transform.rotation = Quaternion.Euler(
             Mathf.LerpAngle(TargetAngle, Capsule.transform.eulerAngles.x, Time.deltaTime * CapsuleRotationSpeed),
             Mathf.LerpAngle(TargetAngle, Capsule.transform.eulerAngles.y, Time.deltaTime * CapsuleRotationSpeed),
             Mathf.LerpAngle(TargetAngle, Capsule.transform.eulerAngles.z, Time.deltaTime * CapsuleRotationSpeed));

        if (!Sphere.IsNull())
        {
            Sphere.transform.position = new Vector3(Sphere.transform.position.x + (Capsule.transform.position.x - Sphere.transform.position.x) * Time.deltaTime * SphereMagnitude.x,
                Mathf.Abs(Mathf.Sin((Time.time - ButtonDownTime) * Mathf.PI * 2 * SphereFrequency * SphereMagnitude.y)), 0);
        }
    }

    private GameObject SpawnSphere(Vector3 mousePoint)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Vector3 position = Camera.main.ScreenToWorldPoint(mousePoint);

        sphere.transform.position = position;

        return sphere;
    }

    private float PositionToAngle(Vector3 point)
    {
        Vector3 diff = point - CapsuleScreenPoint;

        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }
}
