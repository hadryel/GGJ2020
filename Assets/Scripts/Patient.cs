using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public bool treated;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CarryAction>().enabled)
            return;

        other.GetComponent<CarryAction>().Target = this.gameObject;
        other.GetComponent<CarryAction>().enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<CarryAction>().Target = null;
        other.GetComponent<CarryAction>().enabled = false;
    }

    public void Treat(Medicine medicine)
    {
        GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
        treated = true;

        GameObject.Destroy(medicine.gameObject);
    }
}
