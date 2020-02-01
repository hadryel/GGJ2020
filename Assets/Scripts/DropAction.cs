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
            Target.GetComponent<IDropTarget>().Drop(GetComponent<Player>());
        }
    }
}
