using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// class is used as helper class to Player which 
/// would detect ground contact
/// </summary>
public class PlayerGroundCheck : MonoBehaviour
{
    PlayerMovement playerController;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            playerController.SetGroundedState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            playerController.SetGroundedState(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            playerController.SetGroundedState(true);
        }
    }
}
