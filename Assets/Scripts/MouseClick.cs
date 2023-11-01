using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public GameObject mouse_effect;
    public Camera mainCamera;
    public AudioClip mouse_sound;
    AudioSource audiosoure;
    private void Awake()
    {
        audiosoure = gameObject.GetComponent<AudioSource>();
        audiosoure.clip = mouse_sound;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audiosoure.Play();
            if (!GameManager.isEscPanel)
            {
                Vector3 mousePosition = Input.mousePosition;
                Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
                GameObject mouse_effect2 = Instantiate(mouse_effect, worldMousePosition, Quaternion.identity);
                Destroy(mouse_effect2, 2f);
            }
        }
        
    }

}
