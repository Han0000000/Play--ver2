using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!GameManager.isEscPanel && MissionManager.mission_count != 9)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        else if (!GameManager.isEscPanel && MissionManager.mission_count == 9)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(horizontalInput, 0) * speed * Time.deltaTime;
            transform.Translate(movement);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MissionManager.mission_count == 2 && collision.gameObject.tag == "Stage2_spot")
        {
            MissionManager.mission_complicated = true;
            MissionManager.instance.Misson_End();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(MissionManager.mission_count == 1 && collision.gameObject.tag == "Stage2_spot")
        {
            MissionManager.mission_complicated = true;
            MissionManager.instance.Misson_End();
        }
    }
    void Jump()
    {
        // 바닥에 닿아있을 때만 점프 가능하도록 체크
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        if (hit.collider != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

}
