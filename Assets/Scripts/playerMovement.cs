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
    public float useGravity;
    bool BearCheck = false;
    public float bearBuffTimer = 5;
    public float mayJump = 0;



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
    }

    void FixedUpdate()
    {

        float movement = Input.GetAxis("Horizontal");
        mayJump += Time.deltaTime;
        //Debug.Log(mayJump);
       
         
        playerRigidbody.gravityScale = 0;
        if (useGravity==0) playerRigidbody.AddForce(Physics.gravity * (playerRigidbody.mass * playerRigidbody.mass));

        if(Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            if(playerIsFacingRight==false)
            {
                FlipPlayer();
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

        //Debug.Log(movement);

        transform.position = transform.position + new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;

        if(BearCheck==true && Input.GetButton("Fire1"))
        {
            Debug.Log("karhu");
            StartCoroutine(BearBuff());
        }
/*
         if(Input.GetButtonDown("Jump"))
        {
            if(IsGrounded())
            {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

        }
        
        if(IsGrounded())
        {
            mayJump = 0;
        }
*/

    }


    private void Update() {

        //float movement = Input.GetAxis("Horizontal");
        //Debug.Log(mayJump);
         if(/*mayJump > 0.5 ||*/ IsGrounded())
         {
          if(Input.GetButtonDown("Jump"))
          {
              mayJump = 0;
              //Debug.Log(IsGrounded());
              //Debug.Log("Jump");
              //Debug.Log(mayJump);
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

          }
         }
        if(IsGrounded())
        {
            mayJump = 0;
        }
    }

    private void SlopeCheck()
    {
        //RaycastHit2D slopeRay = Physics2D.CapsuleCast(playerCapsuleCollider.bounds.center,)
    }
    private void MovePlayer()
    {
        float movement = Input.GetAxis("Horizontal");
        //Debug.Log(movement);

        transform.position += new Vector3(movement,0,0) * Time.deltaTime * movementSpeed;
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
      //  Debug.Log(raycastHit.collider);
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
        Debug.Log("Bear buff");
        movementSpeedMax = bearMovementSpeedMax;
        jumpForce = bearJumpForce;
        acceleration = bearAcceleration;
        deceleration = bearDeceleration;
        turnRate = bearTurnRate;

        yield return new WaitForSeconds(bearBuffTimer);
        movementSpeedMax = humanMovementSpeedMax;
        jumpForce = humanJumpForce;
        acceleration = humanAcceleration;
        deceleration = humanDeceleration;
        turnRate = humanTurnRate;

        Debug.Log("Bear buff finished");
    }

    
}  