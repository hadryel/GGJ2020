using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour, ICarriable
{
    public void Carry(Player player)
    {
        var carried = GameObject.Instantiate(this.gameObject);
        carried.transform.parent = player.CarryingSlot;
        carried.transform.localPosition = new Vector3(0.554f, 1.029f, 0);
        carried.transform.localRotation = Quaternion.AngleAxis(90f, Vector3.forward);
        carried.SetActive(true);
        player.Carried = carried;
    }

    public void Drop(Player player, GameObject Target)
    {
        GameObject.Destroy(gameObject);
    }
}
