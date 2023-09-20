using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreData : MonoBehaviour, IDatapersistant
{
    public Text HighscoreOutput = null;
    public Text HighscoreOutputEnd = null;
    private int HighScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.HighScore = data.HighScore;
    }

    public void SaveData(ref GameData data)
    {
        data.HighScore = this.HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.instance.score > HighScore)
        {
            this.HighScore = Score.instance.score;
            HighscoreOutput.text = HighScore.ToString();
            HighscoreOutputEnd.text = HighScore.ToString();
        }
        else
        {
            HighscoreOutput.text = HighScore.ToString();
        }
        
    }


}
