using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientLine : MonoBehaviour
{
    public GameObject[] LinePositions;

    public GameObject Patient;
    void Start()
    {
        StartCoroutine(StartRoutine());
    }

    void Update()
    {

    }

    IEnumerator StartRoutine()
    {
        Debug.Log(Random.Range(0.5f, 1.5f));
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));

        AddPatientInLine();

        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        Debug.Log(Random.Range(0.5f, 1.5f));

        AddPatientInLine();

        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        Debug.Log(Random.Range(0.5f, 1.5f));

        AddPatientInLine();
    }

    public void AddPatientInLine()
    {
        var newPatinet = GameObject.Instantiate(Patient);

        // Set life spans, treatment type...

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
