﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineCabinet : MonoBehaviour
{
    public GameObject Medicine;

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.GetComponent<CarryAction>().enabled)
        //     return;

        other.GetComponent<CarryAction>().Target = Medicine;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CarryAction>().Target == Medicine)
            other.GetComponent<CarryAction>().Target = null;
    }
}
