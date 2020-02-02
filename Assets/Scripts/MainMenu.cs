using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Options;
    public GameObject Credits;

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

    public void ShowCredits()
    {
        Menu.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(true);
    }

    public void ShowMenu()
    {
        Options.SetActive(false);
        Credits.SetActive(false);
        Menu.SetActive(true);
    }
}
