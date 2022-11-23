using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject optionsMenu;

    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!pause) OpenMenu();
            else CloseMenu();
        }
    }

    public void StartGame()
    {
        CloseMenu();
        pause = false;
    }
    public void OpenMenu()
    {
        Debug.Log("Abrir Menu");
        Time.timeScale = 0;
        pause = true;
        gameMenu.SetActive(true);
        CloseOptions();
    }
    public void CloseMenu()
    {
        Debug.Log("Cerrando menu");
        Time.timeScale = 1;
        pause = false;
        gameMenu.SetActive(false);
    }
    public void OpenOptions()
    {
        Debug.Log("Abriendo Menu");
        gameMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void CloseOptions()
    {
        gameMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void CloseGame()
    {
        Debug.Log("Cerrar juego");
        Application.Quit();
    }

}
