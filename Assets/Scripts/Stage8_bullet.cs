using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage8_bullet : MonoBehaviour
{
    public Transform player; // 따라다닐 Player의 Transform
    public float moveSpeed = 5.0f; // 이동 속도
    public Transform[] st8_spots;
    Transform furthestObject = null;
    void Update()
    {
        if (player != null)
        {
            // Player의 현재 위치를 얻어와서 따라가기
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
            // Player와 오브젝트 간의 거리를 계산
            float distance = Vector2.Distance(player.transform.position, objTransform.position);

            // 현재 오브젝트가 가장 먼 오브젝트라면 갱신
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