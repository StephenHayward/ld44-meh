using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    public MovementController GetMovementController { get { return movementController; } }
}
