using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public void Back()
    {
        GameObject.Find("SettingsMenu").SetActive(false);
    }
}
