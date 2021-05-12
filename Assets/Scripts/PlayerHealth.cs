using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 8;
    private int health;
    private ArrowUI arrow;
    public GameObject arrowgo;

    private void Start() {
        health = maxHealth;
        arrow = arrowgo.GetComponent<ArrowUI>();
    }
    public int pHealth
    {
        get{return health;}
        set{health = value;
        Debug.Log(health);
        //arrow.RotateArrow();
        if(health==0)
        {
            Debug.Log("ded");
        }
        }
    }

}
