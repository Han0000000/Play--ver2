using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Timer : MonoBehaviour
{
    public static float time;
    public static float all_time;
    public static int total_stage;
    public static string name;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        time = GameManager.mission_clear_time;
    }
    private void Update()
    {
        if (!GameManager.isGameEnd)
        {
            all_time += Time.deltaTime * 1.5f;
            if (!GameManager.isEscPanel)
            {
                time -= Time.deltaTime * 1.5f;
                if (time <= 0)
                {
                    Debug.Log("¹Ì¼Ç ³¡");
                    MissionManager.instance.Misson_End();
                }
            }
        }
    }
}
