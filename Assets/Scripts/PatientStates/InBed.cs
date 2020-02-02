using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBed : MonoBehaviour
{
    public GameObject CurrentBed;

    public float lifeTime = 45f; // Randomize/Balance this - use static field to be called by GameManager or PatientLine

    public int firstTreatment = -1;
    public int secondTreatment = -1; // -1 is no treatment

    void Start()
    {

    }

    void OnEnable()
    {
        var treatmentIconHandler = CurrentBed.GetComponent<TreatmentIconHandler>();

        if (secondTreatment >= 0)
        {
            treatmentIconHandler.singleTreatment = false;

            // Jam logic, extract to a function one day :(
            if (treatmentIconHandler.DoubleTreatmentSlot1.transform.childCount == 0)
            {
                var treatmentIcon = GameObject.Instantiate(treatmentIconHandler.TreatmentIcons[firstTreatment]);
                treatmentIcon.transform.parent = treatmentIconHandler.DoubleTreatmentSlot1.transform;
                treatmentIcon.transform.localPosition = Vector3.zero;
            }
            else
            {
                var treatmentIconTransform = treatmentIconHandler.DoubleTreatmentSlot1.transform.GetChild(0);
                treatmentIconTransform.GetComponent<SpriteRenderer>().sprite = treatmentIconHandler.TreatmentIcons[firstTreatment].GetComponent<SpriteRenderer>().sprite;
                treatmentIconTransform.localPosition = Vector3.zero;
            }

            if (treatmentIconHandler.DoubleTreatmentSlot2.transform.childCount == 0)
            {
                var treatmentIcon = GameObject.Instantiate(treatmentIconHandler.TreatmentIcons[secondTreatment]);
                treatmentIcon.transform.parent = treatmentIconHandler.DoubleTreatmentSlot2.transform;
                treatmentIcon.transform.localPosition = Vector3.zero;
            }
            else
            {
                var treatmentIconTransform = treatmentIconHandler.DoubleTreatmentSlot2.transform.GetChild(0);
                treatmentIconTransform.GetComponent<SpriteRenderer>().sprite = treatmentIconHandler.TreatmentIcons[secondTreatment].GetComponent<SpriteRenderer>().sprite;
                treatmentIconTransform.localPosition = Vector3.zero;
            }
        }
        else
        {
            treatmentIconHandler.singleTreatment = true;

            if (treatmentIconHandler.SingleTreatmentSlot.transform.childCount == 0)
            {
                var treatmentIcon = GameObject.Instantiate(treatmentIconHandler.TreatmentIcons[firstTreatment]);
                treatmentIcon.transform.parent = treatmentIconHandler.SingleTreatmentSlot.transform;
                treatmentIcon.transform.localPosition = Vector3.zero;
            }
            else
            {
                var treatmentIconTransform = treatmentIconHandler.SingleTreatmentSlot.transform.GetChild(0);
                treatmentIconTransform.GetComponent<SpriteRenderer>().sprite = treatmentIconHandler.TreatmentIcons[firstTreatment].GetComponent<SpriteRenderer>().sprite;
                treatmentIconTransform.localPosition = Vector3.zero;
            }
        }

        treatmentIconHandler.enabled = true;
    }

    void OnDisable()
    {
        var treatmentIconHandler = CurrentBed.GetComponent<TreatmentIconHandler>();

        treatmentIconHandler.enabled = false;

    }
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            CurrentBed.GetComponent<OccupiedHospitalBed>().BreakBed();
            GetComponent<PatientSpriteHandler>().Die();
            enabled = false;
        }
    }
}
