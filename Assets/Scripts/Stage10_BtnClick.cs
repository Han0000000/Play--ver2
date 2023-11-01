using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage10_BtnClick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MissionManager.mission_complicated = true;
            MissionManager.instance.Misson_End();
        }
    }


}
