using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentIconHandler : MonoBehaviour
{
    public bool singleTreatment;
    public GameObject SingleTreatmentIcons;
    public GameObject DoubleTreatmentIcons;

    public GameObject SingleTreatmentSlot;
    public GameObject DoubleTreatmentSlot1;
    public GameObject DoubleTreatmentSlot2;

    public GameObject[] TreatmentIcons;

    void OnEnable()
    {
        if (singleTreatment)
        {
            SingleTreatmentIcons.SetActive(true);
        }
        else
        {
            DoubleTreatmentIcons.SetActive(true);
        }
    }

    void OnDisable()
    {
        SingleTreatmentIcons.SetActive(false);
        DoubleTreatmentIcons.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
