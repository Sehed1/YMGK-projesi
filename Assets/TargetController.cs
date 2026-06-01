using UnityEngine;
using Vuforia;

public class TargetController : MonoBehaviour
{
    public GameObject otherTarget; // الهدف الثاني

    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        observer.OnTargetStatusChanged += OnStatusChanged;
    }

    void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            // 🔥 لما هذا يظهر → نخفي الثاني
            if (otherTarget != null)
                otherTarget.SetActive(false);
        }
        else
        {
            // 🔥 لما يختفي → نرجع الثاني
            if (otherTarget != null)
                otherTarget.SetActive(true);
        }
    }
}