using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int MaxKills = 5;
    public int KillCounter = 5;
    public int SaveCounter = 0;

    void Start()
    {
        KillCounter = MaxKills;
    }

    void Update()
    {

    }

    public void Reset()
    {
        SaveCounter = 0;
        KillCounter = MaxKills;
    }

    public void SavePatient()
    {
        SaveCounter++;
    }

    public void KillPatient()
    {
        KillCounter--;

        if (KillCounter <= 0)
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }
}
