using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAction : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
        if (Target != null && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<Animator>().SetBool("IsCarrying", false);
            Target.GetComponent<IDropTarget>().Drop(GetComponent<Player>());
        }
        else if (Target != null && Target.GetComponent<MedicineCabinet>() != null)
        {
             // Move this logic one day - create ChangeMedicine maybe
            if (Input.GetKeyDown(KeyCode.W))
            {
                Target.GetComponent<MedicineCabinet>().CycleMedicine(GetComponent<Player>(), true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Target.GetComponent<MedicineCabinet>().CycleMedicine(GetComponent<Player>(), false);
            }
        }
    }
}
