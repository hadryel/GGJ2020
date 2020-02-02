using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpriteHandler : MonoBehaviour
{
    public GameObject HeadSick;
    public GameObject HeadHealth;

    public GameObject TorsoSick;
    public GameObject TorsoHealth;

    public GameObject ArmFSick;
    public GameObject ArmFHealth;

    public GameObject ArmBSick;
    public GameObject ArmBHealth;

    void Start()
    {

    }

    void OnEnable()
    {
        GetComponentInChildren<Animator>().SetBool("IsCarried", GetComponent<Patient>().treatmentStarted);
    }

    public void ChangeToHealthy(bool healthy)
    {
        HeadSick.SetActive(!healthy);
        HeadHealth.SetActive(healthy);
        TorsoSick.SetActive(!healthy);
        TorsoHealth.SetActive(healthy);
        ArmFSick.SetActive(!healthy);
        ArmFHealth.SetActive(healthy);
        ArmBSick.SetActive(!healthy);
        ArmBHealth.SetActive(healthy);
    }

    public void Die()
    {
        HeadSick.GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        HeadHealth.GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        TorsoSick.GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        TorsoHealth.GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        ArmFSick.GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        ArmFHealth.GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        ArmBSick.GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        ArmBHealth.GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
    }
}
