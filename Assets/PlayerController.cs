using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (horizontalMovement != 0)
            movementController.Move(horizontalMovement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movementController.Jump();
        }
    }
}
