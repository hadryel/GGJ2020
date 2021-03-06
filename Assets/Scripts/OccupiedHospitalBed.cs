﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedHospitalBed : MonoBehaviour
{
    // The treatment target
    public GameObject Target;
    public GameObject Tape;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled)
            return;

        var player = other.GetComponent<Player>();

        Medicine medicine = null; // The true Jam logic

        if (player.Carried != null)
            medicine = player.Carried.GetComponent<Medicine>();

        if (player.Carried != null && medicine != null && IsMedicineCompatible(medicine))
        {
            var treatAction = player.GetComponent<TreatAction>();
            treatAction.Target = Target;
            treatAction.enabled = true;
        }
        else if (Target != null && Target.GetComponent<Patient>().treated)
        {
            player.GetComponent<CarryAction>().Target = Target;
            player.GetComponent<CarryAction>().enabled = true;
            GetComponent<EmptyHospitalBed>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player.GetComponent<TreatAction>().Target == Target)
        {
            var treatAction = player.GetComponent<TreatAction>();
            treatAction.Target = null;
        }
        else if (player.GetComponent<CarryAction>().Target == Target)
        {
            player.GetComponent<CarryAction>().Target = null;
        }
    }

    public void BreakBed()
    {
        Target.GetComponent<Patient>().GameManager.KillPatient();

        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<EmptyHospitalBed>().enabled = false;
        enabled = false;
        Tape.SetActive(true);
    }

    bool IsMedicineCompatible(Medicine medicine)
    {
        var inBed = Target.GetComponent<InBed>();

        return medicine.currentMedicine == inBed.firstTreatment || medicine.currentMedicine == inBed.secondTreatment;
    }
}
