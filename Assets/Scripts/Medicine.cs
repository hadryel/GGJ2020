using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour, ICarriable
{
    public MedicineCabinet MedicineCabinet;

    public void Carry(Player player)
    {
        var carried = GameObject.Instantiate(this.gameObject);
        carried.transform.parent = player.CarryingSlot;
        carried.transform.localPosition = new Vector3(-0.18f, 1.1f, 0);
        carried.transform.localRotation = Quaternion.identity;
        carried.SetActive(true);
        player.Carried = carried;

        player.GetComponent<CarryAction>().Target = null;

        MedicineCabinet.ActivateLogic(player);
        // var dropAction = player.GetComponent<DropAction>();
        // dropAction.enabled = false;
        // dropAction.Target = MedicineCabinet.gameObject;
        // dropAction.enabled = true;
    }

    public void Drop(Player player, GameObject Target)
    {
        // Debug.Log("Dropou!");

        player.Carried = null;

        GameObject.Destroy(gameObject);
    }
}
