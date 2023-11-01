using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5_rhythm : MonoBehaviour
{
    public KeyCode key;
    Rigidbody2D rb;
    public static Stage5_rhythm instance;
    public GameObject effect;
    public Transform[] rand;
    int movespeed;
    public int temp;

    public Transform[] trans_succes;

    public AudioClip mouse_sound;
    AudioSource audiosoure;
    private void Awake()
    {
        instance = this;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        movespeed = 7; 
        audiosoure = gameObject.GetComponent<AudioSource>();
        audiosoure.clip = mouse_sound;
    }

    private void Start()
    {
        gameObject.transform.position = rand[temp].position;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, -movespeed * Time.deltaTime, 0);
        transform.Translate(movement);
    }

    private void Update()
    {
        if (trans_succes[0].position.y < gameObject.transform.position.y && trans_succes[1].position.y > gameObject.transform.position.y
            && Input.GetKeyDown(key))
        {
            MissionManager.rythm_count++;
            Vector3 vec3_pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z);
            Instantiate(effect, vec3_pos, Quaternion.identity);
            Destroy(gameObject);
        }

        if(trans_succes[2].position.y > gameObject.transform.position.y)
        {
            MissionManager.instance.Misson_End();
        }
    }

    /*
     private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(key) && collision.gameObject.tag == "Stage5_btn")
        {
            audiosoure.Play();
            MissionManager.rythm_count++;
            Vector3 vec3_pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z);
            Instantiate(effect, vec3_pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(key) && collision.gameObject.tag == "Stage5_btn")
        {
            audiosoure.Play();
            MissionManager.rythm_count++;
            Vector3 vec3_pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z);
            Instantiate(effect, vec3_pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
     */
}
