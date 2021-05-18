using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bearClaw, enemyHit, Jump, Landing;
    public static AudioSource audioSrc;

    private void Start() {
        bearClaw = Resources.Load<AudioClip>("Bear claw");
        enemyHit = Resources.Load<AudioClip>("Hit enemy");
        Jump = Resources.Load<AudioClip>("Jump");
        Landing = Resources.Load<AudioClip>("Landing");

        audioSrc = GetComponent<AudioSource>();
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

        }
    }
}
