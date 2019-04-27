using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "AI States/Idle State")]
public class IdleAI : State
{
    [SerializeField] float maxWalk = 4;
    [SerializeField] float minWalk = 10;
    [SerializeField] float pauseDuration = 3;
    [SerializeField] float walkSpeed;

    float currentWalkAmount, targetWalkAmount, elapsed;
    int dir;

    public override void OnEnterState(Actor owner)
    {
        dir = (Random.Range(-1, 1) < 0) ? -1 : 1;
        targetWalkAmount = Random.Range(minWalk, maxWalk);
    }

    public override void OnExitState(Actor owner)
    {
    }

    public override void UpdateState(Actor owner)
    {
        // Check for chase condition


        // Update pause timer
        if(elapsed > 0)
        {
            elapsed = Mathf.MoveTowards(elapsed, 0, Time.deltaTime);
            return;
        }

        MovementController movementController = owner.GetMovementController;

        // Walk a random direction for a predefined amount of time
        if (currentWalkAmount < targetWalkAmount) {
            movementController.Move(walkSpeed * dir);
            currentWalkAmount += Time.deltaTime;

            if (movementController.IsWallLeft)
                dir = 1;
            else if(movementController.IsWallRight)
                dir = -1;
        }
        else
        {
            // Activate pause timer
            elapsed = pauseDuration;

            // Stop AI movement
            movementController.StopMoving();

            // Set next walk direction/target distance
            dir = (Random.Range(-1, 1) < 0) ? -1 : 1;
            targetWalkAmount = Random.Range(minWalk, maxWalk);
            currentWalkAmount = 0;

            name = "Enemy - Dir: " + dir;
        }
    }
}
