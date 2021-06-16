using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUI : MonoBehaviour
{
    private PlayerHealth m_health;
    public GameObject player;

    private void Start() {
        if (player == null)
            player = GameObject.FindWithTag("Player");
        m_health = player.GetComponent<PlayerHealth>();
        transform.Rotate(0,0,180);
    }
    public void RotateArrow()
    {
        Quaternion ar = Quaternion.Euler(0,0, (180/m_health.maxHealth)*m_health.pHealth);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Inverse(ar),200 * Time.deltaTime);
    }

    private void Update() {

        RotateArrow();
    }
}
