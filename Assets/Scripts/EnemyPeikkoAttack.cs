using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPeikkoAttack : MonoBehaviour
{
    public float viewDistance;
    private bool enemyFacingLeft = true;
    [SerializeField]
    private Rigidbody2D stone;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float attackCooldown;
    private float attackCooldownd;
    [SerializeField]
    private float stoneSpeed;



private void Start() {
    attackCooldownd = attackCooldown;
    attackCooldown = 0;
}
private void Update()
{
    attackCooldown -= Time.deltaTime;
    if(PlayerDetectedLeft())
    {   
        if(!enemyFacingLeft)
        {
            FlipEnemy();
        }
        if(attackCooldown<=0)
        {
            StartCoroutine("AttackLeft");
        }
        //Debug.Log("player detected left");
    }
    if(PlayerDetectedRight())
    {
        if(enemyFacingLeft)
        {
            FlipEnemy();
        }
        if(attackCooldown<=0)
        {
            StartCoroutine("AttackRight");
        }
        //Debug.Log(("player detected right"));
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

    private IEnumerator AttackLeft()
    {
        attackCooldown = attackCooldownd;
        Rigidbody2D stoneclone;
        stoneclone = Instantiate(stone, stone.transform.position,stone.transform.rotation);
        stoneclone.gameObject.SetActive(true);
        stoneclone.velocity = transform.TransformDirection(new Vector3(-1*stoneSpeed, 4f,0));
        yield return new WaitForSeconds(0.05f);
        stoneclone.gameObject.AddComponent<CircleCollider2D>();
        yield return new WaitForSeconds(5f);
    }

    private IEnumerator AttackRight()
    {
        attackCooldown = attackCooldownd;
        Rigidbody2D stoneclone;
        stoneclone = Instantiate(stone, stone.transform.position,stone.transform.rotation);
        stoneclone.gameObject.SetActive(true);
        stoneclone.velocity = transform.TransformDirection(new Vector3(1*stoneSpeed, 4f,0));
        yield return new WaitForSeconds(0.05f);
        stoneclone.gameObject.AddComponent<CircleCollider2D>();
    }

}
