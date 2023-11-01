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
            // ������Ʈ�� ã������ ��� ����
            Destroy(objectToDelete);
        }

        SceneManager.LoadScene("MainScene");
    }
}
