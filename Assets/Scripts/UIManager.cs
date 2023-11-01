using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    public Text txt_timer;

    public Text txt_mission;

    public Text txt_stage;

    public void Update()
    {
        txt_timer.text = Mathf.Round(Timer.time).ToString();

        txt_mission.text = MissionManager.str_mssion[MissionManager.mission_count];

        txt_stage.text = "Stage " + MissionManager.mission_count;
    }
}
