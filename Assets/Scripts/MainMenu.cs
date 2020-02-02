using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayGame()
    {
        var gm = GameObject.Find("Game Manager");

        if (gm != null)
            gm.GetComponent<GameManager>().Reset();

        SceneManager.LoadScene("GameScene");
    }
}
