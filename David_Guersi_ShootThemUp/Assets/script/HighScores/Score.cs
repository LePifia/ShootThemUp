using System;

[Serializable]
public class Score
{
    public string nameRank;
    public int score;

    public Score (String nameRank , int score)
    {
        this.nameRank = nameRank;
        this.score = score;
    }

}
