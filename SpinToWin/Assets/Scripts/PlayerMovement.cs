using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce = 10f;
    public Transform feet;
    public Transform player;
    public Transform playerCamera;
    public LayerMask groundLayers;


    Vector2 gravity;
    float movementX;
    //float movementY;

    // 0 = UP, 1 = RIGHT, 2 = DOWN, 3 = LEFT 
    private int gravityDirection;

    private void Update(){
        movementX = Input.GetAxisRaw("Horizontal");
        //movementY = Input.GetAxisRaw("Vertical");
        playerCamera.position = new Vector3(player.position.x, player.position.y, -10);
        RotateGravity();
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement;
        if (gravityDirection == 0)
        {
            movement = new Vector2(movementX * movementSpeed, rb.velocity.y);
        } else if( gravityDirection == 1)
        {
            movement = new Vector2(rb.velocity.x, movementX * movementSpeed);
        }
        else if (gravityDirection == 2)
        {
            movement = new Vector2(-movementX * movementSpeed, rb.velocity.y);
        }
        else // 3
        {
            movement = new Vector2(rb.velocity.x,- movementX * movementSpeed);
        }
        rb.velocity = movement;
    }

    void Jump() {
        Vector2 movement;
        if (gravityDirection == 0)
        {
            movement = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (gravityDirection == 1)
        {
            movement = new Vector2(-jumpForce, rb.velocity.x);
        }
        else if (gravityDirection == 2)
        {
            movement = new Vector2(-rb.velocity.x, -jumpForce);
        }
        else // 3
        {
            movement = new Vector2(jumpForce, -rb.velocity.x);
        }

        rb.velocity = movement;
    }

    bool IsGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f,groundLayers);

        if (groundCheck != null) {
            return true;
        }
        
	return false;
    }

    void setGravity()
    {
        if (gravityDirection == 0) {
            Debug.Log("Gravity  DOWN = " + gravityDirection);
            gravity = new Vector2(0f, -12f);
            //rb.velocity = new Vector2(movementX * movementSpeed, 0);
        } else if (gravityDirection == 1)
        {
            Debug.Log("Gravity  RIGHT = " + gravityDirection);
            gravity = new Vector2(12f, 0f);
            //camera.Rotate(Vector3.forward, 10.0f * Time.deltaTime);
            //rb.velocity = new Vector2(movementX * movementSpeed, 0);
        } else if (gravityDirection == 2) {
            Debug.Log("Gravity  UP = " + gravityDirection);
            gravity = new Vector2(0f, 12f);
            //camera.Rotate(Vector3.forward, 10.0f * Time.deltaTime);
            // rb.velocity = new Vector2(movementX * movementSpeed, 0);
        } else if (gravityDirection == 3) {
            Debug.Log("Gravity  LEFT = " + gravityDirection);
            gravity = new Vector2(-12f, 0f);
            //camera.Rotate(Vector3.forward, 10.0f * Time.deltaTime);
            // rb.velocity = new Vector2(movementX * movementSpeed, 0);
        }
        Physics2D.gravity = gravity;
    }

    void RotateGravity()
    {

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (gravityDirection < 3)
            {
                gravityDirection += 1;
            }
            else
            {
                gravityDirection = 0;
            }
            player.Rotate(new Vector3(0, 0, 90));
            setGravity();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            if (gravityDirection > 0)
            {
                gravityDirection -= 1;
            }
            else
            {
                gravityDirection = 3;
            }
            player.Rotate(new Vector3(0, 0, -90));
            setGravity();
        }
        playerCamera.eulerAngles = Vector3.SlerpUnclamped(playerCamera.eulerAngles, player.eulerAngles, 3f * Time.deltaTime);
    }

};
