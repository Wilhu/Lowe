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
    [SerializeField]
    private bool useBush;
    private bool activePeikko;
    private bool canAttack;
    private Rigidbody2D prb; 
    private SpriteRenderer spriteRenderer;




private void Start() {
    prb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    attackCooldownd = attackCooldown;
    attackCooldown = 0;
    if (useBush==true)
    {
        activePeikko=false;
        canAttack=false;
    }
    else
    {
        activePeikko=true;
        canAttack=true;
    }


}
private void Update()
{
    attackCooldown -= Time.deltaTime;

    if(PlayerDetectedLeft())
    {   
        if(activePeikko==false)
        {
            StartCoroutine("BushJump");
            //Debug.Log("puska");
        }
        if(!enemyFacingLeft)
        {
            FlipEnemy();
        }
        if(attackCooldown<=0 && activePeikko==true && canAttack==true)
        {
            StartCoroutine("AttackLeft");
        }
        //Debug.Log("player detected left");
    }
    if(PlayerDetectedRight())
    {
        if(activePeikko==false)
        {
            StartCoroutine("BushJump");
            //Debug.Log("puska2");
        }
        if(enemyFacingLeft)
        {
            FlipEnemy();
        }
        if(attackCooldown<=0 && activePeikko==true && canAttack==true)
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
        stoneclone.transform.SetParent(prb.transform);
        stoneclone.gameObject.SetActive(true);
        stoneclone.velocity = transform.TransformDirection(new Vector3(-1*stoneSpeed, 4f,0));
        yield return new WaitForSeconds(0.05f);
        stoneclone.gameObject.AddComponent<CircleCollider2D>();
    }

    private IEnumerator AttackRight()
    {
        attackCooldown = attackCooldownd;
        Rigidbody2D stoneclone;
        stoneclone = Instantiate(stone, stone.transform.position,stone.transform.rotation);
        stoneclone.transform.SetParent(prb.transform);
        stoneclone.gameObject.SetActive(true);
        stoneclone.velocity = transform.TransformDirection(new Vector3(1*stoneSpeed, 4f,0));
        yield return new WaitForSeconds(0.05f);
        stoneclone.gameObject.AddComponent<CircleCollider2D>();
    }

    private IEnumerator BushJump()
    {
        prb.AddForce(new Vector2(0,150),ForceMode2D.Impulse);
        activePeikko = true;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sortingOrder = 1;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}
