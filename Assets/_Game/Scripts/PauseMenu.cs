using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool canPause = true;
    public static float totalTime = 0;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuObject;
    public GameObject hudObject;

    public TMP_Text timeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuObject.SetActive(false);
        hudObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //handle pause/resume with escape key
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
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

        //accumulate time and constantly update to show on HUD
        totalTime += Time.deltaTime;
        timeDisplay.text = totalTime.ToString("F2");
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

    public static void PauseBase()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        PlayerCameraRotation.unlockCursor();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        hudObject.SetActive(false);
        PauseBase();
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
        totalTime = 0;
    }

    //SettingsMenu Buttons
    public void Back()
    {
        settingsMenuObject.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
