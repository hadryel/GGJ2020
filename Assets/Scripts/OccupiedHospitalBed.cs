using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedHospitalBed : MonoBehaviour
{
    public GameObject Target;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled)
            return;

        var player = other.GetComponent<Player>();

        if (player.Carried != null && player.Carried.GetComponent<Medicine>() != null)
        {
            var treatAction = player.GetComponent<TreatAction>();
            treatAction.Target = Target;
            treatAction.enabled = true;
        }
        else if (Target != null && Target.GetComponent<Patient>().treated)
        {
            player.GetComponent<CarryAction>().Target = Target;
            player.GetComponent<CarryAction>().enabled = true;
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
}
