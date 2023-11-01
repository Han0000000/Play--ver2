using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public InputField input_name;

    private void Awake()
    {
        GameManager.isGameEnd = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && input_name.text != "")
        {
            Timer.name = input_name.text;
            GameManager.isGameEnd = false;
            SceneManager.LoadScene("GameScene");
        }
    }
}
