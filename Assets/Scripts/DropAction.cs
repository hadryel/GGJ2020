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
    }
}
