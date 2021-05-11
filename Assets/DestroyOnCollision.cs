using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void Start() {
        //accesss = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D other) {

        Destroy(gameObject);

        if(other.gameObject.tag=="Player")
        {

        }
    }


}
