using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip correctSound,oofSound,ClickSound,gameoversound,Lavasound,ThemeSong1;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {   
        correctSound = Resources.Load<AudioClip> ("correct");
        oofSound = Resources.Load<AudioClip> ("oof");
        ClickSound = Resources.Load<AudioClip> ("Click");
        gameoversound = Resources.Load<AudioClip> ("gameover");
        Lavasound = Resources.Load<AudioClip> ("LavaSpawn");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip){
            case "correct":
                audioSrc.PlayOneShot (correctSound);
                break;
            case "oof":
                audioSrc.PlayOneShot (oofSound);
                break;
            case "Click":
                audioSrc.PlayOneShot (ClickSound);
                break;
            case "gameover":
                audioSrc.PlayOneShot (gameoversound);
                break;
            case "LavaSpawn":
                audioSrc.PlayOneShot (Lavasound);
                break;
        }
    }
}
