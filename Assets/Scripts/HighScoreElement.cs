using System;

[Serializable]
public class HighScoreElement 
{
    public string playerName;
    public int Point;

    public HighScoreElement(string name ,int points){
        this.playerName = name;
        this.Point = points;
    }
}
