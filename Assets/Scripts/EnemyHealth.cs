using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    [SerializeField] private int health = 1;
    [SerializeField] private int damage;
    public bool playDeathAnim = false;

    public int eHealth
    {
        get{return health;}
        set{health = value; 
        if(health <= 0)
            {
                playDeathAnim = true;
            //Destroy(gameObject);
            }
        }
    }

    public int enemyDamage
    {
        get{return damage;}
        private set{damage = value;}
    }



}
