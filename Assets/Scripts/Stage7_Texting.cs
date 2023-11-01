using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage7_Texting : MonoBehaviour
{
    [SerializeField] int text_count = 0;
    public GameObject[] obj_textingbox;
    public Sprite[] text_sprites;

    public AudioClip sound;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = sound;
    }
    private void Update()
    {
        if(MissionManager.mission_count == 7)
        {
            if(Input.GetKeyDown(KeyCode.H) && text_count == 0)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 1;
            } else if (Input.GetKeyDown(KeyCode.E) && text_count == 1)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 2;
            } else if (Input.GetKeyDown(KeyCode.L) && text_count == 2)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 3;
            } else if (Input.GetKeyDown(KeyCode.L) && text_count == 3)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 4;
            } else if (Input.GetKeyDown(KeyCode.O) && text_count == 4)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 5;
            } else if (Input.GetKeyDown(KeyCode.W) && text_count == 5)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 6;
            } else if (Input.GetKeyDown(KeyCode.O) && text_count == 6)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 7;
            } else if (Input.GetKeyDown(KeyCode.R) && text_count == 7)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 8;
            } else if (Input.GetKeyDown(KeyCode.L) && text_count == 8)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 9;
            } else if (Input.GetKeyDown(KeyCode.D) && text_count == 9)
            {
                obj_textingbox[text_count].GetComponent<SpriteRenderer>().sprite = text_sprites[text_count];
                audioSource.Play();
                text_count = 10;
            }

            if(text_count == 10)
            {
                MissionManager.mission_complicated = true;
                MissionManager.instance.Misson_End();
            }
            
        }
    }
}
