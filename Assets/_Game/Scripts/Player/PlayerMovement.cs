using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    Vector3 moveDirection;
    Rigidbody rb;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Score")]
    public float score = 0;

    [Header("Shooting")]
    public Camera playerCamera;
    public GameObject rocketPrefab;
    public GameObject rocketSpawnPoint;
    //reference for last fired rocket
    public GameObject lastSpawnedRocket;
    private RaycastHit hit;

    //

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
        readyToJump = true;
    }

    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //player shooting
        ShootRocket();
        ShootRaycast();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void ShootRocket()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastSpawnedRocket = Instantiate(rocketPrefab, rocketSpawnPoint.transform.position, playerCamera.transform.rotation);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(lastSpawnedRocket.gameObject);
        }
    }

    private void ShootRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("shoot raycast");
            if (Physics.Raycast(rocketSpawnPoint.transform.position, playerCamera.transform.forward, out hit, 20f))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("hit enemy");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        //in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVelocity.magnitude > moveSpeed) 
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}