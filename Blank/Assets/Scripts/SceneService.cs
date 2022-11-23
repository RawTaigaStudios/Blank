using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneService : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    /// <summary>
    /// Start Menu Methods
    /// </summary>

    public void CloseGame()
    {
        Debug.Log("Cerrar juego");
        Application.Quit();
    }

    ///Carga de escenas

    public void LoadLevel(string level)
    {
        EditorSceneManager.LoadScene(level);
    }
}
