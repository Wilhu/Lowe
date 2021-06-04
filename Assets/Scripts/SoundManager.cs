using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bearClaw, enemyHit, Jump, Landing, FootStep, playerHit, pitFall, respawnJiggle;
    public static AudioSource audioSrc;

    private void Start() {
        bearClaw = Resources.Load<AudioClip>("clawattack");
        enemyHit = Resources.Load<AudioClip>("Hit enemy");
        Jump = Resources.Load<AudioClip>("jump 1");
        Landing = Resources.Load<AudioClip>("Landing");
        FootStep = Resources.Load<AudioClip>("footstep");
        playerHit = Resources.Load<AudioClip>("getting_hit");
        pitFall = Resources.Load<AudioClip>("pit_fall");
        respawnJiggle = Resources.Load<AudioClip>("respawn_jiggle");


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

            case "footstep":
            audioSrc.PlayOneShot(FootStep);
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
}
