using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBed : MonoBehaviour
{
    public GameObject CurrentBed;

    float lifeTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            CurrentBed.GetComponent<OccupiedHospitalBed>().BreakBed();
            GetComponent<PatientSpriteHandler>().Die();
            enabled = false;

            // Add to minus score here
        }
    }
}
