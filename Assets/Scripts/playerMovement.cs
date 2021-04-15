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
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerBoxCollider;
    [SerializeField] private LayerMask platformLayerMask;
    private bool playerIsFacingRight = true;
    private CapsuleCollider2D playerCapsuleCollider;



    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        Debug.Log(movementSpeed);

        if(Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            if(playerIsFacingRight==false)
            {
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

        Debug.Log(movement);

        transform.position = transform.position + new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;

    }


    private void Update() {

        float movement = Input.GetAxis("Horizontal");
         if(IsGrounded() && Input.GetButtonDown("Jump"))
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
        float extraHeight  = 0.1f;
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
}
