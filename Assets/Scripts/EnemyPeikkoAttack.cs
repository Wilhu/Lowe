using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPeikkoAttack : MonoBehaviour
{
    public float viewDistance;
    private bool enemyFacingLeft = true;
    [SerializeField]
    private Object stone;

private void Update()
{
    if(PlayerDetectedLeft())
    {
        Instantiate(stone, new Vector3(-1f,1f,0),Quaternion.identity);
        
        if(!enemyFacingLeft)
        {
            FlipEnemy();
        }
        Debug.Log("player detected left");
    }
    if(PlayerDetectedRight())
    {
        if(enemyFacingLeft)
        {
            FlipEnemy();
        }
        Debug.Log(("player detected right"));
    }
}

    private bool PlayerDetectedLeft()
    {
        RaycastHit2D raycastleft = Physics2D.BoxCast(transform.position, new Vector2(1,1),0f,Vector2.left,viewDistance,LayerMask.GetMask("Player"));
        return raycastleft.collider != null;
    }

    private bool PlayerDetectedRight()
    {
        RaycastHit2D raycastright = Physics2D.BoxCast(transform.position, new Vector2(1,1),0f,Vector2.right,viewDistance,LayerMask.GetMask("Player"));
        return raycastright.collider != null;
    }


        private void FlipEnemy()
    {
        enemyFacingLeft = !enemyFacingLeft;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;

        transform.localScale = playerScale;

    }

}
