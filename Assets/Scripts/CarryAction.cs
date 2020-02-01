using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryAction : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
        if (Target != null && Input.GetKeyDown(KeyCode.Space))
        {
            Target.GetComponent<ICarriable>().Carry(GetComponent<Player>());
        }
    }
}
