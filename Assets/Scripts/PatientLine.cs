﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientLine : MonoBehaviour
{
    int patientCount = 0;
    public GameObject[] LinePositions;

    public GameObject Patient;

    public GameManager GameManager;

    float minimumInterval = 5f;
    float maximumInterval = 10f;

    float currentInterval;
    void Start()
    {
        currentInterval = Random.Range(minimumInterval, maximumInterval);
        minimumInterval = 10f;
        minimumInterval = 15f;
    }

    void Update()
    {
        UpdateLineTimer();

        if (LinePositions[0].transform.childCount == 0)
        {
            StartCoroutine(CycleLine());
        }
    }

    void UpdateLineTimer()
    {
        currentInterval -= Time.deltaTime;

        if (currentInterval <= 0)
        {
            if (LinePositions[4].transform.childCount > 0)
            {
                GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
                GameManager.GameOver();
            }
            else
            {
                AddPatientInLine();

                currentInterval = Random.Range(minimumInterval, maximumInterval);

                CalculateProgress();
            }
        }
    }

    public void CalculateProgress()
    {
        // Adjust timers as the player saves patients
    }

    public void AddPatientInLine()
    {
        patientCount++;

        var newPatinet = GameObject.Instantiate(Patient);
        var inBed = newPatinet.GetComponent<InBed>();

        SetTreatments(inBed);

        newPatinet.transform.parent = GetFreeLinePosition().transform;
        newPatinet.transform.position = LinePositions[4].transform.position;

        newPatinet.SetActive(true);

        StartCoroutine(RenderPatientEntrance(newPatinet));
    }

    //Set the current treatment for the new patient and progress the game
    void SetTreatments(InBed inBed)
    {
        inBed.firstTreatment = Random.Range(0, 4); //Randomize this later

        if (patientCount < 3)
        {
            // Set life spans, treatment type...
        }
        else if (patientCount < 7)
        {
            if (Random.Range(0, 2) > 1)
            {
                inBed.secondTreatment = Random.Range(0, 4); //Randomize this later

                inBed.lifeTime += Random.Range(30f, 40f);
            }
        }
        else if (patientCount < 10)
        {
            // Set life spans, treatment type...
            if (Random.Range(0, 1) > 1)
            {
                inBed.secondTreatment = Random.Range(0, 4); //Randomize this later

                inBed.lifeTime += Random.Range(20f, 40f);
            }
        }
        else if (patientCount < 15)
        {
            // Set life spans, treatment type...
            if (Random.Range(0, 1) > 1)
            {
                inBed.secondTreatment = Random.Range(0, 4); //Randomize this later

                inBed.lifeTime += Random.Range(10f, 20f);
            }
        }
        else if (patientCount < 20)
        {
            // Set life spans, treatment type...

            inBed.secondTreatment = Random.Range(0, 4); //Randomize this later

            inBed.lifeTime += Random.Range(5f, 10f);

        }

        //Updating the spawn time of patients
        if (patientCount == 1)
        {
            minimumInterval = 20f;
            minimumInterval = 30f;
        }
        else if (patientCount == 2)
        {
            minimumInterval = 20f;
            minimumInterval = 30f;
        }
        else if (patientCount == 4)
        {
            minimumInterval = 25f;
            minimumInterval = 40f;
        }
        else if (patientCount == 8)
        {
            minimumInterval = 20f;
            minimumInterval = 30f;
        }
        else if (patientCount == 10)
        {
            minimumInterval = 15f;
            minimumInterval = 30f;
        }
        else if (patientCount == 12)
        {
            minimumInterval = 15f;
            minimumInterval = 20f;
        }
        else if (patientCount == 14)
        {
            minimumInterval = 5f;
            minimumInterval = 20f;
        }
        else if (patientCount == 16)
        {
            minimumInterval = 5f;
            minimumInterval = 15f;
        }
        else
        {
            minimumInterval = 5f;
            minimumInterval = 10f;
        }
    }
    IEnumerator RenderPatientEntrance(GameObject newPatient)
    {
        newPatient.GetComponentInChildren<Animator>().SetBool("IsWalking", true);

        while (newPatient.transform.localPosition.x > 0)
        {
            newPatient.transform.localPosition += new Vector3(-1f * Time.deltaTime, 0, 0);
            yield return null;
        }

        newPatient.transform.localPosition = Vector3.zero;

        newPatient.GetComponentInChildren<Animator>().SetBool("IsWalking", false);

        newPatient.GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator CycleLine()
    {
        for (int i = 0; i < LinePositions.Length - 1; i++)
        {
            if (LinePositions[i].transform.childCount == 0 && LinePositions[i + 1].transform.childCount == 1)
            {
                GameObject patient = LinePositions[i + 1].transform.GetChild(0).gameObject;

                patient.GetComponentInChildren<Animator>().SetBool("IsWalking", true);

                patient.transform.parent = LinePositions[i].transform;

                while (patient.transform.localPosition.x > 0)
                {
                    patient.transform.localPosition += new Vector3(-1f * Time.deltaTime, 0, 0);
                    yield return null;
                }

                patient.transform.localPosition = Vector3.zero;

                patient.GetComponentInChildren<Animator>().SetBool("IsWalking", false);

                if (i == 0)
                    patient.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    public GameObject GetFreeLinePosition()
    {
        for (int i = 0; i < LinePositions.Length; i++)
        {
            if (LinePositions[i].transform.childCount == 0)
            {
                return LinePositions[i];
            }
        }

        Debug.Log("PERDEU O JOGO RERERERE!");

        return null;
    }
}
