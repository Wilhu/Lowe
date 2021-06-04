using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public float movementSpeedMax = 20;
    public float movementSpeed;
    public float jumpForce = 1;
    public float acceleration = 0.5f;
    public float deceleration = 1.5f;
    public float turnRate = 1;
    private float humanMovementSpeedMax;
    private float humanJumpForce;
    private float humanAcceleration;
    private float humanDeceleration;
    private float humanTurnRate;
    public float bearMovementSpeedMax;
    public float bearJumpForce;
    public float bearAcceleration;
    public float bearDeceleration;
    public float bearTurnRate;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerBoxCollider;
    [SerializeField] private LayerMask platformLayerMask;
    private bool playerIsFacingRight = true;
    private float useGravity;
    bool BearCheck = false;
    public float bearBuffDuration = 5;
    public float mayJump = 0;
    private float jumpCD = 0;
    public bool bearBuffActive = false;
    private GameObject[] bearObjects;
    private bool isJumping = false;
    private int attackDirection;
    private float attackCD=0;
    [SerializeField] private float attackCDp;
    [SerializeField] private float dashPower;
    [SerializeField] private float gravityOffTime;
    [SerializeField] private float dashtime;
    PlayerHealth m_health;
    [SerializeField] private float knockbackforce;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool invulnerable = false;
    private float movement;



    void Awake() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        m_health = GetComponent<PlayerHealth>();
        humanMovementSpeedMax = movementSpeedMax;
        humanJumpForce = jumpForce;
        humanAcceleration = acceleration;
        humanDeceleration = deceleration;
        humanTurnRate = turnRate;
        bearObjects = GameObject.FindGameObjectsWithTag("Bear");
    }

    void FixedUpdate()
    {
        mayJump += Time.deltaTime;
        jumpCD -= Time.deltaTime;
        attackCD -= Time.deltaTime;

        //Debug.Log("mayJump: " + mayJump);
        //Debug.Log("jumpCD: " + jumpCD);
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("testi 2 power"))
        {
            return;
        }
        Jump();
        MovePlayer();

        playerRigidbody.gravityScale = 0;
        if (useGravity==0/* && mayJump > 0.1*/) playerRigidbody.AddForce(Physics.gravity * (playerRigidbody.mass * playerRigidbody.mass));

        if(BearCheck==true && Input.GetButton("Fire1"))
        {

            //Debug.Log("karhu");
            StartCoroutine(BearBuff());
        }
        if(bearBuffActive && Input.GetButton("Fire2"))
        {
            BearAttack();
        }
        else
        {
            //animator.SetBool("Attack", false);
        }
    }


    private void Update() {
        BearObjects();
        movement = Input.GetAxisRaw("Horizontal");
    }
    private void Jump()
    {

        if(!IsGrounded() && mayJump < 0.1)
        {
           // useGravity=1;
           // Debug.Log("ay");
        }
        else{
           // useGravity=0;
        }

        if(mayJump < 0.1 || IsGrounded())
        {

            if(jumpCD < 0 && Input.GetButton("Jump"))
            {
                //Debug.Log("Jumped");
                SoundManager.PlaySound("Jump");
                animator.SetTrigger("JumpTrigger");
                jumpCD = 0.5f;
                playerRigidbody.velocity = new Vector2(0,0); //Vector3.zero;
                playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }
        }
        if(IsGrounded())
        {
            mayJump = 0;

            animator.SetBool("Fall",false);
        }
        if(playerRigidbody.velocity.y > 0.01)
        {
            isJumping=true;
            //Debug.Log("ylös");
        }
        else if(playerRigidbody.velocity.y < 0 && !IsGrounded()) {
            isJumping=false;
            animator.SetBool("Fall",true);
            //Debug.Log("alas");
        }
        else
        {
            animator.SetBool("Fall",false);
        }
    }
    private void MovePlayer()
    {
        //float movement = Input.GetAxisRaw("Horizontal");
        if(Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            if(playerIsFacingRight==false)
            {
                FlipPlayer();
                attackDirection = 10;
                movementSpeed = movementSpeed / turnRate;
            }
             movementSpeed = Mathf.Lerp(movementSpeed, movementSpeedMax, Input.GetAxis("Horizontal") * Time.deltaTime * acceleration);
            playerIsFacingRight = true;
            // Debug.Log("oikealle");
        }
        else if(Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            if(playerIsFacingRight==true)
            {
                FlipPlayer();
                attackDirection = -10;
                movementSpeed = movementSpeed / turnRate;
            }
             movementSpeed = Mathf.Lerp(movementSpeed, movementSpeedMax, Input.GetAxis("Horizontal") * Time.deltaTime * -acceleration);
            playerIsFacingRight = false;
           //  Debug.Log("vasemmalle");
        }
        else
        {
            movementSpeed = Mathf.Lerp(movementSpeed, 0, Time.deltaTime * deceleration);
            // Debug.Log("paikallaan");
            // x = Mathf.Lerp(x, 0, Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed);
            //Debug.Log("Standing");
        }
        transform.position = transform.position + new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;
        animator.SetFloat("Movement Speed", Mathf.Abs(movement));
        //playerRigidbody.MovePosition(transform.position + new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        float extraHeight  = 0.005f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider.bounds.min + new Vector3(playerBoxCollider.bounds.extents.x,0), playerBoxCollider.bounds.size - new Vector3(0.4f,playerBoxCollider.bounds.extents.y*1.95f,0f), 0f, Vector2.down, extraHeight, platformLayerMask);
        //RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider.bounds.min + 0.00005f * Vector3.up, playerBoxCollider.bounds.size - new Vector3(0.4f,0f,0f), 0f, Vector2.down, extraHeight, platformLayerMask);
        //RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size - new Vector3(0.4f,0f,0f), 0f, Vector2.down, extraHeight, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(playerBoxCollider.bounds.min + new Vector3(playerBoxCollider.bounds.extents.x,0) + new Vector3(playerBoxCollider.bounds.extents.x, 0), Vector2.down * (playerBoxCollider.bounds.size - new Vector3(0.4f,playerBoxCollider.bounds.extents.y*1.95f,0f + extraHeight)), rayColor);
        //Debug.DrawRay(playerBoxCollider.bounds.min + new Vector3(playerBoxCollider.bounds.extents.x,0) - new Vector3(playerBoxCollider.bounds.extents.x, 0), Vector2.down * (playerBoxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(playerBoxCollider.bounds.min + new Vector3(playerBoxCollider.bounds.extents.x,0) - new Vector3(playerBoxCollider.bounds.extents.x, 0), Vector2.down * (playerBoxCollider.bounds.size - new Vector3(0.4f,playerBoxCollider.bounds.extents.y*1.95f,0f + extraHeight)), rayColor);
        Debug.DrawRay(playerBoxCollider.bounds.min/* + new Vector3(playerBoxCollider.bounds.extents.x,0) - new Vector3(playerBoxCollider.bounds.extents.x, playerBoxCollider.bounds.extents.y + extraHeight)*/, Vector2.right * (playerBoxCollider.bounds.size.x), rayColor);
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    private void FlipPlayer()
    {
        playerIsFacingRight = !playerIsFacingRight;
        //Vector3 playerScale = transform.localScale;
        //playerScale.x *= -1;
        //transform.localScale = playerScale;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Bear")
        {
            //Debug.Log("karhu");
            BearCheck = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D other) {

        BearCheck = false;
        //Debug.Log("ei karhua");
    }

    IEnumerator BearBuff()
    {
        //Debug.Log("Bear buff"); Karhu päälle
        bearBuffActive = true;
        animator.SetTrigger("BearTrigger");
        animator.SetBool("Bear", true);
        movementSpeedMax = bearMovementSpeedMax;
        jumpForce = bearJumpForce;
        acceleration = bearAcceleration;
        deceleration = bearDeceleration;
        turnRate = bearTurnRate;

        yield return new WaitForSeconds(bearBuffDuration);
        bearBuffActive = false; //Karhu pois päältä
        animator.SetBool("Bear", false);
        movementSpeedMax = humanMovementSpeedMax;
        jumpForce = humanJumpForce;
        acceleration = humanAcceleration;
        deceleration = humanDeceleration;
        turnRate = humanTurnRate;

    }
    private void BearObjects()
    {
        if(bearBuffActive==true)
        {
            foreach (GameObject go in bearObjects)
            {
                go.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject go in bearObjects)
            {
                go.SetActive(true);
            }
        }
    }

    private void BearAttack()
    {
        if(attackCD<=0)
        {
        SoundManager.PlaySound("bearClaw");
        //transform.position = Vector2.Lerp(transform.position, transform.position + new Vector3(attackDirection,0), dashtime * Time.deltaTime);
        playerRigidbody.velocity = Vector2.zero;
        animator.SetTrigger("AttackTrigger");
        playerRigidbody.AddForce(new Vector2(attackDirection*dashPower,100),ForceMode2D.Impulse);
        //StartCoroutine(GravityOff());
        Collider2D[] result = Physics2D.OverlapCircleAll(gameObject.transform.position + new Vector3(attackDirection,0,0), 10f);
        
            foreach(Collider2D res in result)
            {
                //Debug.Log(res.name);
                if(res.tag == "Enemy")
                {
                    //Debug.Log("jee vihu");
                    SoundManager.PlaySound("enemyHit");
                    EnemyHealth m_enemyhealth = res.GetComponent<EnemyHealth>();
                    m_enemyhealth.eHealth = m_enemyhealth.eHealth-1; 
                }
                else
                {
                    //Debug.Log("jotain");
                }


            }
        attackCD = attackCDp;
        }
       /* Collider2D hitColliders = Physics2D.OverlapCircle(transform.position + new Vector3(attackDirection,0,0),10);
        Debug.Log(hitColliders); */
    }

    private IEnumerator GravityOff()
    {
        useGravity=1;
        yield return new WaitForSeconds(gravityOffTime);
        useGravity=0;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        bool canplaylandingsound;
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "stone")
        {
            if(invulnerable==false)
            {
            //playerRigidbody.AddForce(new Vector2((other.gameObject.transform.position.x-transform.position.x)*100,(other.gameObject.transform.position.y-transform.position.y)*100),ForceMode2D.Impulse);
            playerRigidbody.AddForce(new Vector2((transform.position.x-other.gameObject.transform.position.x)*knockbackforce,(transform.position.y-other.gameObject.transform.position.y)*knockbackforce),ForceMode2D.Impulse);
            StartCoroutine("DamageFlash");
            //Debug.Log("damaa");
           // Debug.Log(other.gameObject.transform.position.x-transform.position.x);
           // Debug.Log(other.gameObject.transform.position.y-transform.position.y);
            EnemyHealth m_enemyhealth = other.gameObject.GetComponentInParent<EnemyHealth>();
            m_health.pHealth = m_health.pHealth-m_enemyhealth.enemyDamage;
            }

        }
        if(other.gameObject.tag == "Ground" )
        {
            canplaylandingsound = true;
            if(canplaylandingsound = true && !SoundManager.audioSrc.isPlaying && IsGrounded())
            {
                SoundManager.PlaySound("Landing");
                canplaylandingsound = false;
            }
        }
    }

    public IEnumerator DamageFlash()
    {
        invulnerable = true;
        for(int i = 0; i < 3; i++)
        {
            spriteRenderer.color = new Color(0.7f,0.7f,0.7f,1f);
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(0.15f);
        }
        invulnerable = false;
    }
}
  