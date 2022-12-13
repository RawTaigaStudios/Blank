using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject soundMenu;
    [SerializeField] GameObject bindingMenu;

    [SerializeField] private InputActionReference pauseAction;
    //[SerializeField] private PlayerInput playerInput;
    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        gameMenu.SetActive(false);
        soundMenu.SetActive(false);
        bindingMenu.SetActive(false);
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAction.action.triggered)
        {
            onPause();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void onPause()
    {
        if (!pause) OpenMenu();
        else ContinueGame();
    }
    public void ContinueGame()
    {
        Debug.Log("Resume");
        pause = false;
        Time.timeScale = 1;
        gameMenu.SetActive(false);
        soundMenu.SetActive(false);
        bindingMenu.SetActive(false);
    }
    public void OpenMenu()
    {
        Debug.Log("Pause");
        Time.timeScale = 0;
        pause = true;
        gameMenu.SetActive(true);
        soundMenu.SetActive(false);
        bindingMenu.SetActive(false);
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

}
