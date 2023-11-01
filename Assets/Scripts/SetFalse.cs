using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFalse : MonoBehaviour
{

    public float time;
    private void Start()
    {
        Invoke("False", time);
    }

    void False()
    {
        gameObject.SetActive(false);
    }
}
