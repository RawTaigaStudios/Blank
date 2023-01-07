using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Tilemaps;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public static GameData instance;
    private string saveFile;

    // Create a GameData field.
    [SerializeField]private Data gameData;
    public Data _gameData { get { return gameData; } set { gameData = value; } }

    void Awake()
    {
        instance = this;

        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/gamedata.json";
        UnityEngine.Debug.Log("Path guardado en : " + saveFile);
        if (!File.Exists(saveFile))
        {
            createFile();
        }

        readFile();

        

    }

    public void readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            try
            {
                // Read the entire file and save its contents.
                string fileContents = File.ReadAllText(saveFile);

                if (fileContents.Length == 0)
                {
                    UnityEngine.Debug.Log("El fichero esta vacio");
                }
                else
                {
                    // Deserialize the JSON data 
                    //  into a pattern matching the GameData class.
                    gameData = JsonUtility.FromJson<Data>(fileContents);
                    UnityEngine.Debug.Log("El fichero se ha leido correctamente");
                }

            }
            catch
            {
                UnityEngine.Debug.Log("El fichero esta vacio");
            }

        }
        else
        {
            createFile();
            UnityEngine.Debug.Log("El fichero no  se ha encontrado");
        }
    }
    public void createFile()
    {
        File.Create(saveFile);
        gameData = new Data();
        writeFile();
        readFile();
    }
    public void writeFile()
    {
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(gameData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
        UnityEngine.Debug.Log("Fichero modificado");
    }
    /*
    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Value ++"))
        {
            gameData.maxLevel++;
        }
        if (GUI.Button(new Rect(20, 70, 80, 20), "Value --"))
        {
            gameData.maxLevel--;
        }
        if (GUI.Button(new Rect(20, 100, 80, 20), "Save Files"))
        {
            writeFile();
        }
        if (GUI.Button(new Rect(20, 130, 80, 20), "Load Files"))
        {
            readFile();
        }
        if (GUI.Button(new Rect(20, 160, 80, 20), "Reset File"))
        {
            File.Delete(saveFile);
        }
        if (GUI.Button(new Rect(20, 190, 80, 20), "Create File"))
        {
            File.Create(saveFile);
        }
        if (GUI.Button(new Rect(20, 220, 80, 20), "Show Datos guardados"))
        {
            UnityEngine.Debug.Log(gameData.ToString());
            UnityEngine.Debug.Log(gameData.music.ToString());
            UnityEngine.Debug.Log(gameData.sound.ToString());

        }
        GUI.Box(new Rect(10, 10, 100, 90), gameData.maxLevel.ToString());
    }*/
}
