using UnityEngine;

public class JumpBounce : MonoBehaviour
{
    public float jumpHeight = 0.3f; // ارتفاع القفزة
    public float speed = 2f;        // سرعة القفز

    private Vector3 startPos;
    private bool isJumping = false;

    void Start()
    {
        // نحفظ مكان البداية
        startPos = transform.localPosition;
    }

    void Update()
    {
        HandleClick();

        if (isJumping)
        {
            float z = startPos.z + Mathf.Abs(Mathf.Sin(Time.time * speed)) * jumpHeight;

            transform.localPosition = new Vector3(
                startPos.x,
                startPos.y,
                z
            );
        }
    }

    void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponentInParent<JumpBounce>() == this)
                {
                    isJumping = !isJumping;
                }
            }
        }
    }
}