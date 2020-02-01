using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAction : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Player>().DropCarried(Target);
            enabled = false;
        }
    }
}
