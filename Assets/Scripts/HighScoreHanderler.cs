using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHanderler : MonoBehaviour
{
    public static Score instance;
    List<HighScoreElement> highScoresList = new List<HighScoreElement>();
    [SerializeField] int maxCount = 7;
    [SerializeField] string filename;

    public delegate void OnHighscoreListChanged(List<HighScoreElement> list);
    public static event OnHighscoreListChanged onHighscoreListChanged;
    private void Start()
    {
        LoadHighscores();
    }

    private void LoadHighscores()
    {
        highScoresList = FileHandler.ReadListFromJSON<HighScoreElement>(filename);

        while (highScoresList.Count > maxCount)
        {
            highScoresList.RemoveAt(maxCount);
        }

        if (onHighscoreListChanged != null)
        {
            onHighscoreListChanged.Invoke(highScoresList);
        }
    }

    private void SaveHighscores()
    {
        FileHandler.SaveToJSON<HighScoreElement>(highScoresList, filename);
    }

    public void AddHighScoreToList(HighScoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= highScoresList.Count || element.Point > highScoresList[i].Point)
            {
                highScoresList.Insert(i, element);

                while (highScoresList.Count > maxCount)
                {
                    highScoresList.RemoveAt(maxCount);
                }

                SaveHighscores();

                if (onHighscoreListChanged != null)
                {
                    onHighscoreListChanged.Invoke(highScoresList);
                }
                break;
            }
        }
    }

    public void AddHighscoreIfPossible(HighScoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= highScoresList.Count || element.Point > highScoresList[i].Point)
            {
                highScoresList.Insert(i, element);

                while (highScoresList.Count > maxCount)
                {
                    highScoresList.RemoveAt(maxCount);
                }

                SaveHighscores();
                break;
            }
        }
    }
    
}
