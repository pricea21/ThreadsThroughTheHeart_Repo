using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public bool InSettings = false;
    public bool InConOrCred = false;
    public GameObject pausePanel;
    public GameObject settingPanel;
    public GameObject creditsPanel;
    public GameObject controlsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();

                if (InSettings)
                {
                    Pause();

                    if (InConOrCred)
                    {
                        Settings();
                    }
                }
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        InSettings = false;
        settingPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Debug.Log("Restarting level...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Settings()
    {
        settingPanel.SetActive(true);
        InSettings = true;
        InConOrCred = false;
        pausePanel.SetActive(false);
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        InConOrCred = true;
        settingPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void Controls()
    {
        controlsPanel.SetActive(true);
        InConOrCred = true;
        settingPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
}
