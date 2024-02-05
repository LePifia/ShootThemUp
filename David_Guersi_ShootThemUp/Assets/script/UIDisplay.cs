using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{

    //Health
    [SerializeField] Slider healthslider;
    [SerializeField] PlayerStats playerHealth;

    //Score
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreKeeper scoreKeeper;

    //Wave
    [SerializeField] TextMeshProUGUI waveText;

    //NaME
    [SerializeField] TextMeshProUGUI namer;
    [SerializeField] NameSet nameSet;

    //Bomb
    [SerializeField] PlayerShooter PlayerShooter;
    [SerializeField] Slider BombSlider;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerStats>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        PlayerShooter = FindObjectOfType<PlayerShooter>();
    }

    void Start()
    {
        healthslider.maxValue = playerHealth.GetHealth();
        BombSlider.maxValue = PlayerShooter.GetBombCooldown();
    }

    
    void Update()
    {
        healthslider.value = playerHealth.GetHealth();
        BombSlider.value = PlayerShooter.GetBombDelayement();
        scoreText.text = scoreKeeper.GetScore().ToString();
        waveText.text = scoreKeeper.GetWave().ToString();
        namer.text = nameSet.Name().ToString();

        PlayerPrefs.SetInt("scoreMax", scoreKeeper.GetScore());

    }
}
