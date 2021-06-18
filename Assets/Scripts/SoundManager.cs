using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bearClaw, enemyHit, Jump, Landing, FootStep, playerHit, pitFall, respawnJiggle, ForestFootStep, BearTransf, CommonButton, PicChangeSound, RNTDeath, RunningDeath,StartButtonSound;
    public static AudioSource audioSrc;
    public AudioMixer musicMixer;
    public Slider musicSlider;
    public AudioMixer soundMixer;
    public Slider soundSlider;

    private void Start() {
        bearClaw = Resources.Load<AudioClip>("clawattack");
        enemyHit = Resources.Load<AudioClip>("Hit enemy");
        Jump = Resources.Load<AudioClip>("jump 1");
        Landing = Resources.Load<AudioClip>("Landing");
        FootStep = Resources.Load<AudioClip>("footstep");
        playerHit = Resources.Load<AudioClip>("getting_hit");
        pitFall = Resources.Load<AudioClip>("pit_fall");
        respawnJiggle = Resources.Load<AudioClip>("respawn_jiggle");
        ForestFootStep = Resources.Load<AudioClip>("forestbed_footstep");
        BearTransf = Resources.Load<AudioClip>("bear-transformation");
        CommonButton = Resources.Load<AudioClip>("common-button-sound");
        PicChangeSound = Resources.Load<AudioClip>("pictures");
        RNTDeath = Resources.Load<AudioClip>("rockntroll_death");
        RunningDeath = Resources.Load<AudioClip>("runningtroll_death");
        StartButtonSound = Resources.Load<AudioClip>("start-button-sound");



        audioSrc = GetComponent<AudioSource>();

        musicSlider.value = PlayerPrefs.GetFloat("Music", 0);
        musicMixer.SetFloat("MusicVol", Mathf.Log10(musicSlider.value) *20);
        soundSlider.value = PlayerPrefs.GetFloat("Sound", 0);
        soundMixer.SetFloat("GameSoundVol", Mathf.Log10(musicSlider.value) *20);
    }

    public static void PlaySound(string clip)
    {
        switch(clip){
            case "bearClaw":
            audioSrc.PlayOneShot(bearClaw);
            break;

            case "enemyHit":
            audioSrc.PlayOneShot(enemyHit);
            break;

            case "Jump":
            audioSrc.PlayOneShot(Jump);
            break;

            case "Landing":
            audioSrc.PlayOneShot(Landing);
            break;

            case "footstep":
            if(audioSrc.isPlaying){
                break;
            }
            else{
                audioSrc.PlayOneShot(FootStep);
            }
            break;

            case "forestbed_footstep":
            if(audioSrc.isPlaying){
                break;
            }
            else{
                audioSrc.PlayOneShot(FootStep);
            }
            break;

            case "getting_hit":
            audioSrc.PlayOneShot(playerHit);
            break;

            case "pit_fall":
            audioSrc.PlayOneShot(pitFall);
            break;

            case "respawn_jiggle":
            audioSrc.PlayOneShot(respawnJiggle);
            break;

        }
    }

    public void PlayClipAt(AudioClip clip, Vector3 pos){
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
        AudioMixer aMixer = Resources.Load<AudioMixer>("GameSoundsMixer");
        AudioMixerGroup[] aMixerGroup = aMixer.FindMatchingGroups("Master");
        aSource.outputAudioMixerGroup = aMixerGroup[0];
        aSource.clip = clip; // define the clip
        // set other aSource properties here, if desired
        aSource.Play(); // start the sound
        Destroy(tempGO, clip.length); // destroy object after clip duration
        //return aSource; // return the AudioSource reference
 }
}
