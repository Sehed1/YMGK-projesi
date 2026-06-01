using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class QuizSystem : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI resultText;

    public Image background;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI buttonAText;
    public TextMeshProUGUI buttonBText;

    public AudioSource winSound;
    public AudioSource loseSound;

    private string correctAnswer;
    private int score = 0;

    void Start()
    {
        
        panel.SetActive(false); // نخفي بالبداية
        scoreText.text = "Score: 0"; // 🔥 مهم

    }

    public void ShowAnswers(string correct, string aText, string bText)
    {
        Debug.Log("=== DEBUG START ===");

        Debug.Log("panel: " + panel);
        Debug.Log("buttonAText: " + buttonAText);
        Debug.Log("buttonBText: " + buttonBText);
        Debug.Log("resultText: " + resultText);
        Debug.Log("background: " + background);

        Debug.Log("A text: " + aText);
        Debug.Log("B text: " + bText);

        Debug.Log("=== DEBUG END ===");

        if (buttonAText != null)
            buttonAText.text = aText;

        if (buttonBText != null)
            buttonBText.text = bText;

        if (resultText != null)
            resultText.text = "";

        if (background != null)
            background.color = Color.green; // اللون الافتراضي

        correctAnswer = correct;

        if (panel != null)
            panel.SetActive(true);
    }

    public void AnswerA()
    {
        CheckAnswer("A");
    }

    public void AnswerB()
    {
        CheckAnswer("B");
    }

    void CheckAnswer(string answer)
    {
        if (answer == correctAnswer)
        {
            resultText.text = "Doğrudur!";
            background.color = Color.green;

            if (winSound != null)
            {
                winSound.Stop();   // 🔥 يمنع تكرار
                winSound.Play();   // 🔥 يشغل الصوت
            }

            score++;
            scoreText.text = "Score: " + score;
        }
        else
        {
            resultText.text = "Yanlş Cevap Seçtiniz!";
            background.color = Color.red;

            if (loseSound != null)
            {
                loseSound.Stop();
                loseSound.Play();
            }
            score --;
            scoreText.text = "Score: " + score;
        }

        StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        panel.SetActive(false);
    }
}