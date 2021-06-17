using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;
    SettingsMenu settingsMenuParent;

    private void Start() {
        settingsMenuParent = GameObject.Find("SettingsCanvas").GetComponent<SettingsMenu>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(settingsMenuParent.settingsMenu.activeSelf == true)
            {
                settingsMenuParent.settingsMenu.SetActive(false);
            }
            else if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        //Debug.Log(settingsMenuParent.settingsMenu.activeSelf);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        paused = true;
    }

    public void QuitGame() 
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    public void Settings()
    {
        settingsMenuParent.settingsMenu.SetActive(true);
    }
}
