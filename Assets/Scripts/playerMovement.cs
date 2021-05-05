using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public float movementSpeedMax = 20;
    private float movementSpeed;
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
    private CapsuleCollider2D playerCapsuleCollider;
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




    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
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
        Jump();
        MovePlayer();

        playerRigidbody.gravityScale = 0;
        if (useGravity==0/* && mayJump > 0.1*/) playerRigidbody.AddForce(Physics.gravity * (playerRigidbody.mass * playerRigidbody.mass));

        if(BearCheck==true && Input.GetButton("Fire1"))
        {

            Debug.Log("karhu");
            StartCoroutine(BearBuff());
        }
        if(/*bearBuffActive && */Input.GetButton("Fire2"))
        {
            BearAttack();
        }
    }


    private void Update() {
        BearObjects();
    }
    private void Jump()
    {

        if(!IsGrounded() && mayJump < 0.1)
        {
           // useGravity=1;
            Debug.Log("ay");
        }
        else{
           // useGravity=0;
        }

        if(mayJump < 0.1 || IsGrounded())
        {

            if(jumpCD < 0 && Input.GetButton("Jump"))
            {
                //Debug.Log("Jumped");
                jumpCD = 0.5f;
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }
        }
        if(IsGrounded())
        {
            mayJump = 0;
        }
        if(playerRigidbody.velocity.y > 0)
        {
            isJumping=true;
            //Debug.Log("ylös");
        }
        else{
            isJumping=false;
            //Debug.Log("alas");
        }
    }

    private void SlopeCheck()
    {
        //RaycastHit2D slopeRay = Physics2D.CapsuleCast(playerCapsuleCollider.bounds.center,)
    }
    private void MovePlayer()
    {
        float movement = Input.GetAxis("Horizontal");
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
    }

    private bool IsGrounded()
    {
        float extraHeight  = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size - new Vector3(0.4f,0f,0f), 0f, Vector2.down, extraHeight, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(playerBoxCollider.bounds.center + new Vector3(playerBoxCollider.bounds.extents.x, 0), Vector2.down * (playerBoxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(playerBoxCollider.bounds.center - new Vector3(playerBoxCollider.bounds.extents.x, 0), Vector2.down * (playerBoxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(playerBoxCollider.bounds.center - new Vector3(playerBoxCollider.bounds.extents.x, playerBoxCollider.bounds.extents.y + extraHeight), Vector2.right * (playerBoxCollider.bounds.size.x), rayColor);
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    private void FlipPlayer()
    {
        playerIsFacingRight = !playerIsFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;

        transform.localScale = playerScale;

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
        movementSpeedMax = bearMovementSpeedMax;
        jumpForce = bearJumpForce;
        acceleration = bearAcceleration;
        deceleration = bearDeceleration;
        turnRate = bearTurnRate;

        yield return new WaitForSeconds(bearBuffDuration);
        bearBuffActive = false; //Karhu pois päältä
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

        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(new Vector2(attackDirection*dashPower,0),ForceMode2D.Impulse);
        StartCoroutine(GravityOff());
        attackCD = attackCDp;
        }
       /* Collider2D hitColliders = Physics2D.OverlapCircle(transform.position + new Vector3(attackDirection,0,0),10);
        Debug.Log(hitColliders); */
            Collider2D[] result = Physics2D.OverlapCircleAll(gameObject.transform.position + new Vector3(attackDirection,0,0), 10f);
        
            foreach(Collider2D res in result)
            {
                //Debug.Log(res.name);
                if(res.tag == "Enemy")
                {
                    Debug.Log("jee vihu");
                    //Deal damage
                }
                else
                {
                    //Debug.Log("jotain");
                }


            }


    }

    private IEnumerator GravityOff()
    {
        useGravity=1;
        yield return new WaitForSeconds(gravityOffTime);
        useGravity=0;
    }
    
}  