using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistantManeger : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDatapersistant> dataPersistantOnjects;
    private fileDataHander dataHander;
    public static DataPersistantManeger instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one data");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHander = new fileDataHander(Application.persistentDataPath, fileName);
        this.dataPersistantOnjects = FindAllDataPersistantObject();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHander.Load();

        if (this.gameData == null)
        {
            Debug.Log("No data was found.");
            NewGame();
        }

        foreach(IDatapersistant dataPersistenceObj in dataPersistantOnjects){
            dataPersistenceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        foreach(IDatapersistant dataPersistenceObj in dataPersistantOnjects){
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHander.Save(gameData);
    }
    private List<IDatapersistant> FindAllDataPersistantObject(){
        IEnumerable<IDatapersistant> dataPersistantObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDatapersistant>();
        return new List<IDatapersistant>(dataPersistantObjects);
    }

    private void Update() {
        if(Typer.instance.endGame == true){
            SaveGame();
        }
    }

}
