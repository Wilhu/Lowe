using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    private Scene cScene;
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public AudioMixer mixerMusic;
    public AudioMixer mixerSounds;
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
        mixerMusic.SetFloat("MusicVol", Mathf.Log10(0.5f)*20);
        mixerSounds.SetFloat("GameSoundVol", Mathf.Log10(0.5f)*20);
    }

    public void ButtonSound()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();
    }
}
