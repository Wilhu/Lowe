using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    /*private void Start() {
        mixer.SetFloat("MusicVol", Mathf.Log10(0.5f)*20);
        mixer.SetFloat("GameSoundVol", Mathf.Log10(0.5f)*20);
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
