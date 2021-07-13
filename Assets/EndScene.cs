using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public GameObject text;
    public GameObject mainMenuButton;


    private void Update() {
        if(Input.anyKeyDown)
        {
            StartCoroutine("Fade");
        }
    }

    public IEnumerator Fade()
    {
        Color objectColor = text.GetComponent<TextMeshProUGUI>().color;
        float fadeAmount;

            while(text.GetComponent<TextMeshProUGUI>().color.a < 1)
            {
                fadeAmount = objectColor.a + (2f * Time.deltaTime);
                objectColor = new Color(objectColor.r,objectColor.g,objectColor.b, fadeAmount);
                text.GetComponent<TextMeshProUGUI>().color = objectColor;
                yield return null;
                mainMenuButton.SetActive(true);
            }
    }

    public void ToMainMenu()
    {
        Destroy(GameObject.Find("SettingsCanvas"));
        Destroy(GameObject.Find("BackgroundMusic"));
        Destroy(GameObject.Find("SoundManager"));
        SceneManager.LoadScene("Main Menu 2");
    }
}

