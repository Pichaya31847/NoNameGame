using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManegerHomePage : MonoBehaviour
{
    
    public static GameManegerHomePage instance;
    [SerializeField] InputField nameInput;
    [SerializeField] private GameObject InputNameGame;
    [SerializeField] private GameObject HighScorePanel;
    public string NameText;
    public void StartGame()
    {
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        SoundManager.PlaySound("Click");
        Application.Quit();
    }

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void InputName()
    {
        SoundManager.PlaySound("Click");
        InputNameGame.SetActive(true);
    }

    public void BacktoIndex()
    {
        SoundManager.PlaySound("Click");
        InputNameGame.SetActive(false);
    }

    public void ShowHighScool()
    {
        SoundManager.PlaySound("Click");
        HighScorePanel.SetActive(true);
    }

    public void CloseHighScool()
    {
        SoundManager.PlaySound("Click");
        HighScorePanel.SetActive(false);
    }

    void Start() {
        SetNullName();
    }

    void Update() {
        if(nameInput.text != "" && nameInput.text != NameText){
            SoundManager.PlaySound("Click");
            ChangeName();
        }else if(nameInput.text == "" && NameText != "NoName"){
            SetNullName();
        }if (Input.GetKeyDown(KeyCode.Return) && InputNameGame == true){
            StartGame();
        }
    }

    public void ChangeName(){
        NameText = nameInput.text;
        Debug.Log(NameText);
    }

    public void SetNullName(){
        NameText = "NoName";
        Debug.Log(NameText);
    }
}
