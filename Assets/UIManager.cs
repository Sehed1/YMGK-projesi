using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI dangerText;

    void Start()
    {
        panel.SetActive(true);
    }
    public void ShowInfo(FishInfo info)
    {
        Debug.Log("SHOWINFO CALLED"); // 🔥

        panel.SetActive(true);

        nameText.text = info.balikAdi;
        descriptionText.text = info.aciklama;

        if (info.tehlikeliMi)
        {
            dangerText.text = "Tehlikeli :(";
            dangerText.color = Color.red;
        }
        else
        {
            dangerText.text = "Tehlikeli değil :)";
            dangerText.color = Color.green;
        }
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}