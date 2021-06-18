using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryStart : MonoBehaviour
{
    public GameObject ImagesUI;
    private Image ImageComp;
    public Sprite[] StoryImages;
    private int i = 0;

    private void Start() {
        ImageComp = GetComponentInChildren<Image>();
        Debug.Log(StoryImages.Length);
    }
    private void OnEnable() {
        if(PlayerPrefs.GetInt("CinematicStart")==0)
        {
            Time.timeScale=0f;
            ImagesUI.SetActive(true);
        }
    }

    private void Update() {
        if(Input.anyKeyDown && ImagesUI.activeSelf == true)
        {
            ImageComp.sprite = StoryImages[i];
            if(i<StoryImages.Length-1)
            {
                i++;
                Debug.Log(i);
            }
            else //if(i == StoryImages.Length)
            {
                ImagesUI.SetActive(false);
                Time.timeScale = 1f;
                PlayerPrefs.SetInt("CinematicStart", 1);
            }
        }
    }
}
