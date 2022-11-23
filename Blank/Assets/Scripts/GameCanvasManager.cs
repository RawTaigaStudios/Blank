using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasManager : MonoBehaviour
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
        EditorSceneManager.LoadScene("Tutorial");
    }
    public void ContinueGame()
    {
        CloseMenu();
        pause = false;
    }
    public void OpenMenu()
    {
        Time.timeScale = 0;
        pause = true;
        gameMenu.SetActive(true);
        CloseOptions();
    }
    public void CloseMenu()
    {
        Time.timeScale = 1;
        pause = false;
        gameMenu.SetActive(false);
    }
    public void OpenOptions()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void CloseOptions()
    {
        gameMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void ReturnMainMenu()
    {
        EditorSceneManager.LoadScene("MenuInicial");
    }

}
