using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DischargeArea : MonoBehaviour, IDropTarget
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player.Carried != null && player.Carried.GetComponent<Patient>() != null && player.Carried.GetComponent<Patient>().treated)
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
        GameObject.Destroy(player.Carried);
    }
}
