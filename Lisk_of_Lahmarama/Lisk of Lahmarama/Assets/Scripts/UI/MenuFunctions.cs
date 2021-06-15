using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFunctions : MonoBehaviour
{
    public GameObject screen;
    void Start()
    {
        screen.SetActive(false);
    }
    public void closeM()
    {
        screen.SetActive(false);
    }
    public void open()
    {
        screen.SetActive(true);
    }
    public void changeScene()
    {
        SceneManager.LoadScene("PlayerTestMaze");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
