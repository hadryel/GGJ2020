using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLight : MonoBehaviour
{
    void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
