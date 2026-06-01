using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float speed = 1f;
    public float leftLimit = -2f;
    public float rightLimit = 2f;

    private bool goingLeft = true;

    void Update()
    {
        // الحركة
        if (goingLeft)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
            
            // إذا وصلت لليسار
            if (transform.localPosition.x <= leftLimit)
            {
                goingLeft = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(transform.right * speed * Time.deltaTime);

            // إذا وصلت لليمين
            if (transform.localPosition.x >= rightLimit)
            {
                goingLeft = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        // قلب السمكة (تعكس الاتجاه)
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}