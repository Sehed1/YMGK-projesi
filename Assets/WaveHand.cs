using UnityEngine;

public class WaveHand : MonoBehaviour
{
    public float baseRotationY = 110f;
    public float waveAmount = 20f;
    public float speed = 3f;

    private bool isWaving = false; // 🔥 حالة التشغيل

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
                // تأكد إنك ضغطت على نفس اليد أو الأب
                if (hit.transform.GetComponentInParent<WaveHand>() == this)
                {
                    isWaving = !isWaving; // 🔁 تشغيل/إيقاف
                }
            }
        }
    }
}