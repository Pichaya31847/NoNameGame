using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreOutput = null;
    private string remainingWord = string.Empty;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreOutput.text = score.ToString();
    }

    private void Awake() {
        instance = this;

    }

    public void SetscoreWord()
    {
        //Get word Bank
        score += 1 ;
        scoreOutput.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
