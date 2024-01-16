using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private GameObject AlertText;
    [SerializeField] private GameObject PauseMenu;
    private int hintss = 1;
    public static bool GameIsPause = false;
    public Text ScoreLast = null;
    private int ScoreLastsInt = 0;

    void Update()
    {
        ScoreLastsInt = Score.instance.score;
        ScoreLast.text = ScoreLastsInt.ToString()+"#";
        if (Score.instance.score == 9 && hintss == 1)
        {
            AlertText.SetActive(true);
            SoundManager.PlaySound("LavaSpawn");
            hintss += 1;
        }
        else if (Score.instance.score == 10)
        {
            AlertText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Typer.instance.endGame == false)
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void RestartGame()
    {
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene("GameScene");
    }

    public void RestartButtons(){
        Resume();
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene("GameScene");
    }

    public void Resume(){
        SoundManager.PlaySound("Click");
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause(){
        SoundManager.PlaySound("Click");
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void GoHomePages()
    {
        SoundManager.PlaySound("Click");
        Resume();
        SceneManager.LoadScene("MainPage");
    }
}
