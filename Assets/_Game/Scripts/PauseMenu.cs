using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuObject;
    public GameObject hudObject;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //PauseMenu Buttons
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        hudObject.SetActive(true);
        settingsMenuObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        PlayerCameraRotation.lockCursor();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        hudObject.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        PlayerCameraRotation.unlockCursor();
    }

    public void LoadSettingsMenu()
    {
        Debug.Log("Loading menu");
        settingsMenuObject.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void Restart()
    {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }

    //SettingsMenu Buttons
    public void Back()
    {
        settingsMenuObject.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
