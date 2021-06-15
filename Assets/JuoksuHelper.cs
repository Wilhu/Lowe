using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuoksuHelper : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyPeikkoMovement movementScript;
    void Start()
    {
        movementScript = transform.parent.GetComponent<EnemyPeikkoMovement>();
    }
    void BushJump()
    {
        StartCoroutine(movementScript.BushJump());
    }
}
