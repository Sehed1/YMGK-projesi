using UnityEngine;

public class GaryMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float moveRange = 0.5f;

    public float waveHeight = 0.05f;
    public float waveSpeed = 2f;

    private Vector3 startLocalPos;
    private bool isMoving = false;
    private int direction = -1;

    void Start()
    {
        startLocalPos = transform.localPosition;
    }

    void Update()
    {
        HandleClick();
        MoveGary();
    }

    void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponentInParent<GaryMove>() == this)
                {
                    isMoving = !isMoving;
                }
            }
        }
    }

    void MoveGary()
    {
        if (!isMoving) return;

        float leftLimit = startLocalPos.x - moveRange;
        float rightLimit = startLocalPos.x + moveRange;

        float newX = transform.localPosition.x + direction * speed * Time.deltaTime;

        // 🔁 إذا وصل الحد → يعكس الاتجاه + يقلب الشكل
        if (newX < leftLimit || newX > rightLimit)
        {
            direction *= -1;

            // 🔥 قلب غاري
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        // تموج (Z)
        float newZ = startLocalPos.z + Mathf.Sin(Time.time * waveSpeed) * waveHeight;

        transform.localPosition = new Vector3(
            newX,
            transform.localPosition.y,
            newZ
        );
    }
}