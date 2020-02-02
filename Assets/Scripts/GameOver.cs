using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text YouSavedText;
    public Text YouKilledText;

    public string youSaved = "You saved {0} patients";
    public string youKilled = "And let {0} die";

    void OnEnable()
    {
        GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        int saved = gm.SaveCounter;
        int killed = gm.MaxKills;

        YouSavedText.text = string.Format(youSaved, saved);
        YouKilledText.text = string.Format(youKilled, killed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAgain()
    {
        GameObject.Find("Game Manager").GetComponent<GameManager>().Reset();

        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
