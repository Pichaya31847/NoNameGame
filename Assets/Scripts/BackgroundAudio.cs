using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    public static BackgroundAudio instance;
    public AudioSource AudioSource;
    public AudioClip AudioClip1;
    public AudioClip AudioClip2;
    public AudioClip AudioClip3;
    public AudioClip AudioClip4;
    private bool P1 = true;
    private bool P2 = true;
    private bool P3 = true;

    void Start()
    {
        AudioSource.clip = AudioClip1;
        AudioSource.Play();

    }


    void Update()
    {
        if (Score.instance.score == 50 && P1 == true)
        {
            AudioSource.clip = AudioClip2;
            AudioSource.Play();
            P1 = false;
        }
        else if (Score.instance.score == 100 && P2 == true)
        {
            AudioSource.clip = AudioClip3;
            AudioSource.Play();
            P2 = false;
        }
        else if (Score.instance.score == 1000 && P3 == true)
        {
            AudioSource.clip = AudioClip4;
            AudioSource.Play();
            P3 = false;
        }

        if(Typer.instance.endGame == true){
            AudioSource.Stop();
        }
    }

}
