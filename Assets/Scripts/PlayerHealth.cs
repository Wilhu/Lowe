using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 8;
    private int health;
    private ArrowUI arrow;

    private void Start() {
        health = maxHealth;
    }
    public int pHealth
    {
        get{return health;}
        set{health = value;
        Debug.Log(health);
        if(health<1)
        {
            Debug.Log("ded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        }
    }

}
