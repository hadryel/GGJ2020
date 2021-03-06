﻿using System.Collections;
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
            GetComponent<Patient>().treated = true;
            GetComponent<PatientSpriteHandler>().ChangeToHealthy(true);

            enabled = false;
        }
    }
}
