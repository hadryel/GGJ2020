using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineCabinet : MonoBehaviour, IDropTarget
{
    public GameObject Medicine;

    void Awake()
    {
        GetComponentInChildren<Medicine>(true).MedicineCabinet = this;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        ActivateLogic(player);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CarryAction>().Target == Medicine)
            other.GetComponent<CarryAction>().Target = null;
        else if (other.GetComponent<DropAction>().Target == this.gameObject)
            other.GetComponent<DropAction>().Target = null;
    }

    public void ActivateLogic(Player player)
    {
        if (player.Carried && player.Carried.GetComponent<Patient>() != null)
            return;
        else if (player.Carried != null && player.Carried.GetComponent<Medicine>() != null)
        {
            var dropAction = player.GetComponent<DropAction>();
            dropAction.enabled = false;
            dropAction.Target = this.gameObject;
            dropAction.enabled = true;
        }
        else
        {
            var carryAction = player.GetComponent<CarryAction>();
            carryAction.enabled = false;
            carryAction.Target = Medicine;
            carryAction.enabled = true;
        }
    }

    public void Drop(Player player)
    {
        var medicine = player.Carried;
        player.Carried = null;

        GameObject.Destroy(medicine.gameObject);

        player.GetComponent<DropAction>().Target = null;

        ActivateLogic(player);
    }
}
