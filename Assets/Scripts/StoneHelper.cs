using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHelper : MonoBehaviour
{
    EnemyPeikkoAttack attackScript;
    void Awake()
    {
       attackScript = transform.parent.GetComponent<EnemyPeikkoAttack>();
    }

    // Update is called once per frame
    void Attack()
    {
        StartCoroutine(attackScript.Attack());
    }
}
