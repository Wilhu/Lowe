using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPeikkoMovement : MonoBehaviour
{
    public enum PeikkoState {Moving, Attacking}
    public PeikkoState state;
    public float moveDirection = 1;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == PeikkoState.Moving)
        {
            transform.position = transform.position + new Vector3(moveDirection,0,0) * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="PeikkoTurnPoint")
        {
            moveDirection = -moveDirection;
        }
    }


}
