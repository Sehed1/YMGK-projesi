using UnityEngine;

public class FishMove2 : MonoBehaviour
{
    public float speed = 1f;
    public float leftLimit = -2f;
    public float rightLimit = 2f;

    private bool goingRight = true; // يبدأ نحو اليمين

    void Update()
    {
        if (goingRight)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);

            // وصل لليمين
            if (transform.localPosition.x >= rightLimit)
            {
                goingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);

            // رجع لليسار
            if (transform.localPosition.x <= leftLimit)
            {
                goingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}