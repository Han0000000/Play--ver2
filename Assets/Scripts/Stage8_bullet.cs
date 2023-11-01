using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage8_bullet : MonoBehaviour
{
    public Transform player; // ����ٴ� Player�� Transform
    public float moveSpeed = 5.0f; // �̵� �ӵ�
    public Transform[] st8_spots;
    Transform furthestObject = null;
    void Update()
    {
        if (player != null)
        {
            // Player�� ���� ��ġ�� ���ͼ� ���󰡱�
            Vector3 targetPosition = player.position;
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }
    private void Start()
    {
        Spawn();
        gameObject.transform.position = furthestObject.position;
    }

    void Spawn()
    {
        float maxDistance = float.NegativeInfinity;

        foreach (Transform objTransform in st8_spots)
        {
            // Player�� ������Ʈ ���� �Ÿ��� ���
            float distance = Vector2.Distance(player.transform.position, objTransform.position);

            // ���� ������Ʈ�� ���� �� ������Ʈ��� ����
            if (distance > maxDistance)
            {
                maxDistance = distance;
                furthestObject = objTransform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MissionManager.mission_complicated = false;
            MissionManager.instance.Misson_End();
        }
    }
}