using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stage;
    public static bool isEscPanel = false;
    public static int mission_clear_time = 5;
    public static GameManager instance;
    public static bool isGameEnd;
    [SerializeField] GameObject esc_panel;

    private void Awake()
    {
        stage = 0;
        MissionManager.mission_count = stage;
        isEscPanel = false;
        instance = this;
        esc_panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc_panel.SetActive(!isEscPanel);
            isEscPanel = ToggleBool(isEscPanel);
        }
    }

    bool ToggleBool(bool inputBool)
    {
        return !inputBool;
    }

    public void Esc_Toggle()
    {
        esc_panel.SetActive(!isEscPanel);
        isEscPanel = ToggleBool(isEscPanel);
    }

    public void ShuffleArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int j = Random.Range(i, n);
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
