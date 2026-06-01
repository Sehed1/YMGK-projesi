using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public AudioSource sound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                CharacterInteraction character = hit.transform.GetComponentInParent<CharacterInteraction>();

                if (character != null)
                {
                    if (character.sound != null)
                        character.sound.Play();  // 🔥 المهم هنا
                }
            }
        }
    }
}