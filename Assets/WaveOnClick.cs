using UnityEngine;

public class WaveOnClick : MonoBehaviour
{
    public float baseRotationY = 35.7f; // حط القيمة الحالية عندك
    public float waveAmount = 25f;
    public float speed = 3f;

    private bool isWaving = false;

    void Update()
    {
        HandleClick();

        if (isWaving)
        {
            float y = baseRotationY + Mathf.Sin(Time.time * speed) * waveAmount;
            transform.localRotation = Quaternion.Euler(0, y, 0);
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
                if (hit.transform.GetComponentInParent<WaveOnClick>() == this)
                {
                    isWaving = !isWaving; // تشغيل/إيقاف
                }
            }
        }
    }
}