using UnityEngine;
using Vuforia;

public class PlayMusicOnTarget : MonoBehaviour
{
    public AudioSource music;

    void Start()
    {
        var observer = GetComponent<ObserverBehaviour>();

        observer.OnTargetStatusChanged += (behaviour, status) =>
        {
            bool isVisible = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

            if (isVisible)
            {
                if (!music.isPlaying)
                    music.Play();
            }
            else
            {
                music.Stop();
            }
        };
    }
}