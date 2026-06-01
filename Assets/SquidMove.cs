using UnityEngine;

public class SquidMove : MonoBehaviour
{
    public float speed = 1f;      // سرعة الحركة
    public float height = 0.5f;   // مدى الحركة

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * height;
        transform.localPosition = startPos + new Vector3(0, y, 0);
    }
}