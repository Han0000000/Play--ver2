using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage10_Road : MonoBehaviour
{
    [SerializeField] int num1;
    [SerializeField] int num2;
    public int result;

    public Text txt_exam;
    public InputField input_result;
    private void Start()
    {
        num1 = Random.Range(10, 99);
        num2 = Random.Range(10, 99);
        result = num1 + num2;
        input_result.ActivateInputField();
    }

    private void Update()
    {
        txt_exam.text = $"{num1} + {num2} = ??";
        if(input_result.text == result.ToString())
        {
            MissionManager.mission_complicated = true;
            MissionManager.instance.Misson_End();
        }
    }
}
