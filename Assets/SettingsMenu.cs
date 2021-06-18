using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    private Scene cScene;
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public void Back()
    {
        //GameObject.Find("SettingsMenu").SetActive(false);
        settingsMenu.SetActive(false);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && settingsMenu.activeSelf==true && cScene.name == "Main Menu")
        {
            Back();
        }
    }
    private void Start() {
        cScene = SceneManager.GetActiveScene();
    }

    public void ButtonSound()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();
    }
}
