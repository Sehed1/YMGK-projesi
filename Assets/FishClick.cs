using UnityEngine;
using System.Collections;

public class FishClick : MonoBehaviour
{
    public UIManager uiManager;
    public QuizSystem quizManager;

    private AudioSource currentAudio;
    private Coroutine currentCoroutine;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        if (cam == null)
        {
            Debug.LogError("Camera component NOT FOUND ❌");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cam == null)
                return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                FishInfo info = hit.transform.GetComponentInParent<FishInfo>();

                if (info != null)
                {
                    bool isSponge = IsFromTarget(info.transform, "ImageTarget1");
                    bool isFish = IsFromTarget(info.transform, "ImageTarget");

                    // 🐟 فقط السمك يظهر المعلومات
                    if (isFish && !isSponge)
                    {
                        if (uiManager != null)
                            uiManager.ShowInfo(info);
                    }
                    else
                    {
                        if (uiManager != null)
                            uiManager.Hide();
                    }

                    AudioSource audio = info.GetComponent<AudioSource>();

                    if (audio != null && info.voiceClip != null)
                    {
                        // إيقاف الصوت السابق
                        if (currentAudio != null && currentAudio.isPlaying)
                            currentAudio.Stop();

                        // إيقاف الكوروتين السابق
                        if (currentCoroutine != null)
                            StopCoroutine(currentCoroutine);

                        // تشغيل الصوت
                        audio.clip = info.voiceClip;
                        audio.Play();

                        currentAudio = audio;

                        // 🧽 فقط سبونج بوب → كويز
                        if (isSponge)
                        {
                            Debug.Log("SPONGE TARGET DETECTED ✅");

                            if (quizManager != null)
                            {
                                currentCoroutine =
                                    StartCoroutine(PlaySpongeFlow(audio, info));
                            }
                            else
                            {
                                Debug.LogError("QuizManager NOT assigned ❌");
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator PlaySpongeFlow(AudioSource audio, FishInfo info)
    {
        while (audio != null && audio.isPlaying)
        {
            yield return null;
        }

        Debug.Log("SHOW ANSWERS NOW 🔥");

        if (quizManager != null)
        {
            quizManager.ShowAnswers(
                info.correctAnswer,
                info.answerA,
                info.answerB
            );
        }
    }

    bool IsFromTarget(Transform t, string targetName)
    {
        while (t != null)
        {
            if (t.name.Contains(targetName))
                return true;

            t = t.parent;
        }

        return false;
    }
}