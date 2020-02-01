using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyHospitalBed : MonoBehaviour
{
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player.Carried != null && player.Carried.GetComponent<Patient>() != null)
        {
            var dropAction = player.GetComponent<DropAction>();
            dropAction.Target = this.gameObject;
            dropAction.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player.Carried != null && player.Carried.GetComponent<Patient>() != null)
        {
            var dropAction = player.GetComponent<DropAction>();
            dropAction.Target = null;
            dropAction.enabled = false;
        }
    }
}
