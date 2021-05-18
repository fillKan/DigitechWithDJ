using UnityEngine;

public struct Box
{
    public Transform transform;
    public SpriteRenderer renderer;
}

public class CursorBoxSizing : MonoBehaviour
{
    [SerializeField] private bool UnUsingCloudy;
    [SerializeField] private Transform[] BoxTransforms;

    [SerializeField] private float CursorScale;

    [Header("Scaling Info")]
    [SerializeField] private float MinScale;
    [SerializeField] private float MaxScale;

    private Box[] Boxes;
    private Vector3 CursorPoint
    { get => Camera.main.ScreenToWorldPoint(Input.mousePosition); }


    private void Awake()
    {
        Boxes = new Box[BoxTransforms.Length];

        for (int i = 0; i < BoxTransforms.Length; i++)
        {
            if (BoxTransforms[i].TryGetComponent(out SpriteRenderer renderer)) {
                Boxes[i] = new Box() 
                {
                     renderer = renderer,
                    transform = BoxTransforms[i] 
                };
            }
        }
    }

    private void Update()
    {
        foreach (Box box in Boxes) {

            float distance 
                = Mathf.Max(Vector2.Distance(box.transform.position, CursorPoint) - CursorScale, 0f);

            float sclae
                = Mathf.Max(MaxScale - distance, MinScale);

            box.transform.localScale = Vector2.one * sclae;

            if (!UnUsingCloudy)
            {
                box.renderer.color = new Color(1, 1, 1, Mathf.Max(MaxScale - distance, 0.15f));
            }
            
        }
    }
}
