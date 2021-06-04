using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHelper : MonoBehaviour
{
    EnemyPeikkoAttack attackScript;
    EnemyPeikkoMovement movementScript;

    void Awake()
    {
        attackScript = transform.parent.GetComponent<EnemyPeikkoAttack>();
        movementScript = transform.parent.GetComponent<EnemyPeikkoMovement>();
    }

    // Update is called once per frame
    void Attack()
    {
        StartCoroutine(attackScript.Attack());
    }

    void BushJump()
    {
        StartCoroutine(movementScript.BushJump());
    }
}
