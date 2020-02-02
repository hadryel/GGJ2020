using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour, ICarriable
{
    public int currentMedicine = 0;
    public Sprite[] MedicineSprites;
    public string[] MedicineNames;

    public MedicineCabinet MedicineCabinet;

    public void UpdateMedicine(bool directionUp)
    {
        currentMedicine += (directionUp) ? 1 : -1;

        if (currentMedicine < 0)
            currentMedicine += MedicineSprites.Length;
        else if (currentMedicine >= MedicineSprites.Length)
            currentMedicine = 0;

        GetComponent<SpriteRenderer>().sprite = MedicineSprites[currentMedicine];        
    }

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
    }

    public void Drop(Player player, GameObject Target)
    {
        player.Carried = null;

        GameObject.Destroy(gameObject);
    }
}
