using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;

    void Start()
    {

        SetMaxScore();
        

        var scores = scoreManager.GetHighScores().ToArray();

        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.nameRank.text = scores[i].nameRank;
            row.score.text = scores[i].score.ToString();
        }
    }

    public void SetMaxScore()
    {
        scoreManager.AddScore(new Score(PlayerPrefs.GetString("NameRank"), PlayerPrefs.GetInt("scoreMax")));

        //add set string and set int to make it work

    }
}