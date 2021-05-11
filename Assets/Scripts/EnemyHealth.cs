using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{    [SerializeField] private int health = 1;

    public int eHealth
    {
        get{return health;}
        set{health = value; 
        if(health == 0)
            {
            Destroy(gameObject);
            }
        }
    }



}
