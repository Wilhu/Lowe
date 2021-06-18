using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCinematicReset : MonoBehaviour
{
    private void Start() {
        PlayerPrefs.SetInt("CinematicStart", 0);
    }
}
