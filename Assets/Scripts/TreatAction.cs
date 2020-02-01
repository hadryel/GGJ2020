using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatAction : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Player>().TreatTarget(Target);
            enabled = false;
        }
    }
}
