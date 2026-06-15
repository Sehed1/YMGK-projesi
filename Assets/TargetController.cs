using UnityEngine;
using Vuforia;

public class TargetController : MonoBehaviour
{
    public GameObject otherTarget;
    public UIManager uiManager;

    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        observer.OnTargetStatusChanged += OnStatusChanged;
    }

    void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED)
        {
            if (otherTarget != null)
                otherTarget.SetActive(false);
        }
        else
        {
            if (otherTarget != null)
                otherTarget.SetActive(true);

            // إخفاء معلومات السمكة عند فقدان التارغت
            if (uiManager != null)
                uiManager.Hide();
        }
    }
}