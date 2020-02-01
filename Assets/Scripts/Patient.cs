using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour, ICarriable
{
    public bool treated;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<CarryAction>().Target = this.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CarryAction>().Target == this.gameObject)
            other.GetComponent<CarryAction>().Target = null;
    }

    public void Treat(Medicine medicine)
    {
        GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
        treated = true;

        GameObject.Destroy(medicine.gameObject);
    }

    public void Carry(Player player)
    {
        GetComponent<SpriteRenderer>().sortingOrder = 2;
        enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        transform.parent = player.CarryingSlot;
        transform.localPosition = new Vector3(0.554f, 1.029f, 0);
        transform.localRotation = Quaternion.AngleAxis(90f, Vector3.forward);
        player.Carried = this.gameObject;
    }
}
