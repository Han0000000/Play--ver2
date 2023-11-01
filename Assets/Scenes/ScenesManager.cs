using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
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
