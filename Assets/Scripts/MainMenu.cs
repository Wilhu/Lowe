using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsmenu;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && settingsmenu.activeInHierarchy)
        {
            settingsmenu.SetActive(false);
        }
    }
    public void PlayGame()
    {
        Debug.Log("Starting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }

    public void Settings()
    {
        settingsmenu.SetActive(true);
    }

    public void Back()
    {
        settingsmenu.SetActive(false);
    }
}
