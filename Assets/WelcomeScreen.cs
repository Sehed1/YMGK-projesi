using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{
    public GameObject welcomePanel;

    void Start()
    {
        Invoke("HideWelcome", 4f);
    }

    void HideWelcome()
    {
        welcomePanel.SetActive(false);
    }
}