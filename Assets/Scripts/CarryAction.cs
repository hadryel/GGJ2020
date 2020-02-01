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
            GetComponentInChildren<Animator>().SetBool("IsCarrying", true);
            Target.GetComponent<ICarriable>().Carry(GetComponent<Player>());
        }
    }
}
