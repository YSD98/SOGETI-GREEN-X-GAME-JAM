using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] GameObject playerHand;
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed
        , smoothTime, jumpForce;


    Rigidbody rigidBody;
    Vector3 moveAmount, smoothMoveVelocity;

    bool isgrounded, readyToPlay = false;
    float verticalLookRotation;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (readyToPlay)
        {
            Look();

            // TODO - to be made active after world setup
            Move();
            //Jump();
        }
    }

    private void FixedUpdate()
    { 
        rigidBody.MovePosition(rigidBody.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
     

    /// <summary>
    /// handles the way the player look 
    /// based on mouse movement
    /// </summary>
    private void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
        playerHand.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }


    /// <summary>
    /// handles actual player movement using keyboard input
    /// </summary>
    private void Move()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, dir * (Input.GetKeyDown(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }


    /// <summary>
    /// handles jumping code
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rigidBody.AddForce(transform.up * jumpForce);
        }
    }
     


    /// <summary>
    /// updates the ground state of player.
    /// true -> on the ground
    /// false -> above the ground 
    /// </summary>
    /// <param name="_state"></param>
    public void SetGroundedState(bool _state)
    {
        isgrounded = _state;
    }

    /// <summary>
    /// called when the player is ready and wants
    /// to start the game
    /// </summary>
    /// <param name="_status"></param>
    public void SetPlayStatus(bool _status)
    {
        readyToPlay = _status;
    }
}
