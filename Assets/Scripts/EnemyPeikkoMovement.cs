using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPeikkoMovement : MonoBehaviour
{
    public enum PeikkoState {Moving, Hiding}
    public PeikkoState state;
    public float moveDirection = 1;
    private Rigidbody2D prb;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speed;
    [SerializeField] private bool useBush;
    public bool activePeikko = true;
    [SerializeField]
    private float viewDistance;
    private bool enemyFacingLeft = true;
    [SerializeField]
    private SpriteRenderer bushSpriteRenderer;
    public Animator animator;
    EnemyHealth enemyHealth;

    private void Start() {
        prb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();


        if(useBush==true)
        {
            activePeikko=false;
            state=PeikkoState.Hiding;
        }
        else
        {
            activePeikko=true;
            FlipEnemy();
            state=PeikkoState.Moving;
        }
    }

    void Update()
    {
        if(state == PeikkoState.Moving && enemyHealth.playDeathAnim == false)
        {
            transform.position = transform.position + new Vector3(moveDirection,0,0) * speed * Time.deltaTime;
            animator.SetBool("Running",true);
        }
        else
        {
            if(PlayerDetect())
            {
                //Debug.Log("or");
                animator.SetTrigger("Hyppy");
                //StartCoroutine("BushJump");
            }

        }
        if(enemyHealth.playDeathAnim==true)
        {
            state = PeikkoState.Hiding;
            Destroy(this.GetComponent<CapsuleCollider2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
            Destroy(this.gameObject, 0.2f);
            animator.SetTrigger("Death");
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="PeikkoTurnPoint")
        {
            moveDirection = -moveDirection;
            FlipEnemy();
        }
    }

    private bool PlayerDetect()
    {
        RaycastHit2D raycastl = Physics2D.Raycast(transform.position, Vector2.left, viewDistance, LayerMask.GetMask("Player"));
        RaycastHit2D raycastr = Physics2D.Raycast(transform.position, Vector2.right, viewDistance, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position,Vector2.left*viewDistance,Color.green);
        Debug.DrawRay(transform.position,Vector2.right*viewDistance,Color.green);
        if(raycastl.collider != null)
        {
            moveDirection = -1;
            if(!enemyFacingLeft)
            {
                FlipEnemy();
            }
            enemyFacingLeft = true;
        }
        else if(raycastr.collider != null)
        {
            moveDirection = 1;
            if(enemyFacingLeft)
            {
                FlipEnemy();
            }
            enemyFacingLeft = false;
        }
        return raycastl.collider || raycastr.collider != null;
    }

    public IEnumerator BushJump()
    {
        state = PeikkoState.Moving;
        activePeikko=true;
        prb.AddForce(new Vector2(0,150),ForceMode2D.Impulse);
        //activePeikko = true;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sortingOrder = bushSpriteRenderer.sortingOrder+1;
        yield return new WaitForSeconds(1f);
    }

    private void FlipEnemy()
    {
        enemyFacingLeft = !enemyFacingLeft;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;

        transform.localScale = playerScale;

    }

}
