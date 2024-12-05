using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public bool inSettings = false;
    public bool inConOrCred = false;
    public GameObject settingPanel;
    public GameObject creditsPanel;
    public GameObject controlsPanel;
    public GameObject titleMenuPanel;


    public void Settings()
    {
        settingPanel.SetActive(true);
        inSettings = true;
        inConOrCred = false;
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        titleMenuPanel.SetActive(false);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        inConOrCred = true;
        settingPanel.SetActive(false);
    }

    public void Controls()
    {
        controlsPanel.SetActive(true);
        inConOrCred = true;
        settingPanel.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Back()
    {
        titleMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
        inSettings = false;
    }
}
