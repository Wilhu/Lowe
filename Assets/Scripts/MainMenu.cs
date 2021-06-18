using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsmenu;
    public AudioSource audioSource;
    public AudioClip StartButtonClickSound;
    FadeBlack fadeBlack;

    private void Start() {
        fadeBlack = GetComponent<FadeBlack>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && settingsmenu.activeInHierarchy)
        {
            settingsmenu.SetActive(false);
        }
    }
    public void PlayGame()
    {
        //Debug.Log("Starting...");
        StartCoroutine("StartGame");

    }

    public void QuitGame()
    {
        //Debug.Log("Quiting...");
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

    public void StartClickSound()
    {
        audioSource.clip = StartButtonClickSound;
        audioSource.Play();
    }

    private IEnumerator StartGame()
    {
        StartCoroutine(fadeBlack.ScreenFadeBlack());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
