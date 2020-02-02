using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyHospitalBed : MonoBehaviour, IDropTarget
{
    public bool flipped;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled)
            return;

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
        patient.GetComponent<InBed>().CurrentBed = gameObject;

        patient.transform.parent = transform;
        patient.transform.localPosition = Vector3.zero + new Vector3(-0.57f, 0.13f, 0);

        patient.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);

        GetComponent<EmptyHospitalBed>().enabled = false;
        var occupiedBed = GetComponent<OccupiedHospitalBed>();
        occupiedBed.Target = patient;
        occupiedBed.enabled = true;

        player.Carried = null;
    }
}
