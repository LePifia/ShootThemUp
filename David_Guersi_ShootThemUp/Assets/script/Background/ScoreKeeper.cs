using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    int score;
    int wave;
    [SerializeField] GameObject boss;

    [SerializeField] ScoreManager scoreManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetWave()
    {
        return wave;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ModifyCurrentWave(int value)
    {
        wave += value;
        ActivateBoss();
        Mathf.Clamp(score, 0, int.MaxValue);
        
    }

    private void ActivateBoss()
    {
        if (wave % 10 == 0)
        {
            boss.SetActive(true);
        }
    }




}
