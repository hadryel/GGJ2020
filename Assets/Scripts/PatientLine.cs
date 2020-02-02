using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientLine : MonoBehaviour
{
    public GameObject[] LinePositions;

    public GameObject Patient;

    public GameManager GameManager;

    float minimumInterval = 10f;
    float maximumInterval = 20f;

    float currentInterval;
    void Start()
    {
        currentInterval = Random.Range(minimumInterval, maximumInterval);
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
        var newPatinet = GameObject.Instantiate(Patient);
        var inBed = newPatinet.GetComponent<InBed>();
        // Set life spans, treatment type...
        inBed.firstTreatment = Random.Range(0, 4); //Randomize this later

        //Randomize to see if is 2 treatments
        inBed.secondTreatment = Random.Range(0, 4);

        newPatinet.transform.parent = GetFreeLinePosition().transform;
        newPatinet.transform.position = LinePositions[4].transform.position;

        newPatinet.SetActive(true);

        StartCoroutine(RenderPatientEntrance(newPatinet));
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
