using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public bool AllowGravityChange;
    public bool CameraIsFollowingPlayer = true;

    public float jumpForce = 10f;
    public Transform feet;
    public Transform player;
    public Transform playerCamera;
    public LayerMask groundLayers;

    public Animator anim;

    Vector2 gravity;
    float movementX;
    //float movementY;

    // 0 = UP, 1 = RIGHT, 2 = DOWN, 3 = LEFT 
    [HideInInspector] public int gravityDirection;
    [HideInInspector] public bool isFacingLeft = true;

    private LevelHandler levelHandler;

    void Awake()
    {
        levelHandler = GameObject.FindObjectOfType<LevelHandler>();
    }

    private void Update(){
        movementX = Input.GetAxisRaw("Horizontal");
        //movementY = Input.GetAxisRaw("Vertical");
        if (CameraIsFollowingPlayer)
        {
            playerCamera.position = new Vector3(player.position.x, player.position.y, -10);
        }
        if (Input.GetKeyDown(KeyCode.E) && AllowGravityChange)
        {
            RotatePlayer("E");
        }
        else if (Input.GetKeyDown(KeyCode.Q) && AllowGravityChange)
        {
            RotatePlayer("Q");
        }
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        RotateCamera();
         
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
        setAnimationVariables();

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
            gravity = new Vector2(0f, -12f);
            //rb.velocity = new Vector2(movementX * movementSpeed, 0);
        } else if (gravityDirection == 1)
        {
            gravity = new Vector2(12f, 0f);
        } else if (gravityDirection == 2) {
            gravity = new Vector2(0f, 12f);
        } else if (gravityDirection == 3) {
            gravity = new Vector2(-12f, 0f);
        }
        Physics2D.gravity = gravity;
    }

    void RotatePlayer(string buttonPressed)
    {

        if (buttonPressed == "E")
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
        else if (buttonPressed == "Q")
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
        levelHandler.UpdatePlayerRotation(player.rotation);
    }

    

    void RotateCamera()
    {
        Quaternion playerRotation = player.transform.rotation;
        Quaternion cameraRotation = playerCamera.transform.rotation;
        playerCamera.rotation = Quaternion.Slerp(cameraRotation, playerRotation, 5f * Time.deltaTime);
        
    }

    public void ResetRotations()
    {
        player.transform.rotation = new Quaternion(0, 0, 0,0);
        playerCamera.transform.rotation = new Quaternion(0, 0, 0,0);
        gravityDirection = 0;
        levelHandler.UpdatePlayerRotation(player.rotation);
        setGravity();
    }


    private void setAnimationVariables()
    {
        if (IsGrounded())
        {
            anim.SetBool("IsGrounded", true);
        } else
        {
            anim.SetBool("IsGrounded", false);
        }
        if(Math.Abs(movementX) > 0.5)
        {
            anim.SetBool("IsRunning", true);
        }else
        {
            anim.SetBool("IsRunning", false);
        }
        if(movementX < 0)
        {
            player.localScale = new Vector3(1f, 1f, 1f);
            isFacingLeft = true;
        } else if (movementX > 0)
            {
            isFacingLeft = false;
            player.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

  

};
