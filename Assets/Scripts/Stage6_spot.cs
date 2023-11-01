using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage6_spot : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stage6_box")
        {
            MissionManager.mission_complicated = true;
            MissionManager.instance.Misson_End();
        }
    }
}
