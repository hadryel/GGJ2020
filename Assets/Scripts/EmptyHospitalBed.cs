using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyHospitalBed : MonoBehaviour, IDropTarget
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
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player.GetComponent<DropAction>().Target == this.gameObject)
        {
            var dropAction = player.GetComponent<DropAction>();
            dropAction.Target = null;
        }
    }

    public void Drop(Player player)
    {
        var patient = player.Carried;

        patient.GetComponent<InLine>().enabled = false;
        patient.GetComponent<InBed>().enabled = true;

        patient.transform.parent = transform;
        patient.transform.localPosition = Vector3.zero + new Vector3(0.5f, 0, 0);
        GetComponent<EmptyHospitalBed>().enabled = false;
        var occupiedBed = GetComponent<OccupiedHospitalBed>();
        occupiedBed.Target = patient;
        occupiedBed.enabled = true;
    }
}
