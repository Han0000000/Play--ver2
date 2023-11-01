using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    string last_name;
    float last_time;
    int last_stage;
    public Text txt_End;
    string txt_Endd;
    public Text txt_name;
    void Start()
    {
        last_name = Timer.name;
        last_time = Timer.all_time;
        last_stage = Timer.total_stage;
        txt_Endd = $"최종 스테이지 : {last_stage} \n 총 플레이 시간 : {Math.Round(last_time, 1)}초";
        StartCoroutine("Typing2");
    }

    private void Update()
    {
        if (last_name == null) last_name = "공백";
        txt_name.text = last_name.ToString() + "님";
        txt_Endd = $"최종 스테이지 : {last_stage} \n 총 플레이 시간 : {Math.Round(last_time, 1)}초";

    }

    IEnumerator Typing2()
    {
        int i;
        for (i = 0; i <= txt_Endd.Length; i++)
        {
            txt_End.text = txt_Endd.Substring(0, i);
            yield return new WaitForSeconds(0.08f);
        }
    }

    public void Restart()
    {
        GameObject objectToDelete = GameObject.Find("Timer");

        if (objectToDelete != null)
        {
            // 오브젝트가 찾아졌을 경우 삭제
            Destroy(objectToDelete);
        }

        SceneManager.LoadScene("MainScene");
    }
}
