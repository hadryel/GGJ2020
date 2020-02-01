using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientLine : MonoBehaviour
{

    public GameObject Patient;
    void Start()
    {
        AddPatientInLine();
        AddPatientInLine();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPatientInLine()
    {
        var newPatinet = GameObject.Instantiate(Patient);
        newPatinet.transform.parent = transform;
        newPatinet.transform.localPosition = Vector3.zero;

        // Set life spans, treatment type...

        newPatinet.SetActive(true);
    }
}
