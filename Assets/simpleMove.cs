using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public Transform partToMove;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponentInParent<SimpleMove>() != null)
                {
                    // حركة بسيطة (لف اليد)
                    partToMove.Rotate(0, 0, 45);
                }
            }
        }
    }
}