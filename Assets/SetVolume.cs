using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

   /* private void Start() {
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0);
        mixer.SetFloat("MusicVol", Mathf.Log10(musicSlider.value) *20);
    }*/
    public void SetLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("Music", sliderValue);
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue)*20);

    }

    public void SetSoundLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("Sound", sliderValue);
        mixer.SetFloat("GameSoundVol", Mathf.Log10(sliderValue)*20);
    }

}
