using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuskaAnim : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag=="Enemy")
        {
            Debug.Log("Enemy alueella");
            if(other.GetComponent<EnemyPeikkoMovement>() == null)
            {
                Debug.Log("peikko attack skripti");
                EnemyPeikkoAttack Enemyscript = other.GetComponent<EnemyPeikkoAttack>();
                if(Enemyscript.activePeikko==true)
                {
                    animator.SetBool("PuskastaHypätty", true);
                }
            }
            else
            {
                Debug.Log("peikko move skripti");
                other.GetComponent<EnemyPeikkoMovement>();
                EnemyPeikkoMovement Enemyscript = other.GetComponent<EnemyPeikkoMovement>();
                Debug.Log(Enemyscript.activePeikko);
                if(Enemyscript.activePeikko==true)
                {
                    animator.SetBool("PuskastaHypätty", true);
                }
            }
        }
    }
}
