using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaEnemy : MonoBehaviour
{
    [SerializeField] HighScoreHanderler highScoreHanderler;
    [SerializeField] private GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.instance.score >= 10 && !Typer.instance.endGame){
            transform.position += Vector3.right*Score.instance.score/1800;
        }
        
    }

    public void EndGameAndSave() {
        highScoreHanderler.AddHighscoreIfPossible (new HighScoreElement (GameManegerHomePage.instance.NameText , Score.instance.score));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            EndGameAndSave();
            SoundManager.PlaySound("gameover");
            Typer.instance.endGame = true;
            Debug.Log("End");
            restartButton.SetActive(true);
        }
    }
}
