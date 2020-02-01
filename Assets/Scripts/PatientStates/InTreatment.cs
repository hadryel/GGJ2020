using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTreatment : MonoBehaviour
{
    float lifeTime = 5f;

    void Start()
    {

    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
            GetComponent<Patient>().treated = true;

            enabled = false;
        }
    }
}
