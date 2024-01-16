using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;
    public static MapGenerator instance;
    private LinkedList<GameObject> platforms = new LinkedList<GameObject>();
    private int posx = 0;

    [SerializeField] private GameObject bgPrefab;
    private LinkedList<GameObject> bgs = new LinkedList<GameObject>();
    private int posbgx = 45;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(platformPrefab, platformPrefab.transform.position + new Vector3(posx, 0, 0), Quaternion.identity);
            platforms.AddLast(go);
            posx += 7;
        }
    }

    public void AddMap(int score)
    {
        if (score > 3)
        {
            GameObject go = Instantiate(platformPrefab, platformPrefab.transform.position + new Vector3(posx, 0, 0), Quaternion.identity);
            platforms.AddLast(go);
            posx += 7;
            Destroy(platforms.First.Value, 0);
            platforms.RemoveFirst();

            if ((score + 2) %6 == 0)
            {
                go = Instantiate(bgPrefab, bgPrefab.transform.position + new Vector3(posbgx, 0, 0), Quaternion.identity);
                bgs.AddLast(go);
                posbgx += 45;

                if(bgs.Count > 10){
                    Destroy(bgs.First.Value, 0);
                    bgs.RemoveFirst();
                }
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

}
