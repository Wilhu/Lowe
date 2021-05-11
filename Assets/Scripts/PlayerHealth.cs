using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;

    public int pHealth
    {
        get{return health;}
        set{health = value;
        if(health==0)
        {
            //ded
        }
        }
    }

}
