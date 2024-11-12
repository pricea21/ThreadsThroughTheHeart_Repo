using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
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
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        settingPanel.SetActive(false);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
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
        pausePanel.SetActive(false);
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        settingPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void Controls()
    {
        controlsPanel.SetActive(true);
        settingPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
}
