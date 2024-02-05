using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void MainMenuLoader()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HighScoresLoader()
    {
        if(playerStats != null)
        {
            if (playerStats.GetComponent<PlayerStats>().GetHealth() == 0)
            {
                SceneManager.LoadScene("HighScores");
            }
        }
    }
}
