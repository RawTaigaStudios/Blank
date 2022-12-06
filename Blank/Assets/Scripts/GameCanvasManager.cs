using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject soundMenu;
    [SerializeField] GameObject bindingMenu;


    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        gameMenu.SetActive(false);
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!pause) OpenMenu();
            else ContinueGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ContinueGame()
    {
        pause = false;
        Time.timeScale = 1;
        gameMenu.SetActive(false);
        soundMenu.SetActive(false);
        bindingMenu.SetActive(false);
    }
    public void OpenMenu()
    {
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
