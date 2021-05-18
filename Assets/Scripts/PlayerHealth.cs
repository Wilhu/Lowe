using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(health==0)
        {
            Debug.Log("ded");
        }
        }
    }

}
