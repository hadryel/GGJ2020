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
}
